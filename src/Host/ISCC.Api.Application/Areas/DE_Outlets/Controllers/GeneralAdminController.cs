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
/// "الإدارة العامة" (menu item): search form and paged results list for general administrations.
/// </summary>
/// <remarks>
/// Ported from the legacy Capqwebsite/Areas/DE_Outlets/Controllers/GeneralAdminController.
/// The route template below matches the menu URL for "الإدارة العامة" (DE_Outlets/GeneralAdmin/Index).
/// </remarks>
[Area("DE_Outlets")]
[Authorize]
[Route("DE_Outlets/GeneralAdmin")]
public class GeneralAdminController : BaseController
{
    public GeneralAdminController(IStringLocalizer<SharedResource> localizer) : base(localizer) { }

    /// <summary>The portal's search form for general administrations.</summary>
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
            ViewData["PageHeading"] = L["DE_Outlets_GeneralAdmin_Title"];
            ViewData["Culture"] = CurrentCulture;

            ViewBag.SearchAr = searchAr ?? string.Empty;
            ViewBag.SearchEn = searchEn ?? string.Empty;

            // If search parameters provided, redirect to List action
            if (!string.IsNullOrWhiteSpace(searchAr) || !string.IsNullOrWhiteSpace(searchEn))
            {
                return RedirectToAction(nameof(List), new { searchAr, searchEn, page, pageSize });
            }

