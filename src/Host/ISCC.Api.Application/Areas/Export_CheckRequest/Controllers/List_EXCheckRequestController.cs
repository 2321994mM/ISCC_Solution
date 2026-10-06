using ISCC.Application.ExCheckRequests;
using ISCC.Application.ExCheckRequests.Dtos;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.Export_CheckRequest.Controllers;

/// <summary>
/// "طلبات فحص الصادر" (menu 100): request-number search and paged results list.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>PlantQuar.WEB/Areas/Export_CheckRequest/Controllers/List_EXCheckRequestController</c>.
/// The legacy Index read the user's station list and four permission flags, called
/// <c>EX_CheckRequests_API</c>, and rendered one page — search form, results table and
/// pager together. The station list and the flags turn out not to shape the query:
/// <c>GetListWithPage_List_filter</c> scopes purely by the user's <c>Station_Emp</c> rows
/// and the outlet id, so this port passes exactly those two values to
/// <see cref="IExCheckRequestListService"/>.
/// </para>
/// <para>
/// The route template is character-for-character the menu URL for item 100
/// (<c>Export_CheckRequest/List_EXCheckRequest/Index</c>), so the menu resolver links the
/// screen. Program.cs is untouched: attribute routing and the area attribute carry the rest.
/// The query strings keep the legacy names (<c>CurrentPage</c>, <c>Search</c>) so existing
/// bookmarks and the legacy pager's links still bind.
/// </para>
/// </remarks>
[Area("Export_CheckRequest")]
[Authorize]
[Route("Export_CheckRequest/List_EXCheckRequest")]
public class List_EXCheckRequestController : BaseController
{
    private readonly IExCheckRequestListService _service;

    public List_EXCheckRequestController(
        IStringLocalizer<SharedResource> localizer,
        IExCheckRequestListService service)
        : base(localizer)
    {
        _service = service;
    }

    /// <summary>
    /// The search form plus the paged results table, exactly as the legacy single-page
    /// Index rendered them.
    /// </summary>
    /// <param name="CurrentPage">Preserved page number; null or 1 renders the first page.</param>
    /// <param name="Search">Preserved request-number search term (contains-match).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        int CurrentPage = 1,
        string Search = "",
        CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["Ex_List_Title"];
            ViewData["Culture"] = CurrentCulture;

            var query = new ExCheckRequestListQuery(
                UserId(),
                OutletId(),
                Search ?? string.Empty,
                CurrentPage);

            var result = await _service.SearchAsync(query, cancellationToken);

            ViewBag.Search = Search ?? string.Empty;
            ViewBag.CurrentPage = result.PageNumber;
            ViewBag.TotalResults = result.TotalCount;
            ViewBag.TotalPages = result.TotalCount == 0
                ? 0
                : (int)Math.Ceiling(result.TotalCount / (double)result.PageSize);

            return View(result);
        }
        catch (Exception ex)
        {
            LogErrorToDb("List_EXCheckRequest", "Index", ex.ToString());
            throw;
        }
    }

    /// <summary>
    /// The signed-in user's <c>PR_User.Id</c>, from the name-identifier claim. Legacy read
    /// the same value — the short <c>Session["UserId"]</c> — and <c>Station_Emp.Emp_Id</c>
    /// stores it.
    /// </summary>
    private long UserId()
    {
        var raw = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return long.TryParse(raw, out var id) ? id : 0;
    }

    /// <summary>
    /// The signed-in user's business outlet id, from the <c>OutletId</c> claim. Legacy read
    /// the same value from Session; the <c>Ex_List</c> view's scope columns hold this id.
    /// </summary>
    private long OutletId()
    {
        var raw = User.FindFirstValue("OutletId");
        return long.TryParse(raw, out var id) ? id : 0;
    }
}