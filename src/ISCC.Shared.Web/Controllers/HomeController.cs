using ISCC.Shared.Contracts;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Shared.Web.Controllers;

/// <summary>
/// The landing page and error page for every UI portal.
/// </summary>
/// <remarks>
/// <para>
/// Lives here rather than in a host because it previously existed in one portal only.
/// The client portal shipped a <c>HomeController</c> and the employers portal shipped
/// none, so <c>/</c> answered 200 in one and 404 in the other. One copy in the shared
/// project means neither portal can drift from the other.
/// </para>
/// <para>
/// The Android API is unaffected: it maps attribute routes only and has no conventional
/// default route, so nothing here is reachable there. The
/// <see cref="ApiExplorerSettingsAttribute"/> keeps it out of that host's Swagger
/// document as well, where it would otherwise appear as a page that does not respond.
/// </para>
/// </remarks>
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : BaseController
{
    /// <summary>Creates the controller and injects its localizer.</summary>
    public HomeController(Microsoft.Extensions.Localization.IStringLocalizer<
        ISCC.Shared.Localization.SharedResource> localizer)
        : base(localizer)
    {
    }

    /// <summary>
    /// The portal landing page. Replaced with real content as controllers are ported.
    /// </summary>
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = null;
        return View();
    }

    /// <summary>
    /// Renders the shared components against sample data.
    /// </summary>
    /// <remarks>
    /// A proof sheet, not a feature. It lets the table, select, select2 and pager be
    /// exercised end to end without porting a real page, so a component regression shows
    /// up here instead of in a migrated screen. Remove it once real pages depend on the
    /// components.
    /// </remarks>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Components() => View();

    /// <summary>
    /// Returns dropdown options for the cascading select2 on the components page.
    /// </summary>
    /// <remarks>
    /// Returns the <see cref="ApiResponse{T}"/> envelope rather than a bare array, so the
    /// shared script's envelope handling is exercised too. The components script accepts
    /// either shape; this is the shape real endpoints will use.
    /// </remarks>
    /// <param name="parentId">
    /// The parent value. Empty returns an empty list, which is what a cascading select
    /// should show before a parent is chosen.
    /// </param>
    [HttpGet]
    [AllowAnonymous]
    [Route("/Home/Options")]
    public ActionResult<ApiResponse<object>> Options([FromQuery] string? parentId)
    {
        if (string.IsNullOrEmpty(parentId))
        {
            return Ok(ApiResponse<object>.Ok(Array.Empty<object>()));
        }

        // Constant sample data. Reads nothing from the database on purpose.
        var options = new[]
        {
            new { id = parentId + "-1", text = "Option A" },
            new { id = parentId + "-2", text = "Option B" },
            new { id = parentId + "-3", text = "Option C" }
        };

        return Ok(ApiResponse<object>.Ok(options));
    }

    /// <summary>
    /// The shared error page.
    /// </summary>
    /// <remarks>
    /// The re-execution target configured by
    /// <c>UseSharedWeb(mvcErrorPath: "/Home/Error")</c>. The framework routes here after
    /// an unhandled fault and, separately, for a 4xx that never became an exception.
    /// Both preserve the original status code on the response, so reading it here is how
    /// the view knows whether to say "we logged this" or "that page does not exist".
    /// </remarks>
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Error()
    {
        // The trace id comes from the query string because this action is reached by
        // pipeline re-execution, not by a model, so there is nothing to bind. Falls back
        // to the current trace id, which re-execution preserves.
        var traceId = Request.Query["traceId"].FirstOrDefault()
                      ?? HttpContext.TraceIdentifier;

        // A 200 here means the page was opened directly rather than reached by a
        // failure, so report 0 and let the view fall back to the generic fault copy.
        var failedStatus = Response.StatusCode == StatusCodes.Status200OK
            ? 0
            : Response.StatusCode;

        // Reached by a JSON caller too, not just a browser. Status-code re-execution
        // routes everything here, so this action is the single place that decides the
        // representation of a failure that was never an exception.
        if (SharedExceptionHandler.WantsJson(HttpContext))
        {
            return StatusCode(failedStatus == 0 ? StatusCodes.Status500InternalServerError : failedStatus,
                new ApiResponse<object>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = ErrorCodes.ForStatus(failedStatus),
                        Message = ErrorCodes.MessageForStatus(failedStatus),
                        TraceId = traceId
                    },
                    TraceId = traceId
                });
        }

        return View(new ErrorViewModel { RequestId = traceId, StatusCode = failedStatus });
    }
}
