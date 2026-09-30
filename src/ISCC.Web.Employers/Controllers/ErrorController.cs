using ISCC.Shared.Localization;
using ISCC.Web.Employers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Web.Employers.Controllers;

/// <summary>
/// 404 handling. Migrated from <c>Capqwebsite/Controllers/ErrorController.cs</c>
/// (16 lines — it only rendered a static view).
/// </summary>
public class ErrorController : BaseController
{
    public ErrorController(IStringLocalizer<SharedResource> localizer) : base(localizer) { }

    [AllowAnonymous]
    [Route("/Error/HandleError")]
    public IActionResult HandleError([FromQuery] int? id)
    {
        if (id == 404)
            return View("NotFound");

        return View("Error", new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier
        });
    }
}