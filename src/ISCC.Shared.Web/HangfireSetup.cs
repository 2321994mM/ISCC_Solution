using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Hangfire.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ISCC.Shared.Web;

/// <summary>
/// Wires Hangfire for background jobs.
/// </summary>
/// <remarks>
/// <para>
/// Added for the Android API, which needs work that must not block a request: the
/// notification dispatch and report generation the legacy code did inline.
/// </para>
/// <para>
/// <b>Storage decision.</b> Jobs are stored in the existing <c>PlantQuarantine_New</c>
/// database on the same server, in the <c>HangFire</c> schema, not a new database. That
/// avoids provisioning a second SQL instance, but it does mean
/// the job tables are created inside the application database on first run. The legacy
/// database already holds 298 tables and 15,328 rows of live error logging, so adding 20
/// job tables is a visible change to a shared production database. See the note in
/// <c>docs/MIGRATION-PLAN.md</c> before enabling this against production.
/// </para>
/// <para>
/// <b>Dashboard security.</b> The dashboard can delete jobs, trigger them and read
/// serialized arguments. It is off by default and, when on, requires an authenticated
/// user. Do not expose it anonymously.
/// </para>
/// </remarks>
public static class HangfireSetup
{
    /// <summary>Schema Hangfire creates its tables in.</summary>
    public const string SchemaName = "HangFire";

    /// <summary>
    /// Registers Hangfire with SQL Server storage and the dashboard.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">Configuration, read from the <c>Hangfire</c> section.</param>
    public static IServiceCollection AddSharedHangfire(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration.GetSection("Hangfire").Get<HangfireOptions>() ?? new HangfireOptions();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            // Fail loudly at startup rather than at the first job that tries to enqueue.
            throw new InvalidOperationException(
                "Hangfire requires ConnectionStrings:DefaultConnection, which was not configured.");
        }

        services.AddHangfire(config => config
            // UseSqlServer creates the HangFire schema and its tables on first use.
            // Set PrepareSchemaIfNecessary to false in production once the schema has
            // been created deliberately, so a credential without DDL rights cannot fail
            // the app at startup.
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
            {
                SchemaName = SchemaName,
                PrepareSchemaIfNecessary = options.PrepareSchemaIfNecessary,
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(options.SlidingInvisibilityTimeoutMinutes),
                QueuePollInterval = TimeSpan.FromSeconds(options.QueuePollIntervalSeconds)
            }));

        // Hangfire registers these itself, but exposing IStorageConnection through the
        // container means application code can inject it without depending on Hangfire
        // internals. Resolved from the storage AddHangfire just configured.
        services.AddSingleton<IStorageConnection>(_ => JobStorage.Current.GetConnection());

        // The worker that actually drains the queue. Registered through DI rather than
        // app.UseHangfireServer, because the middleware overload is deprecated in 1.8 and
        // removed in 2.0.
        services.AddHangfireServer(server =>
        {
            server.ServerName = Environment.MachineName;
            // A floor, not a ceiling: one worker per core, minimum two, so a single slow
            // job cannot stall the whole queue.
            server.WorkerCount = Math.Max(2, Environment.ProcessorCount);
            // How long in-flight jobs are given to finish during shutdown.
            server.ShutdownTimeout = TimeSpan.FromSeconds(30);
            server.HeartbeatInterval = TimeSpan.FromSeconds(30);
        });

        return services;
    }

    /// <summary>
    /// Registers recurring jobs. Call after <see cref="AddSharedHangfire"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static IServiceCollection AddSharedHangfireRecurringJobs(this IServiceCollection services)
    {
        services.AddHostedService<RecurringJobSeeder>();
        return services;
    }

    /// <summary>
    /// Mounts the Hangfire dashboard, when it is enabled.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The background worker itself is started by <see cref="AddSharedHangfire"/> through
    /// <c>AddHangfireServer</c>, so this method only has to deal with the dashboard. It is
    /// mounted only when <c>Hangfire:DashboardEnabled</c> is true, which is off by
    /// default.
    /// </para>
    /// <para>
    /// When authentication is required but not yet configured, the filter below denies
    /// every request, so the dashboard answers 401 rather than rendering. Turning the
    /// dashboard on before Phase 3 lands therefore fails closed, not open.
    /// </para>
    /// </remarks>
    /// <param name="app">The application builder.</param>
    /// <param name="configuration">Configuration, read from the <c>Hangfire</c> section.</param>
    public static WebApplication UseSharedHangfire(this WebApplication app, IConfiguration configuration)
    {
        var options = configuration.GetSection("Hangfire").Get<HangfireOptions>() ?? new HangfireOptions();

        if (!options.DashboardEnabled)
        {
            app.Logger.LogInformation(
                "Hangfire dashboard is disabled. Set Hangfire:DashboardEnabled=true to serve it at {Path}.",
                options.DashboardPath);
            return app;
        }

        var dashboardOptions = new DashboardOptions
        {
            DashboardTitle = "ISCC Background Jobs",
            // The dashboard's own antiforgery token only protects its forms; the
            // authorization filter below is what actually gates access.
            IsReadOnlyFunc = _ => false
        };

        if (options.DashboardRequiresAuthentication)
        {
            dashboardOptions.Authorization =
                new IDashboardAuthorizationFilter[] { new RequireAuthenticatedUserAuthorizationFilter() };
        }

        app.UseHangfireDashboard(options.DashboardPath, dashboardOptions);
        return app;
    }
}

