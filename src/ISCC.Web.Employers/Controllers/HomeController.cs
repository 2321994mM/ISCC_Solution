using System.Diagnostics;
using ISCC.Application.Cms;
using ISCC.Application.Cms.Dtos;
using ISCC.Shared.Localization;
using ISCC.Web.Employers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Web.Employers.Controllers;

/// <summary>
/// Public home page. Migrated from <c>Capqwebsite/Controllers/HomeController.cs</c>.
/// </summary>
/// <remarks>
/// The legacy action built the page with five inline LINQ queries against a
/// <c>new AgricultureDBContext()</c>. Those five queries are now
/// <see cref="ICmsContentService.GetHomePageAsync"/>.
/// <para>
/// <c>Privacy</c> was dropped: it was an unlinked ASP.NET scaffold stub.
/// </para>
/// </remarks>
public class HomeController : BaseController
{
    private readonly ICmsContentService _cms;

    public HomeController(ICmsContentService cms, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _cms = cms;
    }

    [AllowAnonymous]
    [Route("/")]
    [Route("/Home/HomePage/Index")]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        try
        {
            HomePageDto page = await _cms.GetHomePageAsync(cancellationToken);
            return View(page);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(HomeController), nameof(Index), ex.Message);
            throw;
        }
    }

    /// <summary>Logout. Present on the legacy home controller and in the top bar.</summary>
    [AllowAnonymous]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }

    /// <summary>
    /// Truncates to 150 characters total including the ellipsis.
    /// Carried over from the legacy controller, which exposed it as a public static
    /// helper; no controller called it, so it is kept only for the Razor views.
    /// </summary>
    public static string CutTo150(string? input)
    {
        if (input is null) return string.Empty;
        if (input.Length <= 150) return input;
        return input[..147] + "...";
    }
}