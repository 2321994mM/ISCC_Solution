using ISCC.Application.ImCommitteeFinalResult;
using ISCC.Application.ImCommitteeFinalResult.Dtos;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.Committees.Controllers;

/// <summary>
/// "نتيجة لجان الوارد" — import committee final result. Route mirrors the legacy URL so the
/// shared menu can point straight here.
/// </summary>
[Area("Committees")]
[Authorize]
[Route("Committees/ImCommittee_Final_Result")]
public class ImCommittee_Final_ResultController : BaseController
{
    private readonly IImCommitteeFinalResultService _service;
    private readonly IConfiguration _configuration;

    public ImCommittee_Final_ResultController(
        IStringLocalizer<SharedResource> localizer,
        IImCommitteeFinalResultService service,
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

    private long? SessionRequestId()
    {
        var raw = HttpContext.Session.GetString("requestId");
        return long.TryParse(raw, out var value) ? value : (long?)null;
    }

    /// <summary>
    /// Ported verb of the legacy GET. The old app stashed the request id in Session (kept
    /// here for the Json callbacks), stored the outlet/id filters as null defaults and built
    /// the same DTO via <see cref="IImCommitteeFinalResultService.GetAsync"/>.
    /// </summary>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        long? requestId,
        long? OutLet_ID,
        long? item_ShortName_ID = null,
        long? Lots_itemShortName_ID = null,
        long? CommitteeTypeLst_ID = null)
    {
        ViewData["PageHeading"] = L["ImCommittee_FinalResult_Title"];

        if (requestId.HasValue)
            HttpContext.Session.SetString("requestId", requestId.Value.ToString());

        var effectiveItemShortNameId = item_ShortName_ID ?? 0;
        var effectiveLotsItemShortNameId = Lots_itemShortName_ID ?? 0;
        var effectiveCommitteeTypeLstId = CommitteeTypeLst_ID ?? 0;

        ViewBag.Fullname = User.FindFirstValue(ClaimTypes.Name) ?? User.Identity?.Name;
        ViewBag.CommitteeTypeLst_Value = effectiveCommitteeTypeLstId;

        if (!requestId.HasValue)
            return View(null);

        var model = await _service.GetAsync(
            requestId.Value,
            effectiveItemShortNameId,
            effectiveLotsItemShortNameId,
            effectiveCommitteeTypeLstId,
            HttpContext.RequestAborted);

        // Legacy behavior: Outlets restrict the outlet that may be viewed.
        if (model != null && OutLet_ID.HasValue && model.OutLet_ID != OutLet_ID)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Index), $"Request {requestId} does not belong to outlet {OutLet_ID}");
            return Forbid();
        }

        return View(model);
    }

    /// <summary>Dropdown feed for the item short names of the current request.</summary>
    [HttpPost("ItemShortName_AddEDIT")]
    public async Task<IActionResult> ItemShortName_AddEDIT()
    {
        try
        {
            var req = SessionRequestId() ?? 0;
            var lst = await _service.GetItemShortNamesAsync(req, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Options = lst });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(ItemShortName_AddEDIT), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Dropdown feed for the lots of an item short name on the current request.</summary>
    [HttpPost("ItemLotName_AddEDIT")]
    public async Task<IActionResult> ItemLotName_AddEDIT(long ItemShortName_ID)
    {
        try
        {
            var req = SessionRequestId() ?? 0;
            var lst = await _service.GetLotsAsync(req, ItemShortName_ID, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Options = lst });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(ItemLotName_AddEDIT), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Reloads the composite payload for the selected item/lot filter.</summary>
    [HttpPost("SearchProducts")]
    public async Task<IActionResult> SearchProducts(long itemShortName, long lots_itemShortName)
    {
        try
        {
            var req = SessionRequestId() ?? 0;
            var model = await _service.GetAsync(req, itemShortName, lots_itemShortName, 0, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Records = model });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(SearchProducts), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Saves the quarantine standing of one lot.</summary>
    [HttpPost("Insert_Lot_Result")]
    public async Task<IActionResult> Insert_Lot_Result(
        long Lot_Category_ID,
        int IS_Status,
        string? Nots,
        Im_CheckRequest_Items_Lot_ResultDTO? Lot_ResultList)
    {
        try
        {
            var lotResult = Lot_ResultList ?? new Im_CheckRequest_Items_Lot_ResultDTO();
            lotResult.Im_CheckRequest_Items_Lot_Category_ID = Lot_Category_ID;
            lotResult.Nots = Nots;
            lotResult.IS_Status = IS_Status;
            lotResult.User_Creation_Date = DateTime.Now;
            lotResult.User_Creation_Id = GetUserId();

            var req = SessionRequestId() ?? 0;
            await _service.SaveLotResultAsync(req, lotResult, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Record = lotResult });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Insert_Lot_Result), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Saves the final quarantine standing of the current request.</summary>
    [HttpPost("Insert_Im_CheckRequest_Final_Result")]
    public async Task<IActionResult> Insert_Im_CheckRequest_Final_Result(
        int Im_Final_Result_ID,
        string? FinalResult,
        string? FinalResultList_Name)
    {
        try
        {
            var dto = new Im_CheckRequest_Final_ResultDTO
            {
                Im_Final_Result_ID = Im_Final_Result_ID,
                Date = DateTime.Now,
                User_Creation_Date = DateTime.Now,
                User_Creation_Id = GetUserId(),
                Im_CheckRequest_ID = SessionRequestId() ?? 0,
            };

            await _service.SaveFinalResultAsync(dto.Im_CheckRequest_ID.Value, dto, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Record = dto });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Insert_Im_CheckRequest_Final_Result), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Saves a visa decision for the current request.</summary>
    [HttpPost("Insert_Im_CheckRequest_Visa")]
    public async Task<IActionResult> Insert_Im_CheckRequest_Visa(long Visa_ID, Im_CheckRequest_VisaDTO? checkRequestVisa)
    {
        try
        {
            var visa = checkRequestVisa ?? new Im_CheckRequest_VisaDTO();
            visa.Im_Visa_ID = Visa_ID;
            visa.Date = DateTime.Now;
            visa.User_Creation_Date = DateTime.Now;
            visa.User_Creation_Id = GetUserId();
            visa.Im_CheckRequest_ID = SessionRequestId() ?? 0;

            await _service.SaveVisaAsync(visa.Im_CheckRequest_ID.Value, visa, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Record = visa });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Insert_Im_CheckRequest_Visa), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Returns one visa row for the visa description label.</summary>
    [HttpPost("VisaLabResult_AddEDIT")]
    public async Task<IActionResult> VisaLabResult_AddEDIT(int VisaResult)
    {
        try
        {
            var visa = await _service.GetVisaDataAsync(VisaResult, HttpContext.RequestAborted);
            return Json(new { Result = "OK", Options = visa });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(VisaLabResult_AddEDIT), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Lot result-status dropdown.</summary>
    [HttpPost("LotStatusLst_AddEDIT")]
    public async Task<IActionResult> LotStatusLst_AddEDIT()
    {
        try
        {
            var lst = await _service.GetLotStatusesAsync(HttpContext.RequestAborted);
            return Json(new { Result = "OK", Options = lst });
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(LotStatusLst_AddEDIT), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Soft-deletes a non-admin committee employee and logs it.</summary>
    [HttpPost("Delete_Emp_Confirm")]
    public async Task<IActionResult> Delete_Emp_Confirm(long requestId, long Committee_ID, long Employee_ID)
    {
        try
        {
            var ok = await _service.DeleteCommitteeEmployeeAsync(requestId, Committee_ID, Employee_ID, GetUserId(), HttpContext.RequestAborted);
            return ok ? Json("Su") : Json("Invalid");
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Delete_Emp_Confirm), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
        }
    }

    /// <summary>Sets the accepted flag on one lot-result row.</summary>
    [HttpPost("Update_Status_Confirm")]
    public async Task<IActionResult> Update_Status_Confirm(long Status_Id, bool Status_Bool)
    {
        try
        {
            var ok = await _service.SetLotResultStatusAsync(Status_Id, Status_Bool, HttpContext.RequestAborted);
            return ok ? Json("Su") : Json("Invalid");
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(Update_Status_Confirm), ex.ToString());
            return Json(new { Result = "ERROR", Message = "حدث خطأ" });
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

            // Legacy convention: replace spaces with "+" (URL encoding), then serve the file
            // from the configured network share path.
            path1 = "\\\\" + (_configuration["Path_NetworkShare"] ?? string.Empty) + path1.Replace("+", " ");
            var extension = path1.Split('.').LastOrDefault();
            var bytes = System.IO.File.ReadAllBytes(path1);

            if (string.Equals(extension, "pdf", StringComparison.OrdinalIgnoreCase))
                return File(bytes, "application/pdf");

            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(path1));
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImCommittee_Final_ResultController), nameof(GetReport), ex.ToString());
            return NotFound();
        }
    }
}