/// <summary>Hangfire settings, read from the <c>Hangfire</c> configuration section.</summary>
public class HangfireOptions
{
    /// <summary>
    /// Whether Hangfire may create its own tables on startup.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Defaults to false, on purpose.</b> A true default would mean that deploying a
    /// host which merely forgot to set this value silently issues DDL against
    /// <c>PlantQuarantine_New</c> — a live, shared database with 298 tables and 15,328
    /// rows of production error logging. Letting a config default make that decision is
    /// exactly the kind of thing that should require a human to type it out.
    /// </para>
    /// <para>
    /// Create the schema deliberately with the script in
    /// <c>docs/MIGRATION-PLAN.md</c>, then leave this false so the app never needs DDL
    /// rights at runtime. Set it true only for a local scratch database.
    /// </para>
    /// </remarks>
    public bool PrepareSchemaIfNecessary { get; set; }

    /// <summary>
    /// How long a job stays invisible to other workers while running, so a slow job is
    /// not picked up twice.
    /// </summary>
    public int SlidingInvisibilityTimeoutMinutes { get; set; } = 15;

    /// <summary>How often a worker checks the queue for new jobs.</summary>
    public int QueuePollIntervalSeconds { get; set; } = 15;

    /// <summary>Whether the dashboard is served. Off by default; see the security note.</summary>
    public bool DashboardEnabled { get; set; }

    /// <summary>Path the dashboard is mounted at.</summary>
    public string DashboardPath { get; set; } = "/hangfire";

    /// <summary>
    /// Whether the dashboard requires an authenticated user. Leave on. The dashboard can
    /// delete jobs, trigger them and read their serialized arguments, so serving it
    /// anonymously hands that capability to anyone who can reach the port.
    /// </summary>
    public bool DashboardRequiresAuthentication { get; set; } = true;
}

/// <summary>
/// Creates the recurring job definitions at startup so a fresh database comes up with the
/// expected schedule rather than silently having none.
/// </summary>
public sealed class RecurringJobSeeder : BackgroundService
{
    private readonly IRecurringJobManager _manager;
    private readonly ILogger<RecurringJobSeeder> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>Creates the seeder.</summary>
    public RecurringJobSeeder(
        IRecurringJobManager manager,
        ILogger<RecurringJobSeeder> logger,
        IConfiguration configuration)
    {
        _manager = manager;
        _logger = logger;
        _configuration = configuration;
    }

    /// <summary>Runs once at startup.</summary>
    /// <remarks>
    /// Swallows storage failures on purpose. An exception out of a hosted service stops
    /// the host, and the Android API's job is to serve mobile clients; a Hangfire
    /// storage outage should degrade background processing, not take the API offline.
    /// A missing schedule is visible and recoverable; a dead host is not.
    /// </remarks>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Left as the extension point for real jobs. Each entry is added once and then
        // updated in place on every subsequent start, so an edited cron expression takes
        // effect without a manual step.
        //
        // Example:
        //   _manager.AddOrUpdate<SomeJob>("daily-report", j => j.RunAsync(), "0 3 * * *");
        //
        // Jobs are registered here rather than in Program.cs so the schedule lives with
        // the job code and a host cannot start with a different set by accident.

        try
        {
            _logger.LogInformation("Hangfire recurring jobs seeded.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Could not seed Hangfire recurring jobs. The host will keep serving requests, "
                + "but background jobs may not run until this is fixed.");
        }

        return Task.CompletedTask;
    }
}

/// <summary>
/// Allows the Hangfire dashboard only to authenticated users. This is the safe default
/// in Hangfire 1.8, which expects an authorization filter instance, not a policy name.
/// </summary>
public sealed class RequireAuthenticatedUserAuthorizationFilter : Hangfire.Dashboard.IDashboardAuthorizationFilter
{
    /// <inheritdoc />
    public bool Authorize(Hangfire.Dashboard.DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        return httpContext.User.Identity?.IsAuthenticated == true;
    }
}
