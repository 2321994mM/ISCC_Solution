using ISCC.Application;
using ISCC.Infrastructure;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
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

// Secure by default: anything not explicitly marked [AllowAnonymous] requires a signed-in
// user. Set as a fallback policy rather than by decorating each controller, because the
// failure mode of forgetting is an anonymous endpoint — the decoration is silent, the
// fallback is not.
//
// This is a behaviour change to Phase 3.1, whose three reference-data endpoints were
// verified while unauthenticated and now return 401. That is the correct posture for a
// staff portal: importers, outlets and quarantine statuses are internal lookups the legacy
// MVC app only ever served inside a session. The legacy solution had just 6 [Authorize]
// attributes across 587 controllers, so "public by default" was its de facto rule; that is
// the rule being replaced here.
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// Cookie authentication, registered here rather than in AddSharedWeb because the scheme
// genuinely differs per host: the two browser portals use cookies, the Android API will
// use bearer tokens. Registering it centrally would force one scheme on all three.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/Login";
        options.Cookie.Name = "ISCC.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromHours(8);

        // The portal is a multi-page MVC app, so the ticket must survive the redirect
        // back from the login POST. Without these the antiforgery token is lost on the
        // round trip and the form fails validation with no visible cause.
        options.Events.OnRedirectToLogin = context =>
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                // A JSON caller must not be handed a 302 to an HTML page.
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    error = new { code = "UNAUTHENTICATED", message = "Authentication is required." },
                    traceId = context.HttpContext.TraceIdentifier
                });
            }

            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };
    });

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
