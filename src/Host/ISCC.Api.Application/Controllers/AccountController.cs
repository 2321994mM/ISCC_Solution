using System.Security.Claims;
using ISCC.Application.Auth;
using ISCC.Application.Auth.Dtos;
using ISCC.Infrastructure.Auth;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Sign in and sign out for the employers and staff portal.
/// </summary>
/// <remarks>
/// <para>
/// <b>Not in an area, on purpose.</b> Authentication is cross-cutting rather than a
/// business area, and the route is load-bearing: <c>LoginPath</c> points here, the legacy
/// <c>PlantQuarantine.NewMvc</c> prototype used <c>/Account/Login</c>, and staff have it
/// bookmarked. Wrapping it in an <c>Account</c> area would give
/// <c>/Account/Account/Login</c> unless specially configured, breaking all three at once.
/// Business areas — Import, Farm, Export, Committee, Station — do get areas, starting at
/// Phase 3.2.
/// </para>
/// <para>
/// Derives from <see cref="BaseController"/> so the login page gets the shared localizer
/// and the legacy <c>A__plant_Error_Save</c> error log like every other page in the
/// portal.
/// </para>
/// </remarks>
[AllowAnonymous]
public class AccountController : BaseController
{
    /// <summary>The authentication scheme. Matches the one registered in DI.</summary>
    public const string Scheme = CookieAuthenticationDefaults.AuthenticationScheme;

    private readonly IUserAuthenticationService _authentication;
    private readonly AuthOptions _authOptions;

    public AccountController(
        IUserAuthenticationService authentication,
        IOptions<AuthOptions> authOptions,
        IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _authentication = authentication;
        _authOptions = authOptions.Value;
    }

    /// <summary>Sign-in form. Redirects an already-authenticated user to the home page.</summary>
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["ReturnUrl"] = SafeReturnUrl(returnUrl);
        return View(new LoginViewModel());
    }

    /// <summary>Validates credentials and issues the auth cookie.</summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellationToken)
    {
        // Re-derived rather than trusted from the form: the value round-trips through a
        // hidden field, so a tampered POST must not be able to redirect after login.
        var returnUrl = SafeReturnUrl(model?.ReturnUrl);

        if (model is null || !ModelState.IsValid)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(model ?? new LoginViewModel());
        }

        var user = await _authentication.ValidateCredentialsAsync(
            model.UserName, model.Password, cancellationToken);

        if (user is null)
        {
            // One message for "no such user" and "wrong password", so the form cannot be
            // used to discover which login names exist.
            //
            // The password-change case is NOT reported separately. When
            // Auth:RequirePasswordChange is on, 540 of 998 accounts are refused this way,
            // and telling those users "you must change your password" would be more
            // helpful — but only once the change-password screen exists to send them to.
            // Until then a distinct message is a dead end.
            ModelState.AddModelError(string.Empty, L["Login_Failed"]);
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        await HttpContext.SignInAsync(Scheme, BuildPrincipal(user, model), new AuthenticationProperties
        {
            IsPersistent = model.RememberMe,
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(
                model.RememberMe ? _authOptions.RememberMeHours : _authOptions.SessionHours)
        });

        if (!string.IsNullOrEmpty(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// Signs out and returns to the form.
    /// </summary>
    /// <remarks>
    /// No <c>[Authorize]</c>, deliberately. The class carries <c>[AllowAnonymous]</c>, which
    /// overrides an action-level <c>[Authorize]</c> outright, so adding one here would look
    /// like protection while doing nothing. Sign-out of an anonymous visitor is harmless —
    /// there is no cookie to clear — so anonymous access is the honest description.
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(Scheme);
        return RedirectToAction(nameof(Login));
    }

    /// <summary>
    /// Builds the signed-in principal.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Claim names and the 24h/8h split come from the legacy prototype. Two of its claims
    /// are not reproduced: it hardcoded <c>Language = "ar-Eg"</c> and
    /// <c>LanguageIsAr = "1"</c> on every sign-in, which pinned every user to Arabic
    /// regardless of what the portal's culture middleware had resolved. Here both are set
    /// from the request culture that actually resolved, so an English user gets English
    /// strings from any component that reads them.
    /// </para>
    /// <para>
    /// No password claim, and no password in any property. The credential is used to match
    /// the row and dropped.
    /// </para>
    /// </remarks>
    private ClaimsPrincipal BuildPrincipal(AuthenticatedUser user, LoginViewModel model)
    {
        var isArabic = CurrentCulture.StartsWith("ar", StringComparison.OrdinalIgnoreCase);
        var fullName = isArabic
            ? (user.FullNameAr.Length > 0 ? user.FullNameAr : user.FullNameEn)
            : (user.FullNameEn.Length > 0 ? user.FullNameEn : user.FullNameAr);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Name, fullName),

            // Kept as the legacy prototype spelled them, because views read these names.
            new("LoginName", user.LoginName),
            new("EmpId", user.EmpId.ToString()),
            new("OutletHr", user.OutletHrId?.ToString() ?? string.Empty),
            new("OutletId", user.OutletId?.ToString() ?? "0"),
            new("OutletName", isArabic ? user.OutletNameAr : user.OutletNameEn),
            new("OutletNameEn", user.OutletNameEn),
            new("OutletType", isArabic ? user.OutletTypeAr : user.OutletTypeEn),
            new("OutletTypeId", user.OutletTypeId?.ToString() ?? "0"),
            new("IsArabic", isArabic ? "1" : "0")
        };

        return new ClaimsPrincipal(
            new ClaimsIdentity(claims, Scheme, ClaimTypes.Name, ClaimTypes.Role));
    }

    /// <summary>
    /// Returns the return URL only when it is a local path.
    /// </summary>
    /// <remarks>
    /// Without this check, <c>?returnUrl=https://evil.example</c> turns a successful login
    /// into a redirect off-site — an open redirect, and a credible phishing primitive
    /// because the URL that produces it is the real login page. Any non-local value is
    /// dropped and the user lands on the home page instead.
    /// </remarks>
    private string? SafeReturnUrl(string? candidate) =>
        !string.IsNullOrWhiteSpace(candidate) && Url.IsLocalUrl(candidate) ? candidate : null;
}
