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
    .WriteTo.File("logs/employers-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Layered dependencies, registered in dependency order.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Shared across all three hosts: localization, the exception handler, JSON conventions,
// session, authorization. See ISCC.Shared.Web/DependencyInjection.cs.
builder.Services.AddSharedWeb(builder.Configuration);

// This host is an MVC portal, so views rather than bare controllers.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Shared pipeline: exception handling first, then localization, routing, session,
// authorization. Each host no longer hand-orders these.
app.UseSharedWeb();
app.MapSharedWebAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/// <summary>Exposed so integration tests can use <c>WebApplicationFactory</c>.</summary>
public partial class Program { }
