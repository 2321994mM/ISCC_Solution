using ISCC.Infrastructure.Data.Generated;
using ISCC.Api.Application.Areas.DE_Outlets.Models;
using ISCC.Api.Application.Areas.DE_Outlets.Services;
using ISCC.Shared.Contracts;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.DE_Outlets.Controllers;

/// <summary>
/// "المنافذ" (menu item): search form and paged results list for outlets.
/// </summary>
/// <remarks>
/// Ported from the legacy Capqwebsite/Areas/DE_Outlets/Controllers/OutletController.
/// The legacy Index returned a jTable-based view; this version uses a standard
/// Bootstrap search form and server-rendered results table.
/// The route template below matches the menu URL for "المنافذ" (DE_Outlets/Outlet/Index).
/// Program.cs is untouched: attribute routing and the area attribute carry the rest.
/// </remarks>
[Area("DE_Outlets")]
[Authorize]
[Route("DE_Outlets/Outlet")]
public class OutletController : BaseController
{
    public OutletController(IStringLocalizer<SharedResource> localizer) : base(localizer) { }

    /// <summary>The outlets list page (menu "المنافذ").</summary>
    /// <remarks>
    /// The newer legacy source made this a single-page shell: the hero, filter panel, table
    /// and edit modal are all rendered by the view, and the rows arrive over AJAX from
    /// <see cref="listOutlet"/>. The action therefore does nothing but return the view —
    /// the search is no longer a server round-trip, so there is no <c>GeneralAdmins</c>
    /// lookup and no redirect to <see cref="List"/>.
    /// </remarks>
    [HttpGet("Index")]
    public IActionResult Index()
    {
        try
        {
            ViewData["PageHeading"] = L["DE_Outlets_Outlet_Title"];
            return View();
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Index", ex.ToString());
            throw;
        }
    }

    /// <summary>Runs the search and renders the paged results table.</summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(
        string? searchAr = null,
        string? searchEn = null,
        byte? generalAdminId = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["DE_Outlets_Outlet_Title"];
            ViewData["Culture"] = CurrentCulture;

            ViewBag.SearchAr = searchAr ?? string.Empty;
            ViewBag.SearchEn = searchEn ?? string.Empty;
            ViewBag.GeneralAdminId = generalAdminId ?? 0;

