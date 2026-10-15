using ISCC.Application.ImCheckRequests;
using ISCC.Application.ImCheckRequests.Dtos;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.Im_CheckRequests.Controllers;

/// <summary>
/// "طلبات الفحص الحالية - وارد" (menu 104): search form and paged results list.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>PlantQuar.WEB/Areas/Im_CheckRequests/Controllers/List_ImCheckRequestController</c>.
/// The legacy Index set default dates (<c>today</c> and <c>today - 7</c>), read a
/// <c>message</c> from Session and returned the search form; the list action called an API
/// method that ran <c>List_ImCheckRequest_Data</c>, then returned <c>Im_CheckRequest_List</c>
/// or redirected to Index with a "no data" message. Both actions, plus the two JSON
/// dropdown feeds, are replaced by <see cref="IImCheckRequestListService"/>.
/// </para>
/// <para>
/// This screen is the first real Area in the new portal. The route template below is
/// character-for-character the menu URL for item 104
/// (<c>Im_CheckRequests/List_ImCheckRequest/Index</c>), so the menu resolver links it.
/// Program.cs is untouched: attribute routing and the area attribute carry the rest.
/// </para>
/// </remarks>
[Area("Im_CheckRequests")]
[Authorize]
[Route("Im_CheckRequests/List_ImCheckRequest")]
public class List_ImCheckRequestController : BaseController
{
    private readonly IImCheckRequestListService _service;

    public List_ImCheckRequestController(
        IStringLocalizer<SharedResource> localizer,
        IImCheckRequestListService service)
        : base(localizer)
    {
        _service = service;
    }

    /// <summary>The portal's search form for import inspection requests.</summary>
    /// <remarks>
    /// Server-rendered, not a partial: companies need the outlet and the final-result
    /// options depend on the status already chosen, so the controller fetches both ahead of
    /// the view. Defaults the date window to the last seven days, as legacy did.
    /// </remarks>
    /// <param name="dateFrom">Preserved search start; null renders today minus seven days.</param>
    /// <param name="dateTo">Preserved search end; null renders today.</param>
    /// <param name="selectApproveId">Preserved request-status filter (1-7), when returning from a search.</param>
    /// <param name="finalResultListId">Preserved quarantine final-result filter (6/7 only).</param>
    /// <param name="checkRequestNumber">Preserved request-number filter.</param>
    /// <param name="companyId">Preserved company filter.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        int selectApproveId = 0,
        int finalResultListId = 0,
        string? checkRequestNumber = null,
        long companyId = 0,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["Im_List_Title"];
            ViewData["Culture"] = CurrentCulture;

            var outletId = OutletId();

            ViewBag.DateFrom = (dateFrom ?? DateTime.Now.AddDays(-7)).Date;
            ViewBag.DateTo = (dateTo ?? DateTime.Now).Date;
            ViewBag.SelectApproveId = selectApproveId;
            ViewBag.FinalResultListId = finalResultListId;
            ViewBag.CheckRequestNumber = checkRequestNumber ?? string.Empty;
            ViewBag.CompanyId = companyId;

            ViewBag.Companies = await _service.GetCompaniesAsync(outletId, cancellationToken);

            // The quarantine-status filter (6 = working, 7 = not working) offers a second
            // select of final results. Its options depend on the status, so they are
            // only fetched for a chosen status; otherwise the select holds the sentinel.
            ViewBag.FinalResults = selectApproveId is 6 or 7
                ? await _service.GetFinalResultOptionsAsync(selectApproveId, cancellationToken)
                : Array.Empty<ISCC.Shared.Contracts.SelectOption>();

