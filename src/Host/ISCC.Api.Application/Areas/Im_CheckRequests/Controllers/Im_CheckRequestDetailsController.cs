using ISCC.Application.ImCheckRequestDetails;
using ISCC.Application.ImCheckRequestDetails.Dtos;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.Im_CheckRequests.Controllers;

/// <summary>
/// "تفاصيل طلب الفحص - وارد" — the read/detail screen of one import inspection request.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>Im_CheckRequests/Im_CheckRequestDetails</c> controller and its
/// <c>Im_CheckRequestDetailsBLL</c>. The legacy page loaded everything through one API
/// endpoint (now <see cref="IImCheckRequestDetailsService.GetAsync"/>), showed the refuse-reason
/// dropdown, and posted four small actions: save refuse reasons, accept/reject the request,
/// edit an item's fees, and serve a report file.
/// </para>
/// <para>
/// The route template below is character-for-character the legacy URL
/// (<c>Im_CheckRequests/Im_CheckRequestDetails</c>) so the menu and the links from
/// <c>ImCommittee_Final_Result</c> keep working.
/// </para>
/// </remarks>
[Area("Im_CheckRequests")]
[Authorize]
[Route("Im_CheckRequests/Im_CheckRequestDetails")]
public class Im_CheckRequestDetailsController : BaseController
{
    private readonly IImCheckRequestDetailsService _service;
    private readonly IConfiguration _configuration;

    public Im_CheckRequestDetailsController(
        IStringLocalizer<SharedResource> localizer,
        IImCheckRequestDetailsService service,
        IConfiguration configuration)
        : base(localizer)
    {
        _service = service;
        _configuration = configuration;
    }

    /// <summary>Mirrors <c>(short)Session["UserId"]</c> in the legacy controller.</summary>
    private short GetUserId()
    {
        var raw = User.FindFirstValue("UserId");
        return short.TryParse(raw, out var value) ? value : (short)0;
    }

    /// <summary>
    /// Renders the whole detail page for one request number. The legacy page also loaded the
    /// refuse-reason dropdown and the button-visibility flag.
    /// </summary>
    /// <param name="ImCheckRequest_Number">The request number (<c>CheckRequest_Number</c>).</param>
    /// <param name="Outlet_ID">The outlet the caller came from (kept for legacy URL compatibility).</param>
    /// <param name="Hide_Button">Non-zero hides the accept/reject action buttons.</param>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        string? ImCheckRequest_Number,
        int Outlet_ID,
        int Hide_Button = 0,
        CancellationToken cancellationToken = default)
    {
        ViewData["PageHeading"] = L["Im_CheckRequestDetails_Title"];
        ViewData["Culture"] = CurrentCulture;

        ViewBag.ListReasons = await _service.GetRefuseReasonsAsync(1, cancellationToken);
        ViewBag.Hide_Button = Hide_Button;

        if (string.IsNullOrWhiteSpace(ImCheckRequest_Number))
            return View(null);

        var model = await _service.GetAsync(ImCheckRequest_Number, Outlet_ID, cancellationToken);
        return View(model);
    }

    /// <summary>Saves the selected refuse reasons against the request.</summary>
    [HttpPost("saveReasons")]
    public async Task<IActionResult> saveReasons(
        List<short>? listIDs,
        long checkReqId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var dto = new ReasonsListReqIdDto
            {
                checkReqId = checkReqId,
                refuseReasonsIds = listIDs ?? new List<short>(),
                User_Creation_Id = GetUserId(),
                User_Creation_Date = DateTime.Now,
            };

            await _service.SaveReasonsAsync(dto, cancellationToken);
            return Json("succ");
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(Im_CheckRequestDetailsController), nameof(saveReasons), ex.ToString());
            return Json("ERROR");
        }
    }

    /// <summary>
    /// Accepts or rejects the whole request. The legacy action flipped the request flags then
    /// wrote a log row and returned to the current-requests list.
    /// </summary>
    [HttpPost("acceptRequest")]
    public async Task<IActionResult> acceptRequest(ImRequestDetailsDto model, CancellationToken cancellationToken = default)
    {
        try
        {
            var dto = new ImCheckRequestDto
            {
                ID = model.Im_CheckRequest_ID,
                IsAccepted = model.IsAccepted,
                IsAccepted_Date = DateTime.Now,
                IsActive = model.IsAccepted,
                User_Updation_Id = GetUserId(),
                User_Updation_Date = DateTime.Now,
            };

            await _service.AcceptRequestAsync(dto, cancellationToken);

            return RedirectToAction("Index", "List_ImCheckRequest", new { area = "Im_CheckRequests" });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(Im_CheckRequestDetailsController), nameof(acceptRequest), ex.ToString());
            return RedirectToAction("Index", "List_ImCheckRequest", new { area = "Im_CheckRequests" });
        }
    }

    /// <summary>Updates the fees of one imported item and logs the change.</summary>
    [HttpPost("saveItemFees")]
    public async Task<IActionResult> saveItemFees(
        long? itemId,
        long Im_CheckRequest_ID,
        decimal? fees,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var item = new ItemFeesDto
            {
                ImcheckReqItem_ID = itemId,
                Fees = fees,
                User_Updation_Id = GetUserId(),
                User_Updation_Date = DateTime.Now,
            };

            await _service.SaveItemFeesAsync(item, cancellationToken);
            return Json("succ");
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(Im_CheckRequestDetailsController), nameof(saveItemFees), ex.ToString());
            return Json("ERROR");
        }
    }

    /// <summary>Serves a report file from the shared network path, like the legacy GET.</summary>
    [HttpGet("GetReport")]
    public IActionResult GetReport(string? path1)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(path1))
                return NotFound();

            // Legacy convention: the path arrives with "+" in place of spaces; restore them and
            // serve the file from the configured network share.
            path1 = "\\\\" + (_configuration["Path_NetworkShare"] ?? string.Empty) + path1.Replace("+", " ");
            var extension = path1.Split('.').LastOrDefault();
            var bytes = System.IO.File.ReadAllBytes(path1);

            if (string.Equals(extension, "pdf", StringComparison.OrdinalIgnoreCase))
                return File(bytes, "application/pdf");

            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(path1));
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(Im_CheckRequestDetailsController), nameof(GetReport), ex.ToString());
            return NotFound();
        }
    }
}
