using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Switches the request culture and remembers it in a cookie.
/// </summary>
/// <remarks>
/// New, not migrated. The legacy layout had an "English" link with <c>href=""</c> and no
/// handler anywhere, so it did nothing; separately, five legacy views read a <c>Lang</c>
/// cookie that no code ever wrote (a latent NullReferenceException). This replaces both
/// with the standard ASP.NET Core localization cookie provider, so
/// <c>RequestLocalizationMiddleware</c> can resolve the culture on every request.
/// </remarks>
[AllowAnonymous]
public class CultureController : Controller
{
    private static readonly string CookieName = CookieRequestCultureProvider.DefaultCookieName;

    [HttpPost]
    [Route("/Culture/Set")]
    [ValidateAntiForgeryToken]
    public IActionResult Set(string? culture, string? returnUrl)
    {
        // Only honour cultures we actually support, otherwise the app would fall back to
        // the default anyway and the cookie would be meaningless.
        var supported = new[] { "ar", "en" };
        var chosen = culture is not null && supported.Contains(culture, StringComparer.OrdinalIgnoreCase)
            ? culture
            : "ar";

        Response.Cookies.Append(
            CookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(chosen)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                HttpOnly = false,
                SameSite = SameSiteMode.Lax,
                Secure = Request.IsHttps,
            });

        // Only allow local redirects - an open redirect here would be exploitable.
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }
}