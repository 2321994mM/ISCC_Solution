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
    .WriteTo.File("logs/client-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Identical to the other two hosts. This was previously missing here entirely, which is
// why localization was wired in one portal and silently absent from this one.
builder.Services.AddSharedWeb(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSharedWeb();
app.MapSharedWebAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/// <summary>Exposed so integration tests can use <c>WebApplicationFactory</c>.</summary>
public partial class Program { }