            ViewBag.Message = TempData["ListMessage"]?.ToString();
            return View();
        }
        catch (Exception ex)
        {
            LogErrorToDb("List_ImCheckRequest", "Index", ex.ToString());
            throw;
        }
    }

    /// <summary>Runs the search and renders the paged results table, or the results partial.</summary>
    /// <remarks>
    /// Mirrors the new legacy flow: a request number is a search of its own and drops the other
    /// filters; an AJAX call (the search form's normal path now) gets the results partial so it
    /// can be dropped into the page, while a plain GET still renders the full page. A plain GET
    /// with no rows sends the user back to the search form with a "no data" message, and a
    /// database error logs to <c>A__plant_Error_Save</c>. Query strings keep the legacy names —
    /// including <c>PageNumber</c> — so existing bookmarks still work.
    /// </remarks>
    [HttpGet("Im_CheckRequest_List")]
    public async Task<IActionResult> Im_CheckRequest_List(
        DateTime? dateFrom = null,
        DateTime? dateEnd = null,
        int selectApproveId = 0,
        int finalResultListId = 0,
        string? CheckRequest_Number = null,
        long Company_ID = 0,
        int page = 1,
        int PageNumber = 0,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var requestNumber = (CheckRequest_Number ?? string.Empty).Trim();
            var currentPage = Math.Max(1, PageNumber > 0 ? PageNumber : page);

            var start = (dateFrom ?? DateTime.Now.AddDays(-7)).Date;
            var end = (dateEnd ?? DateTime.Now).Date;

            if (requestNumber.Length > 0)
            {
                // A request number searches on its own. The data layer still demands a valid
                // date range, so this wide window neutralises the date filter, and 1 means
                // "all statuses" to the procedure while 0 would return nothing.
                start = new DateTime(1900, 1, 1);
                end = new DateTime(9999, 12, 30);
                selectApproveId = 1;
                finalResultListId = 0;
                Company_ID = 0;
            }
            else if (selectApproveId <= 0)
            {
                TempData["ListMessage"] = L["Im_List_SelectStatus"].Value;
                return RedirectToAction(nameof(Index));
            }

            var isArabic = CurrentCulture.StartsWith("ar", StringComparison.OrdinalIgnoreCase);

            var query = new ImCheckRequestListQuery(
                OutletId(),
                start,
                end,
                selectApproveId,
                finalResultListId,
                requestNumber,
                Company_ID,
                currentPage,
                isArabic);

            var result = await _service.SearchAsync(query, cancellationToken);

            var isAjax = string.Equals(
                Request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);

            if (result.Items.Count == 0 && !isAjax)
            {
                TempData["ListMessage"] = L["Im_List_NoData"].Value;
                return RedirectToAction(nameof(Index));
            }

            ViewData["PageHeading"] = L["Im_List_Title"];
            ViewData["Culture"] = CurrentCulture;
            ViewBag.SelectApproveId = selectApproveId;
            ViewBag.DateFrom = start;
            ViewBag.DateEnd = end;
            ViewBag.FinalResultListId = finalResultListId;
            ViewBag.CheckRequestNumber = requestNumber;
            ViewBag.CompanyId = Company_ID;

            return isAjax
                ? PartialView(nameof(Im_CheckRequest_List), result)
                : View(result);
        }
        catch (Exception ex)
        {
            LogErrorToDb("List_ImCheckRequest", "Im_CheckRequest_List", ex.ToString());

            if (string.Equals(
                    Request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase))
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Content(L["Im_List_LoadError"].Value);
            }

            TempData["ListMessage"] = L["Im_List_NoData"];
            return RedirectToAction(nameof(Index));
        }
    }

    /// <summary>
    /// The quarantine-status options for a chosen request status (6 = working, 7 = not working).
    /// </summary>
    /// <remarks>
    /// The screen's second select cannot be rendered once and reused: its rows are filtered by
    /// the request status, so the new legacy screen fetched them on every change. This is that
    /// round trip, returning the shape the page's script expects.
    /// </remarks>
    [HttpGet("FinalResultOptions")]
    public async Task<IActionResult> FinalResultOptions(
        int selectApproveId, CancellationToken cancellationToken = default)
    {
        try
        {
            var options = await _service.GetFinalResultOptionsAsync(selectApproveId, cancellationToken);
            return Json(options.Select(option => new { value = option.Value, text = option.Text(CurrentCulture) }));
        }
        catch (Exception ex)
        {
            LogErrorToDb("List_ImCheckRequest", "FinalResultOptions", ex.ToString());
            throw;
        }
    }

    /// <summary>The signed-in user's business outlet id, from the <c>OutletId</c> claim.</summary>
    /// <remarks>
    /// The claim holds the business <c>Outlet.Id</c>, which is what the stored procedure's
    /// <c>@outlet_User</c> compares against <c>Im_CheckRequest.Outlet_ID</c>. Legacy read the
    /// same value from Session.
    /// </remarks>
    private long OutletId()
    {
        var raw = User.FindFirstValue("OutletId");
        return long.TryParse(raw, out var id) ? id : 0;
    }
}