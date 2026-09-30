using ISCC.Application;
using ISCC.Infrastructure;
using ISCC.Shared.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Local, git-ignored overrides (real connection strings etc.).
if (File.Exists("appsettings.Local.json"))
{
    builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
}

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.File("logs/api-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Same shared wiring as both web portals: localization, one exception handler, one JSON
// configuration, authorization. The Android API previously had an
// ExceptionHandlingMiddleware file that was never registered in the pipeline, so it did
// nothing. UseSharedWeb() installs a real IExceptionHandler, which the framework
// guarantees will run.
builder.Services.AddSharedWeb(builder.Configuration);

// Background jobs. Hangfire replaces the inline notification and report work the legacy
// API did on the request thread.
builder.Services.AddSharedHangfire(builder.Configuration);
builder.Services.AddSharedHangfireRecurringJobs();

// This host is a JSON API, not a portal: no views, Swagger for the client team, CORS for
// the mobile app.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAndroid", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// The Hangfire dashboard can delete jobs, trigger them and read their serialized
// arguments, so RequireAuthenticatedUserAuthorizationFilter gates it. Until Phase 3 adds
// real authentication, no user satisfies that filter and the dashboard answers 401
// rather than rendering. That is the intended safe failure mode.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// No session, no static files, no MVC error view: this is an API.
//   useHttpsRedirection false - the reverse proxy terminates TLS in front of it.
//   mvcErrorPath null           - there is no error view to re-execute to.
//   useSession false            - a token API must not hold per-user state in process.
//                                  Session lives in that one process, so a second
//                                  instance behind the load balancer would silently see
//                                  an empty session, and the middleware would set a
//                                  cookie the API never reads.
// UseSharedWeb() still installs the exception handler, localization, routing and
// authorization, all of which this host does need.
app.UseSharedWeb(useHttpsRedirection: false, mvcErrorPath: null, useSession: false);

app.UseCors("AllowAndroid");
app.MapControllers();

// Starts the background worker, and mounts the dashboard when
// Hangfire:DashboardEnabled is true.
app.UseSharedHangfire(builder.Configuration);

app.Run();

/// <summary>Exposed so integration tests can use <c>WebApplicationFactory</c>.</summary>
public partial class Program { }
