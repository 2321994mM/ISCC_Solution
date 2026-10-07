using ISCC.Infrastructure.Data.Generated;
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

    /// <summary>The portal's search form for outlets.</summary>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        string? searchAr = null,
        string? searchEn = null,
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

            // Get General Admin dropdown for filter
            var generalAdmins = await Db.GeneralAdmins
                .Where(g => g.IsActive && g.UserDeletionId == null)
                .Select(g => new SelectOption { Value = g.Id.ToString(), TextAr = g.ArName, TextEn = g.EnName })
                .ToListAsync(cancellationToken);

            ViewBag.GeneralAdmins = generalAdmins;

            // If search parameters provided, redirect to List action
            if (!string.IsNullOrWhiteSpace(searchAr) || !string.IsNullOrWhiteSpace(searchEn))
            {
                return RedirectToAction(nameof(List), new { searchAr, searchEn, page, pageSize });
            }

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
    public async Task<IActionResult> Create(Outlet model, CancellationToken cancellationToken = default)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userId = long.Parse(User.FindFirstValue("UserId") ?? "0");

                model.UserCreationId = userId;
                model.UserCreationDate = DateOnly.FromDateTime(DateTime.Now);
                model.UserDeletionId = null;
                model.UserDeletionDate = null;

                Db.Outlets.Add(model);
                await Db.SaveChangesAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_SavedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Create", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
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
    public async Task<IActionResult> Edit(long id, Outlet model, CancellationToken cancellationToken = default)
    {
        try
        {
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

                var userId = long.Parse(User.FindFirstValue("UserId") ?? "0");

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

                // Handle contacts (simplified - in real app would need proper child collection handling)
                // For now, we'll just update the main entity

                await Db.SaveChangesAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_UpdatedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Outlet", "Edit", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
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
                var userId = long.Parse(User.FindFirstValue("UserId") ?? "0");

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