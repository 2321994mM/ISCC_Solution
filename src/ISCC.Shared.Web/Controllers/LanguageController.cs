using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Shared.Web.Controllers;

/// <summary>
/// Flips the portal between Arabic and English.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>BaseController.ChangeLanguage</c>
/// (<c>PlantQuar.WEB</c>), which toggled <c>Session["Language"]</c> between
/// "ar-Eg" and "en-Us" and bounced back to the referring page. The URL
/// <c>/Base/ChangeLanguage</c> is kept so staff bookmarks still work; the
/// session value becomes the standard <c>.AspNetCore.Culture</c> request-culture
/// cookie, which the <c>CookieRequestCultureProvider</c> already consults ahead
/// of the Arabic default, and which the sticky-culture middleware in
/// <c>DependencyInjection</c> mirrors onto every cookie-less request.
/// </remarks>
public class LanguageController : Controller
{
    /// <summary>
    /// Switches culture and returns to the page the user came from.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The legacy action had three behaviours worth keeping:
    /// </para>
    /// <list type="bullet">
    /// <item><description>
    /// Default to Arabic. Anonymous visitors were bounced to login before the
    /// action ran, so the choice only ever applied to a signed-in session — the
    /// host's <c>FallbackPolicy</c> (<c>RequireAuthenticatedUser</c>) preserves
    /// that, which is also why this action has no <c>[AllowAnonymous]</c>.
    /// </description></item>
    /// <item><description>
    /// The flip is remembered. The culture cookie is written with the same
    /// one-year lifetime, <c>HttpOnly</c> and <c>SameSite=Lax</c> options the
    /// sticky-culture middleware uses, so the two writers produce identical
    /// cookies and the choice outlives the browser session. (The legacy session
    /// reset to Arabic each login; the middleware that predates this controller
    /// deliberately made the choice persistent — see <c>DependencyInjection</c>.)
    /// </description></item>
    /// <item><description>
    /// Redirect back to the caller. The legacy version used
    /// <c>Request.UrlReferrer</c> unchecked, which redirects anywhere — an open
    /// redirect when someone lands here from an external link. Browsers send the
    /// <c>Referer</c> header as an absolute URL, which <c>Url.IsLocalUrl</c>
    /// rejects, so <see cref="TryLocalPath"/> matches scheme, host and port
    /// against the request and only then redirects to the referer's path; a
    /// hostile referer (wrong host or scheme) falls back to the home page.
    /// </description></item>
    /// </list>
    /// </remarks>
    [HttpGet]
    [Route("Base/ChangeLanguage")]
    public IActionResult ChangeLanguage()
    {
        var current = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        var target = current.StartsWith("ar", StringComparison.OrdinalIgnoreCase) ? "en" : "ar";

        // Same value (@c=xx|uic=xx@) and same options the sticky-culture middleware writes,
        // so a flip replaces it cleanly instead of stacking a second, different cookie.
        // ASP.NET Core URL-escapes the value on the wire (c=en|uic=en arrives as
        // c%3Den%7Cuic%3Den); CookieRequestCultureProvider unescapes when parsing.
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            $"c={target}|uic={target}",
            new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });

        var referer = Request.Headers.Referer.ToString();
        if (TryLocalPath(referer, out var localPath))
        {
            // Keep the query string: a referer ending in ?culture=en must return to that
            // URL's own culture-selecting query, not bounce it back to the bare page.
            return Redirect(localPath);
        }

        return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// Reduces a referer to a local path, or fails.
    /// </summary>
    /// <remarks>
    /// Browsers send the <c>Referer</c> header as an absolute URL, while
    /// <see cref="UrlHelper.IsLocalUrl"/> only accepts relative paths — so an absolute
    /// referer would always lose and the flip would never return to the page the user
    /// came from. Match scheme, host and port against the request first and take the
    /// referer's path, then allow bare relative paths through <c>IsLocalUrl</c>, and
    /// reject everything else.
    /// </remarks>
    private bool TryLocalPath(string? referer, out string path)
    {
        if (Uri.TryCreate(referer, UriKind.Absolute, out var uri)
            && string.Equals(uri.Scheme, Request.Scheme, StringComparison.OrdinalIgnoreCase)
            && string.Equals(uri.Host, Request.Host.Host, StringComparison.OrdinalIgnoreCase)
            && (Request.Host.Port is null || uri.Port == Request.Host.Port))
        {
            path = uri.PathAndQuery;
            return true;
        }

        if (Url.IsLocalUrl(referer))
        {
            path = referer;
            return true;
        }

        path = string.Empty;
        return false;
    }
}