            return View();
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "Index", ex.ToString());
            throw;
        }
    }

    /// <summary>Runs the search and renders the paged results table.</summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(
        string? searchAr = null,
        string? searchEn = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["DE_Outlets_GeneralAdmin_Title"];
            ViewData["Culture"] = CurrentCulture;

            ViewBag.SearchAr = searchAr ?? string.Empty;
            ViewBag.SearchEn = searchEn ?? string.Empty;

            var query = Db.GeneralAdmins
                .Where(g => g.UserDeletionId == null)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchAr))
                query = query.Where(g => g.ArName != null && g.ArName.Contains(searchAr));

            if (!string.IsNullOrWhiteSpace(searchEn))
                query = query.Where(g => g.EnName != null && g.EnName.Contains(searchEn));

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(g => g.ArName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(g => new
                {
                    g.Id,
                    g.ArName,
                    g.EnName,
                    g.AddressAr,
                    g.AddressEn,
                    g.IsActive,
                    g.AdminId,
                    ContactCount = g.HagrContacts.Count(hc => hc.OutlitAdmin == 13 && hc.IsActive && hc.UserDeletionId == null)
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
            LogErrorToDb("GeneralAdmin", "List", ex.ToString());
            throw;
        }
    }

    /// <summary>Shows the create/edit form for a general administration.</summary>
    [HttpGet("Create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        try
        {
            ViewData["PageHeading"] = L["DE_Outlets_GeneralAdmin_Create"];
            ViewData["Culture"] = CurrentCulture;

            await PopulateDropdownsAsync(cancellationToken);
            return View(new GeneralAdmin());
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "Create", ex.ToString());
            throw;
        }
    }

    /// <summary>Creates a new general administration.</summary>
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GeneralAdmin model, CancellationToken cancellationToken = default)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userId = short.Parse(User.FindFirstValue("UserId") ?? "0");

                model.UserCreationId = userId;
                model.UserCreationDate = DateTime.Now;
                model.UserDeletionId = null;
                model.UserDeletionDate = null;

                Db.GeneralAdmins.Add(model);
                await Db.SaveChangesAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_SavedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "Create", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
            ModelState.AddModelError(string.Empty, L["Common_ErrorOccurred"].Value);
            return View(model);
        }
    }

    /// <summary>Shows the edit form for a general administration.</summary>
    [HttpGet("Edit/{id:byte}")]
    public async Task<IActionResult> Edit(byte id, CancellationToken cancellationToken = default)
    {
        try
        {
            var admin = await Db.GeneralAdmins
                .FirstOrDefaultAsync(g => g.Id == id && g.UserDeletionId == null, cancellationToken);

            if (admin == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                return RedirectToAction(nameof(Index));
            }

            ViewData["PageHeading"] = L["DE_Outlets_GeneralAdmin_Edit"];
            ViewData["Culture"] = CurrentCulture;

            await PopulateDropdownsAsync(cancellationToken);

            // Fetch contacts separately
            var contacts = await Db.HagrContacts
                .Where(c => c.ContactOwnerId == id && c.OutlitAdmin == 13 && c.IsActive && c.UserDeletionId == null)
                .Select(c => new { c.Id, c.ContactTypeId, c.Value })
                .ToListAsync(cancellationToken);

            ViewBag.Contacts = contacts;

            return View(admin);
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "Edit", ex.ToString());
            throw;
        }
    }

    /// <summary>Updates an existing general administration.</summary>
    [HttpPost("Edit/{id:byte}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte id, GeneralAdmin model, CancellationToken cancellationToken = default)
    {
        try
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existing = await Db.GeneralAdmins
                    .Include(g => g.HagrContacts)
                    .FirstOrDefaultAsync(g => g.Id == id && g.UserDeletionId == null, cancellationToken);

                if (existing == null)
                {
                    TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                    return RedirectToAction(nameof(Index));
                }

                var userId = short.Parse(User.FindFirstValue("UserId") ?? "0");

                existing.ArName = model.ArName;
                existing.EnName = model.EnName;
                existing.AddressAr = model.AddressAr;
                existing.AddressEn = model.AddressEn;
                existing.AdminId = model.AdminId;
                existing.IsActive = model.IsActive;
                existing.UserUpdationId = userId;
                existing.UserUpdationDate = DateTime.Now;

                await Db.SaveChangesAsync(cancellationToken);

                TempData["SuccessMessage"] = L["Common_UpdatedSuccessfully"].Value;
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(cancellationToken);
            return View(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "Edit", ex.ToString());
            await PopulateDropdownsAsync(cancellationToken);
            ModelState.AddModelError(string.Empty, L["Common_ErrorOccurred"].Value);
            return View(model);
        }
    }

    /// <summary>Deletes a general administration (soft delete).</summary>
    [HttpPost("Delete/{id:byte}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(byte id, CancellationToken cancellationToken = default)
    {
        try
        {
            var admin = await Db.GeneralAdmins.FirstOrDefaultAsync(g => g.Id == id && g.UserDeletionId == null, cancellationToken);

            if (admin != null)
            {
                var userId = short.Parse(User.FindFirstValue("UserId") ?? "0");

                admin.UserDeletionId = userId;
                admin.UserDeletionDate = DateTime.Now;

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
            LogErrorToDb("GeneralAdmin", "Delete", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            return RedirectToAction(nameof(Index));
        }
    }

    /// <summary>Gets contacts for a general administration (AJAX).</summary>
    [HttpGet("GetContacts/{adminId:long}")]
    public async Task<IActionResult> GetContacts(long adminId, CancellationToken cancellationToken = default)
    {
        try
        {
            var contacts = await Db.HagrContacts
                .Where(c => c.ContactOwnerId == adminId && c.OutlitAdmin == 13 && c.IsActive && c.UserDeletionId == null)
                .Select(c => new { c.Id, c.ContactTypeId, c.Value, ContactTypeName = c.ContactType != null ? c.ContactType.NameAr : string.Empty })
                .ToListAsync(cancellationToken);

            return Json(contacts);
        }
        catch (Exception ex)
        {
            LogErrorToDb("GeneralAdmin", "GetContacts", ex.ToString());
            return Json(new { error = ex.Message });
        }
    }

    private async Task PopulateDropdownsAsync(CancellationToken cancellationToken = default)
    {
        ViewBag.ContactTypes = await Db.ContactTypes
            .Where(c => c.IsActive)
            .Select(c => new SelectOption { Value = c.Id.ToString(), TextAr = c.NameAr, TextEn = c.NameEn })
            .ToListAsync(cancellationToken);
    }
}