            var query = Db.Outlets
                .Where(o => o.UserDeletionId == null)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchAr))
                query = query.Where(o => o.ArName != null && o.ArName.Contains(searchAr));

            if (!string.IsNullOrWhiteSpace(searchEn))
                query = query.Where(o => o.EnName != null && o.EnName.Contains(searchEn));

            if (generalAdminId.HasValue && generalAdminId.Value > 0)
                query = query.Where(o => o.GrAdminId == generalAdminId.Value);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(o => o.ArName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(o => new
                {
                    o.Id,
                    o.ArName,
                    o.EnName,
                    o.AddressAr,
                    o.AddressEn,
                    o.IsActive,
                    o.IsDisplay,
                    o.IsExport,
                    GrAdminName = o.GrAdmin != null ? o.GrAdmin.ArName : string.Empty,
                    CenterCount = o.Centers.Count(c => c.UserDeletionId == null)
                })
                .ToListAsync(cancellationToken);

            var totalPages = totalCount == 0 ? 1 : (int)Math.Ceiling(totalCount / (double)pageSize);

            ViewBag.TotalCount = totalCount;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.Items = items;

            return View();
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "List", ex.ToString());
            throw;
        }
    }

    /// <summary>Shows the create/edit form for an outlet.</summary>
    [HttpGet("Create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["DE_Outlets_Outlet_Create"];
            ViewData["Culture"] = CurrentCulture;

            await PopulateDropdownsAsync(cancellationToken);
            return View(new Outlet());
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Create", ex.ToString());
            throw;
        }
    }

    /// <summary>Creates a new outlet.</summary>
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Outlet model, List<ContactInputModel>? contacts, CancellationToken cancellationToken = default)
    {
        try
        {
            ModelState.Remove(nameof(Outlet.IsExportNavigation));

            if (ModelState.IsValid)
            {
                var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                var contactUserId = short.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                model.UserCreationId = userId;
                model.UserCreationDate = DateOnly.FromDateTime(DateTime.Now);
                model.UserDeletionId = null;
                model.UserDeletionDate = null;

                await using var transaction = await Db.Database.BeginTransactionAsync(cancellationToken);
                var sequenceValues = await Db.Database
                    .SqlQueryRaw<long>("SELECT NEXT VALUE FOR dbo.Outlet_SEQ AS value")
                    .ToListAsync(cancellationToken);
                model.Id = sequenceValues.Single();
                Db.Outlets.Add(model);

                if (!await ContactFormPersistence.SyncAsync(Db, model.Id, 12, contacts, contactUserId, ModelState, cancellationToken))
                {
                    await transaction.RollbackAsync(cancellationToken);
                    await PopulateDropdownsAsync(cancellationToken);
                    ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
                    return View(model);
                }

                await Db.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_SavedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Create", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
            ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
            ModelState.AddModelError(string.Empty, L["Common_ErrorOccurred"].Value);
            return View(model);
        }
    }

    /// <summary>Shows the edit form for an outlet.</summary>
    [HttpGet("Edit/{id:long}")]
    public async Task<IActionResult> Edit(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var outlet = await Db.Outlets
                .FirstOrDefaultAsync(o => o.Id == id && o.UserDeletionId == null, cancellationToken);

            if (outlet == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                return RedirectToAction(nameof(Index));
            }

            ViewData["PageHeading"] = L["DE_Outlets_Outlet_Edit"];
            ViewData["Culture"] = CurrentCulture;

            await PopulateDropdownsAsync(cancellationToken);

            // Fetch contacts separately
            var contacts = await Db.HagrContacts
                .Where(c => c.ContactOwnerId == id && c.OutlitAdmin == 12 && c.IsActive && c.UserDeletionId == null)
                .Select(c => new { c.Id, c.ContactTypeId, c.Value })
                .ToListAsync(cancellationToken);

            ViewBag.Contacts = contacts;

            return View(outlet);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Edit", ex.ToString());
            throw;
        }
    }

    /// <summary>Updates an existing outlet.</summary>
    [HttpPost("Edit/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, Outlet model, List<ContactInputModel>? contacts, CancellationToken cancellationToken = default)
    {
        try
        {
            ModelState.Remove(nameof(Outlet.IsExportNavigation));

            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existing = await Db.Outlets
                    .FirstOrDefaultAsync(o => o.Id == id && o.UserDeletionId == null, cancellationToken);

                if (existing == null)
                {
                    TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                    return RedirectToAction(nameof(Index));
                }

                var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                var contactUserId = short.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                // Update fields
                existing.ArName = model.ArName;
                existing.EnName = model.EnName;
                existing.AddressAr = model.AddressAr;
                existing.AddressEn = model.AddressEn;
                existing.GrAdminId = model.GrAdminId;
                existing.SupervisorId = model.SupervisorId;
                existing.IsActive = model.IsActive;
                existing.IsDisplay = model.IsDisplay;
                existing.IsExport = model.IsExport;
                existing.IdHr = model.IdHr;
                existing.PortNationalId = model.PortNationalId;
                existing.UserUpdationId = userId;
                existing.UserUpdationDate = DateOnly.FromDateTime(DateTime.Now);

                if (!await ContactFormPersistence.SyncAsync(Db, id, 12, contacts, contactUserId, ModelState, cancellationToken))
                {
                    await PopulateDropdownsAsync(cancellationToken);
                    ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
                    return View(model);
                }

                await Db.SaveChangesAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_UpdatedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Edit", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
            ViewBag.Contacts = (IEnumerable<ContactInputModel>?)contacts ?? Array.Empty<ContactInputModel>();
            ModelState.AddModelError(string.Empty, L["Common_ErrorOccurred"].Value);
            return View(model);
        }
    }

    /// <summary>Deletes an outlet (soft delete).</summary>
    [HttpPost("Delete/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var outlet = await Db.Outlets.FirstOrDefaultAsync(o => o.Id == id && o.UserDeletionId == null, cancellationToken);

            if (outlet != null)
            {
                var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                outlet.UserDeletionId = userId;
                outlet.UserDeletionDate = DateOnly.FromDateTime(DateTime.Now);

                await Db.SaveChangesAsync(cancellationToken);
                TempData["SuccessMessage"] = L["Common_DeletedSuccessfully"].Value;
            }
            else
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Delete", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            return RedirectToAction(nameof(Index));
        }
    }

    /// <summary>
    /// Paged search feed for the outlets list page (AJAX).
    /// Ported from the legacy <c>listOutlet</c> action, which called the
    /// <c>Outlet_API</c> list endpoint and returned a jTable-shaped envelope:
    /// <c>{ Result = "OK", Records, TotalRecordCount }</c>. The envelope shape is kept
    /// because the legacy list page's JavaScript reads those exact property names.
    /// </summary>
    /// <remarks>
    /// The legacy action took <c>jtStartIndex</c>/<c>jtPageSize</c>/<c>jtSorting</c> (jTable's
    /// naming) and forwarded them as <c>index</c>/<c>pageSize</c>/<c>jtSorting</c>. Those
    /// parameter names are preserved verbatim so a legacy caller keeps working.
    /// </remarks>
    [HttpPost("listOutlet")]
    public async Task<IActionResult> listOutlet(
        string txt_AR_BTNSearch = "",
        string txt_EN_BTNSearch = "",
        int jtStartIndex = 0,
        int jtPageSize = 0,
        string jtSorting = "",
        CancellationToken cancellationToken = default)
    {
        try
        {
            var (records, total) = await QueryOutletsAsync(
                txt_AR_BTNSearch, txt_EN_BTNSearch, jtStartIndex, jtPageSize, jtSorting, cancellationToken);

            return Json(new { Result = "OK", Records = records, TotalRecordCount = total });
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "listOutlet", ex.ToString());
            return Json(new { Result = "ERROR", Message = L["Common_ErrorOccurred"].Value });
        }
    }

    /// <summary>Every non-deleted outlet, for the list page's Excel export.</summary>
    [HttpGet("AllOutletExcell")]
    public async Task<IActionResult> AllOutletExcell(CancellationToken cancellationToken = default)
    {
        try
        {
            var (records, _) = await QueryOutletsAsync(string.Empty, string.Empty, 0, -1, string.Empty, cancellationToken);
            return Json(records);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "AllOutletExcell", ex.ToString());
            return Json(new { Result = "ERROR", Message = L["Common_ErrorOccurred"].Value });
        }
    }

    /// <summary>
    /// Saves the inline edit modal on the outlets list page (AJAX).
    /// Ported from the legacy <c>UpdateOutlet</c> action, which did a full <c>PUT</c>
    /// against <c>Outlet_API</c> and answered <c>{ Result = "OK" }</c>.
    /// </summary>
    /// <remarks>
    /// The modal edits the same fields the legacy DTO did (name, address, the three flags,
    /// plus the HR/port/admin references carried through untouched). Contacts are not part
    /// of the modal — they stay on the full Edit form — so <c>contacts</c> is not touched
    /// here, which is what the legacy page did too (the modal never posted a contacts list).
    /// </remarks>
    [HttpPost("UpdateOutlet")]
    public async Task<IActionResult> UpdateOutlet(OutletEditInputModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var details = string.Join("; ", ModelState
                    .Where(kv => kv.Value is { Errors.Count: > 0 })
                    .SelectMany(kv => kv.Value!.Errors.Select(e => kv.Key + ": " + e.ErrorMessage)));
                LogErrorToDb("Outlet", "UpdateOutlet", "ModelState invalid: " + details);
                return Json(new { Result = "ERROR", Message = L["Common_RequiredData"].Value });
            }

            var existing = await Db.Outlets
                .FirstOrDefaultAsync(o => o.Id == model.Id && o.UserDeletionId == null, cancellationToken);

            if (existing == null)
            {
                return Json(new { Result = "ERROR", Message = L["Common_NotFound"].Value });
            }

            var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            existing.ArName = model.ArName;
            existing.EnName = model.EnName;
            existing.AddressAr = model.AddressAr;
            existing.AddressEn = model.AddressEn;
            existing.SupervisorId = model.SupervisorId;
            existing.GrAdminId = model.GrAdminId;
            existing.IsExport = model.IsExport;
            existing.IdHr = model.IdHr;
            existing.PortNationalId = model.PortNationalId;
            existing.IsActive = model.IsActive;
            existing.IsDisplay = (byte)(model.IsDisplay ? 1 : 0);
            existing.CanAcceptPayment = model.CanAcceptPayment;
            existing.UserUpdationId = userId;
            existing.UserUpdationDate = DateOnly.FromDateTime(DateTime.Now);

            await Db.SaveChangesAsync(cancellationToken);

            return Json(new { Result = "OK" });
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "UpdateOutlet", ex.ToString());
            return Json(new { Result = "ERROR", Message = L["Common_ErrorOccurred"].Value });
        }
    }

    /// <summary>
    /// Shared filter/sort/page core for <c>listOutlet</c> and <c>AllOutletExcell</c>.
    /// A <paramref name="pageSize"/> of <c>-1</c> means "every row", matching the legacy
    /// <c>pageSize=-1&amp;index=-1</c> convention used by the Excel export.
    /// </summary>
    private async Task<(List<object> Records, int Total)> QueryOutletsAsync(
        string searchAr, string searchEn, int startIndex, int pageSize, string sorting,
        CancellationToken cancellationToken)
    {
        var query = Db.Outlets.Where(o => o.UserDeletionId == null);

        if (!string.IsNullOrWhiteSpace(searchAr))
            query = query.Where(o => o.ArName != null && o.ArName.Contains(searchAr));

        if (!string.IsNullOrWhiteSpace(searchEn))
            query = query.Where(o => o.EnName != null && o.EnName.Contains(searchEn));

        var total = await query.CountAsync(cancellationToken);

        // Only ArName/EnName are sortable from the page; anything else falls back to ArName.
        query = sorting.StartsWith("En_Name", StringComparison.OrdinalIgnoreCase)
            ? query.OrderBy(o => o.EnName)
            : query.OrderBy(o => o.ArName);

        if (pageSize > 0)
            query = query.Skip(Math.Max(0, startIndex)).Take(pageSize);

        var rows = await query
            .Select(o => new
            {
                o.Id,
                o.ArName,
                o.EnName,
                o.AddressAr,
                o.AddressEn,
                o.SupervisorId,
                o.GrAdminId,
                o.IsExport,
                o.IdHr,
                o.PortNationalId,
                o.IsActive,
                o.IsDisplay,
                o.CanAcceptPayment
            })
            .ToListAsync(cancellationToken);

        var records = rows
            .Select(o => (object)new
            {
                o.Id,
                o.ArName,
                o.EnName,
                o.AddressAr,
                o.AddressEn,
                o.SupervisorId,
                o.GrAdminId,
                o.IsExport,
                o.IdHr,
                o.PortNationalId,
                o.IsActive,
                o.IsDisplay,
                o.CanAcceptPayment
            })
            .ToList();

        return (records, total);
    }

    /// <summary>Gets contacts for an outlet (AJAX).</summary>
    [HttpGet("GetContacts/{outletId:long}")]
    public async Task<IActionResult> GetContacts(long outletId, CancellationToken cancellationToken = default)
    {
        try
        {
            var contacts = await Db.HagrContacts
                .Where(c => c.ContactOwnerId == outletId && c.OutlitAdmin == 12 && c.IsActive && c.UserDeletionId == null)
                .Select(c => new { c.Id, c.ContactTypeId, c.Value, ContactTypeName = c.ContactType != null ? c.ContactType.NameAr : string.Empty })
                .ToListAsync(cancellationToken);

            return Json(contacts);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "GetContacts", ex.ToString());
            return Json(new { error = ex.Message });
        }
    }

    private async Task PopulateDropdownsAsync(CancellationToken cancellationToken = default)
    {
        ViewBag.GeneralAdmins = await Db.GeneralAdmins
            .Where(g => g.IsActive && g.UserDeletionId == null)
            .Select(g => new SelectOption { Value = g.Id.ToString(), TextAr = g.ArName, TextEn = g.EnName })
            .ToListAsync(cancellationToken);

        ViewBag.ContactTypes = await Db.ContactTypes
            .Where(c => c.IsActive)
            .Select(c => new SelectOption { Value = c.Id.ToString(), TextAr = c.NameAr, TextEn = c.NameEn })
            .ToListAsync(cancellationToken);

        ViewBag.PortTypes = await Db.ASystemCodes
            .Where(s => s.SystemCodeTypeId == 21 && s.IsActive)
            .Select(s => new SelectOption { Value = s.Id.ToString(), TextAr = s.ValueName, TextEn = s.ValueNameEn })
            .ToListAsync(cancellationToken);
    }
}
