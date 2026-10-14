using ISCC.Application.ImCheckRequestShowData;
using ISCC.Application.ImCheckRequestShowData.Dtos;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Areas.Im_CheckRequests.Controllers;

/// <summary>
/// "موقف طلبات الفحص الواردة" (menu 165): the per-outlet status board of import inspection
/// requests.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>Im_CheckRequests/Im_CheckRequest_ShowData</c> controller and its
/// <c>Im_CheckRequest_ShowDataBLL</c>. The legacy Index called an API endpoint that ran
/// <c>Pro_Im_CheckRequest_ShowData</c> and handed the rows to the view; a single JSON feed is
/// no longer needed, so the page is now rendered server-side through
/// <see cref="IImCheckRequestShowDataService.GetAllAsync"/>.
/// </para>
/// <para>
/// The route template below is character-for-character the legacy URL
/// (<c>Im_CheckRequests/Im_CheckRequest_ShowData</c>) so the menu entry keeps working.
/// </para>
/// </remarks>
[Area("Im_CheckRequests")]
[Authorize]
[Route("Im_CheckRequests/Im_CheckRequest_ShowData")]
public class Im_CheckRequest_ShowDataController : BaseController
{
    private readonly IImCheckRequestShowDataService _service;

    public Im_CheckRequest_ShowDataController(
        IStringLocalizer<SharedResource> localizer,
        IImCheckRequestShowDataService service)
        : base(localizer)
    {
        _service = service;
    }

    /// <summary>Renders the status board.</summary>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["ImShowData_Title"];
            ViewData["Culture"] = CurrentCulture;

            var isArabic = CurrentCulture.StartsWith("ar", StringComparison.OrdinalIgnoreCase);
            var model = await _service.GetAllAsync(isArabic, cancellationToken);
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(Im_CheckRequest_ShowDataController), nameof(Index), ex.ToString());
            return View(Array.Empty<ImCheckRequestShowDataDto>());
        }
    }
}
