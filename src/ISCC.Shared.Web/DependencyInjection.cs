using System.Diagnostics;
using System.Globalization;
using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace ISCC.Shared.Web;

/// <summary>
/// One place to register everything the three portals have in common.
/// </summary>
/// <remarks>
/// <para>
/// This is the fix for the parity problem: the wiring used to be copy-pasted into each
/// <c>Program.cs</c> and had already drifted, with localization added to one host and
/// missing from the other two. Now it cannot drift, because there is only one copy.
/// </para>
/// <para>
/// Deliberately does <b>not</b> register <c>AddControllers</c>,
/// <c>AddControllersWithViews</c>, CORS or Swagger. Those genuinely differ per host: the
/// portals are MVC, the Android API is a JSON API. Registering the shared parts only keeps
/// each host's <c>Program.cs</c> honest about what it actually is.
/// </para>
/// </remarks>
public static class SharedWebServiceCollectionExtensions
{
    /// <summary>Path the shared component assets are served from.</summary>
    public const string SharedAssetPath = "/_shared";

    /// <summary>
    /// Registers shared services: localization, the exception handler, JSON conventions,
    /// authorization and session.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">Configuration, for tunables such as session timeout.</param>
    public static IServiceCollection AddSharedWeb(this IServiceCollection services, IConfiguration configuration)
    {
        // Localization. ResourcesPath must match the physical layout under
        // ISCC.Shared.Localization, and the marker type must be SharedResource for
        // IStringLocalizer<SharedResource> to bind to SharedResource.resx.
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supported = new[] { new CultureInfo("en"), new CultureInfo("ar") };

            options.SetDefaultCulture("ar");
            options.SupportedCultures = supported;
            options.SupportedUICultures = supported;

            // Arabic is the default for these portals. The "ar" CultureInfo already
            // implies RTL layout, which the shared components read via [dir="rtl"].
            // Accept-Language first, cookie second: an explicit header should beat a
            // stale cookie.
            options.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new QueryStringRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider(),
                new CookieRequestCultureProvider()
            };
        });

        // Explicit, rather than relying on AddControllers* to pull it in transitively.
        // The Android API needs a real scheme in Phase 3; registering the services now
        // means that change is one call in Program.cs.
        services.AddAuthorization();

        // One exception handler for every host. SharedExceptionHandler serves JSON
        // callers; the framework's UseExceptionHandler serves HTML ones.
        services.AddExceptionHandler<SharedExceptionHandler>();
        services.AddProblemDetails();

        // One JSON configuration for every API surface.
        services.Configure<JsonOptions>(options =>
        {
            var shared = SharedApiJson.Options;
            options.JsonSerializerOptions.PropertyNamingPolicy = shared.PropertyNamingPolicy;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = shared.PropertyNameCaseInsensitive;
            options.JsonSerializerOptions.DefaultIgnoreCondition = shared.DefaultIgnoreCondition;
            options.JsonSerializerOptions.NumberHandling = shared.NumberHandling;
        });

        // Suppress [ApiController]'s automatic 400 so a failed ModelState comes back in
        // our envelope rather than ProblemDetails. The envelope is the contract, so
        // consistency beats the framework default here.
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        // Session needs a backing store. AddSession does NOT register one, and the
        // default SessionStore is DistributedSessionStore, which fails to resolve
        // IDistributedCache at pipeline-build time. That failure is not caught: the
        // whole host dies on startup with a DI exception, so any host calling
        // UseSession() without this line is dead in the water.
        services.AddDistributedMemoryCache();

        var idleMinutes = configuration.GetValue("Session:IdleTimeoutMinutes", 30);
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(idleMinutes);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SameSite = SameSiteMode.Lax;
        });

        return services;
    }

    /// <summary>
    /// Runs the shared pipeline, in the only order that works.
    /// </summary>
    /// <remarks>
    /// Order matters and is easy to get wrong by hand: exception handling must wrap
    /// everything after it, localization must precede anything that renders text, and
    /// session must follow routing.
    /// </remarks>
    /// <param name="app">The application builder.</param>
    /// <param name="useHttpsRedirection">Whether to redirect to HTTPS.</param>
    /// <param name="mvcErrorPath">
    /// Where to re-execute when a browser hits an unhandled fault. Pass null for a JSON
    /// API host, which has no error view.
    /// </param>
    /// <param name="useSession">
    /// Whether to insert the session middleware. Leave on for the browser portals; pass
    /// false for a token-authenticated API.
    /// </param>
    /// <remarks>
    /// The services are registered unconditionally by <c>AddSharedWeb</c> and only
    /// activated here, because registering them is harmless while using them is a
    /// decision. A host that inserts the middleware without the services registered dies
    /// at startup, which is loud; the reverse simply leaves the middleware out.
    /// </remarks>
    public static WebApplication UseSharedWeb(
        this WebApplication app,
        bool useHttpsRedirection = true,
        string? mvcErrorPath = "/Home/Error",
        bool useSession = true)
    {
        // The re-execute path is what serves HTML callers. Registered first so it wraps
        // the JSON IExceptionHandler, which sits inside it.
        if (mvcErrorPath is not null)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandlingPath = mvcErrorPath,

                // Without this, re-execution answers 500 for everything. That makes a
                // rejected form look like a server outage to any monitor keyed on 5xx,
                // and a missing record look like a crash. Reuse the JSON path's mapping
                // so both callers agree on what the failure was.
                //
                // The selector is given only the exception, not the context, so the
                // traceId is not available here. It does not matter: the error view
                // renders HttpContext.TraceIdentifier, which re-execution preserves, so
                // the id the user quotes still matches the logged row.
                StatusCodeSelector = exception =>
                    SharedExceptionHandler.Map(exception, Activity.Current?.Id ?? string.Empty).StatusCode
            });
        }

        if (useHttpsRedirection)
        {
            app.UseHttpsRedirection();
        }

        // Catches the failures that never become exceptions: an unmatched route, a
        // rejected CORS preflight, a 401 from the authentication middleware. Those
        // short-circuit with a status code and an empty body, so a client that only knows
        // how to read the envelope gets nothing to read.
        //
        // Exactly one status-code-pages middleware, and which one depends on the host:
        //
        //   - A portal re-executes to the shared error action, which content-negotiates
        //     and returns the view for a browser or the envelope for a JSON caller.
        //   - An API host has no view, so it writes the envelope directly.
        //
        // Registering BOTH on a portal would be a subtle bug, not a redundancy: the
        // middleware registered last is the innermost, so it fills the buffered body
        // first and the outer one then sees a non-empty response and does nothing. A JSON
        // caller would get HTML. One middleware, one writer.
        if (mvcErrorPath is not null)
        {
            app.UseStatusCodePagesWithReExecute(mvcErrorPath);
        }
        else
        {
            app.UseStatusCodePages(async statusCodeContext =>
            {
                var httpContext = statusCodeContext.HttpContext;
                var statusCode = httpContext.Response.StatusCode;

                await httpContext.Response.WriteAsJsonAsync(
                    new ApiResponse<object>
                    {
                        Success = false,
                        Error = new ApiError
                        {
                            Code = ErrorCodes.ForStatus(statusCode),
                            Message = ErrorCodes.MessageForStatus(statusCode),
                            TraceId = httpContext.TraceIdentifier
                        },
                        TraceId = httpContext.TraceIdentifier
                    },
                    SharedApiJson.Options);
            });
        }

        app.UseRequestLocalization();

        // Persist the language choice. Without this the query string is the only carrier
        // of the culture, and re-execution for an error page drops it, so an English user
        // who followed an Arabic-default link and hit a 404 lands on an Arabic error page.
        // Mirroring the resolved culture into the cookie makes the choice survive
        // navigation, error pages included.
        //
        // Must be registered AFTER UseRequestLocalization, or it captures the ambient
        // process culture rather than the one the request actually resolved to, and then
        // pins every visitor to whatever the machine was set to.
        //
        // The cookie is written BEFORE next(), on purpose. ResponseCookies.Append does not
        // check whether the response has already started, so appending after the endpoint
        // has run sets a header that is silently discarded once the body is flushed. The
        // symptom is a middleware that looks correct and writes nothing.
        //
        // Known limit: the very first request that both switches language and 404s still
        // renders the error page in the previous language, because re-execution reads the
        // request cookies parsed at the start of the outer request and this cookie is not
        // among them yet. It is correct from the next navigation onwards.
        app.Use(async (httpContext, next) =>
        {
            var culture = CultureInfo.CurrentUICulture;

            if (!string.IsNullOrEmpty(culture.Name))
            {
                httpContext.Response.Cookies.Append(
                    ".AspNetCore.Culture",
                    $"c={culture.Name}|uic={culture.Name}",
                    new CookieOptions
                    {
                        Path = "/",
                        HttpOnly = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.Lax,
                        // A year: the language choice is not a per-session preference.
                        Expires = DateTimeOffset.UtcNow.AddYears(1)
                    });
            }

            await next();
        });

        app.UseRouting();

        if (useSession)
        {
            app.UseSession();
        }

        app.UseAuthorization();

        return app;
    }

    /// <summary>
    /// Serves the shared component assets from this assembly at <c>/_shared/...</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The files are <b>embedded resources</b>, not loose files in the host's
    /// <c>wwwroot</c>. That matters: a Razor class library normally serves its
    /// <c>wwwroot</c> through the static-web-assets manifest, which only works when the
    /// host was published correctly, and under the path
    /// <c>/_content/ISCC.Shared.Web/...</c> that changes with the assembly name.
    /// </para>
    /// <para>
    /// Embedding makes the assets genuinely self-contained: identical in
    /// <c>dotnet run</c> and in an IIS publish, and reachable at one stable URL that a
    /// rename cannot break. Call this <b>instead of</b> <c>UseStaticFiles</c> for these
    /// files; the host's own <c>wwwroot</c>, if it has one, is still served separately at
    /// the root by the usual <c>UseStaticFiles</c>.
    /// </para>
    /// </remarks>
    /// <param name="app">The application builder.</param>
    public static WebApplication MapSharedWebAssets(this WebApplication app)
    {
        var assembly = typeof(SharedWebServiceCollectionExtensions).Assembly;
        var resourcePrefix = $"{assembly.GetName().Name}.wwwroot";

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new EmbeddedResourceFileProvider(assembly, resourcePrefix),
            RequestPath = SharedAssetPath
        });

        return app;
    }
}
