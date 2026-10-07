using ISCC.Infrastructure.Data.Generated;
using ISCC.Shared.Contracts;
using ISCC.Shared.Localization;
using ISCC.Shared.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ISCC.Api.Application.Areas.DE_Item_Data.Controllers;

/// <summary>
/// "كائنات حية وغير حية" (menu URL DE_Item_Data/Item/Index): search form, paged list,
/// create/edit with the full classification cascade, soft delete, plant-part CRUD, the
/// Excel export feed and picture download.
/// </summary>
/// <remarks>
/// <para>
/// Ported from PlantQuar.WEB Areas/DE_Item_Data (ItemController + the jtable Index.cshtml).
/// There is no jtable here: the grid is server-rendered, following the DE_Outlets port.
/// </para>
/// <para>Deliberate deviations from the legacy code:</para>
/// <list type="bullet">
/// <item>The classification cascade (type - main - sec - group and kingdom - phylum - order -
/// family) is visible on BOTH create and edit. The legacy create form hid those eight
/// selects and took ItemTypeId/GroupId/FamilyId from the filter bar. Only those three are
/// stored on Item; the intermediate levels are navigation only and are not saved.</item>
/// <item>The list filter ANDs only the values the user actually picked. The legacy SQL
/// compared all three (type, family, group) including nulls, so picking a single filter
/// returned only items whose other two columns were exactly null.</item>
/// <item>Classification columns are LEFT-joined for display; the legacy INNER joins through
/// group and family silently hid items with a missing classification.</item>
/// <item>Display/filter type comes from Item.ItemTypeId itself; the legacy list derived the
/// type from the group's classification chain.</item>
/// <item>Sorting is NameAr then Id; the legacy jtSorting switch ran after the page slice,
/// so it effectively sorted one page at a time.</item>
/// </list>
/// <para>Legacy quirks kept: ItemType Id 2 is excluded from the type dropdowns (Edit GET is
/// the one exception - it keeps the item's own type so saving cannot orphan it), ItemCode
/// is at most 3 characters, ForbiddenReason is required while IsForbidden, a duplicate
/// NameAr/NameEn inside the same item type is rejected, audit fields come from the UserId
/// claim, and deletion is soft (UserDeletionId/UserDeletionDate).</para>
/// </remarks>
[Area("DE_Item_Data")]
[Authorize]
[Route("DE_Item_Data/Item")]
public class ItemController : BaseController
{
    private readonly IWebHostEnvironment _env;

    public ItemController(IStringLocalizer<SharedResource> localizer, IWebHostEnvironment env)
        : base(localizer)
    {
        _env = env;
    }

    // ---------------------------------------------------------------- search form

    /// <summary>Landing page: the search form only (results live on <see cref="List"/>).</summary>
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        string? searchAr = null, string? searchEn = null,
        byte? itemTypeId = null, int? groupId = null, int? familyId = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(searchAr, searchEn, itemTypeId, groupId, familyId);
        try
        {
            await LoadSearchDropdownsAsync();
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Index", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return View();
    }

    /// <summary>Server-rendered result list with a pager.</summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(
        string? searchAr = null, string? searchEn = null,
        byte? itemTypeId = null, int? groupId = null, int? familyId = null,
        int page = 1, int pageSize = 10)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(searchAr, searchEn, itemTypeId, groupId, familyId);

        // Defaults first, so an exception below cannot leave the view casting nulls.
        ViewBag.Items = Array.Empty<object>();
        ViewBag.TotalCount = 0;
        ViewBag.PageNumber = 1;
        ViewBag.TotalPages = 1;
        ViewBag.PageSize = pageSize;

        try
        {
            await LoadSearchDropdownsAsync();

            var query = BuildFilterQuery(searchAr, searchEn, itemTypeId, groupId, familyId);

            var totalCount = await query.CountAsync();
            if (page < 1) page = 1;
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)pageSize));
            if (page > totalPages) page = totalPages;

            var culture = CurrentCulture;
            var items = await query
                .OrderBy(i => i.NameAr).ThenBy(i => i.Id)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Select(i => new
                {
                    i.Id,
                    i.NameAr,
                    i.NameEn,
                    i.ScientificName,
                    i.ItemCode,
                    i.Picture,
                    i.IsForbidden,
                    i.IsKnownItem,
                    i.IsPlantInEgypt,
                    i.Agriculture17,
                    i.ItemTypeId,
                    // Item has no navigation property to ItemType, hence the correlated subquery.
                    ItemTypeName = Db.ItemTypes
                        .Where(t => t.Id == i.ItemTypeId)
                        .Select(t => culture == "ar" ? t.NameAr : t.NameEn)
                        .FirstOrDefault(),
                    // LEFT joins through the chain: an item with a missing classification
                    // still shows up (with a dash) instead of disappearing.
                    MainClassName = i.Group != null && i.Group.SecClass != null && i.Group.SecClass.MainClass != null
                        ? (culture == "ar" ? i.Group.SecClass.MainClass.NameAr : i.Group.SecClass.MainClass.NameEn)
                        : null,
                    GroupName = i.Group != null
                        ? (culture == "ar" ? i.Group.NameAr : i.Group.NameEn)
                        : null,
                    FamilyName = i.Family != null
                        ? (culture == "ar" ? i.Family.NameAr : i.Family.NameEn)
                        : null,
                    PartsCount = i.ItemParts.Count(p => p.UserDeletionId == null)
                })
                .ToListAsync();

            ViewBag.Items = items;
            ViewBag.TotalCount = totalCount;
            ViewBag.PageNumber = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "List", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return View();
    }

    // ---------------------------------------------------------------- create

    [HttpGet("Create")]
    public async Task<IActionResult> Create(
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(fAr, fEn, fType, fGroup, fFamily);
        var model = new Item
        {
            // Legacy defaults on the create form.
            IsForbidden = true,
            IsPlantInEgypt = true,
            IsKnownItem = false
        };
        try
        {
            await LoadCascadeAsync(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Create", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return View(model);
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        Item model,
        IFormFile? Picture1,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(fAr, fEn, fType, fGroup, fFamily);

        try
        {
            model.NameAr = model.NameAr?.Trim();
            model.NameEn = model.NameEn?.Trim();
            ValidateItem(model);

            if (ModelState.IsValid)
            {
                if (await IsDuplicateAsync(model, excludeId: null))
                {
                    ModelState.AddModelError(string.Empty, L["Common_DuplicateData"].Value);
                }
            }

            if (Picture1 != null && !IsImageFile(Picture1))
            {
                ModelState.AddModelError(string.Empty, L["DE_Item_Data_Item_InvalidImage"].Value);
            }

            if (ModelState.IsValid)
            {
                if (Picture1 != null)
                {
                    model.Picture = await SavePictureAsync(Picture1);
                }

                model.UserCreationId = GetUserId();
                model.UserCreationDate = DateTime.Now;
                model.UserDeletionId = null;
                model.UserDeletionDate = null;
                model.UserUpdationId = null;
                model.UserUpdationDate = null;
                model.IsKnownItem = model.IsKnownItem ?? false;

                Db.Items.Add(model);
                await Db.SaveChangesAsync();

                TempData["SuccessMessage"] = L["Common_SavedSuccessfully"].Value;
                return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
            }

            await LoadCascadeAsync(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Create", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            try { await LoadCascadeAsync(model); } catch { /* the form still renders with empty lists */ }
        }
        return View(model);
    }

    // ---------------------------------------------------------------- edit

    [HttpGet("Edit/{id:long}")]
    public async Task<IActionResult> Edit(
        long id,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(fAr, fEn, fType, fGroup, fFamily);
        try
        {
            var item = await Db.Items.FirstOrDefaultAsync(i => i.Id == id && i.UserDeletionId == null);
            if (item == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
            }

            await LoadCascadeAsync(item);
            ViewBag.HasPicture = !string.IsNullOrEmpty(item.Picture);
            return View(item);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Edit", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
        }
    }

    [HttpPost("Edit/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        Item model,
        IFormFile? Picture1,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(fAr, fEn, fType, fGroup, fFamily);

        if (id != model.Id)
        {
            return BadRequest();
        }

        try
        {
            var item = await Db.Items.FirstOrDefaultAsync(i => i.Id == id && i.UserDeletionId == null);
            if (item == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
            }

            model.NameAr = model.NameAr?.Trim();
            model.NameEn = model.NameEn?.Trim();
            ValidateItem(model);

            if (ModelState.IsValid && await IsDuplicateAsync(model, excludeId: id))
            {
                ModelState.AddModelError(string.Empty, L["Common_DuplicateData"].Value);
            }

            if (Picture1 != null && !IsImageFile(Picture1))
            {
                ModelState.AddModelError(string.Empty, L["DE_Item_Data_Item_InvalidImage"].Value);
            }

            if (ModelState.IsValid)
            {
                item.NameAr = model.NameAr;
                item.NameEn = model.NameEn;
                item.ScientificName = model.ScientificName?.Trim();
                item.DescreptionAr = model.DescreptionAr?.Trim();
                item.DescreptionEn = model.DescreptionEn?.Trim();
                item.ItemTypeId = model.ItemTypeId;
                item.GroupId = model.GroupId;
                item.FamilyId = model.FamilyId;
                item.IsKnownItem = model.IsKnownItem;
                item.IsPlantInEgypt = model.IsPlantInEgypt;
                item.ItemCode = model.ItemCode?.Trim();
                item.Agriculture17 = model.Agriculture17;
                item.IsForbidden = model.IsForbidden;
                item.ForbiddenReason = model.ForbiddenReason?.Trim();

                if (Picture1 != null)
                {
                    item.Picture = await SavePictureAsync(Picture1);
                }

                item.UserUpdationId = GetUserId();
                item.UserUpdationDate = DateTime.Now;
                await Db.SaveChangesAsync();

                TempData["SuccessMessage"] = L["Common_UpdatedSuccessfully"].Value;
                return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
            }

            ViewBag.HasPicture = !string.IsNullOrEmpty(item.Picture);
            await LoadCascadeAsync(model);
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Edit", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            try { await LoadCascadeAsync(model); } catch { /* the form still renders with empty lists */ }
        }
        return View(model);
    }

    // ---------------------------------------------------------------- delete

    [HttpPost("Delete/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(
        long id,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        try
        {
            var item = await Db.Items.FirstOrDefaultAsync(i => i.Id == id && i.UserDeletionId == null);
            if (item == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
            }
            else
            {
                item.UserDeletionId = GetUserId();
                item.UserDeletionDate = DateTime.Now;
                await Db.SaveChangesAsync();
                TempData["SuccessMessage"] = L["Common_DeletedSuccessfully"].Value;
            }
        }
        catch (DbUpdateException ex)
        {
            LogErrorToDb("Item", "Delete", ex.ToString());
            TempData["ErrorMessage"] = L["Common_RelatedData"].Value;
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Delete", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
    }

    // ---------------------------------------------------------------- plant parts

    /// <summary>
    /// Item info + its plant parts + the add/edit part form. With <c>partId</c> the form
    /// is in edit mode; otherwise it adds.
    /// </summary>
    [HttpGet("Parts/{itemId:long}")]
    public async Task<IActionResult> Parts(
        long itemId,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null,
        int? partId = null)
    {
        ViewData["Culture"] = CurrentCulture;
        SetFilterBag(fAr, fEn, fType, fGroup, fFamily);
        try
        {
            var item = await Db.Items.FirstOrDefaultAsync(i => i.Id == itemId && i.UserDeletionId == null);
            if (item == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
                return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
            }

            var culture = CurrentCulture;

            ViewBag.ItemInfo = new { item.Id, item.NameAr, item.NameEn, item.ItemTypeId };

            ViewBag.Parts = await Db.ItemParts
                .Where(p => p.ItemId == itemId && p.UserDeletionId == null)
                .OrderBy(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    p.SubPartId,
                    p.IsAllowed,
                    SubPartName = culture == "ar" ? p.SubPart.NameAr : p.SubPart.NameEn,
                    SubPartTypeName = p.SubPart.SubPartType != null
                        ? (culture == "ar" ? p.SubPart.SubPartType.NameAr : p.SubPart.SubPartType.NameEn)
                        : null
                })
                .ToListAsync();

            ViewBag.PartTypes = await Db.SubPartTypes
                .Where(t => t.IsActive && t.UserDeletionId == null)
                .OrderBy(t => t.NameAr)
                .Select(t => new SelectOption { Value = t.Id.ToString(), TextAr = t.NameAr, TextEn = t.NameEn })
                .ToListAsync();

            // Add or edit form state.
            long? editPartId = null;
            int? editSubPartId = null;
            int? editSubPartTypeId = null;
            bool editAllowed = true; // the legacy form defaulted the "allowed" flag to checked

            if (partId.HasValue)
            {
                var part = await Db.ItemParts
                    .FirstOrDefaultAsync(p => p.Id == partId && p.ItemId == itemId && p.UserDeletionId == null);
                if (part != null)
                {
                    editPartId = part.Id;
                    editSubPartId = part.SubPartId;
                    editAllowed = part.IsAllowed;
                    editSubPartTypeId = await Db.SubParts
                        .Where(s => s.Id == part.SubPartId)
                        .Select(s => s.SubPartTypeId)
                        .FirstOrDefaultAsync();
                }
            }

            ViewBag.EditPartId = editPartId;
            ViewBag.EditSubPartTypeId = editSubPartTypeId?.ToString();
            ViewBag.EditSubPartId = editSubPartId?.ToString();
            ViewBag.EditAllowed = editAllowed;

            // Sub-parts of this item's type (plus the current one, so a mismatched stored
            // chain still shows the selected value instead of silently falling back).
            var typeFilter = item.ItemTypeId;
            ViewBag.SubParts = await Db.SubParts
                .Where(s => s.UserDeletionId == null
                    && (typeFilter == null || s.ItemTypeId == null || s.ItemTypeId == typeFilter)
                    && ((editSubPartTypeId.HasValue && s.SubPartTypeId == editSubPartTypeId)
                        || (editSubPartId.HasValue && s.Id == editSubPartId)))
                .OrderBy(s => s.NameAr)
                .Select(s => new SelectListItem
                {
                    Text = culture == "ar" ? s.NameAr : s.NameEn,
                    Value = s.Id.ToString()
                })
                .ToListAsync();

            return View();
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "Parts", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
            return RedirectToAction(nameof(List), FilterRoute(fAr, fEn, fType, fGroup, fFamily));
        }
    }

    [HttpPost("AddPart/{itemId:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPart(
        long itemId,
        int? subPartTypeId,
        int? subPartId,
        bool? isAllowed,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        try
        {
            if (!subPartId.HasValue)
            {
                TempData["ErrorMessage"] = L["Common_RequiredData"].Value;
            }
            else if (await Db.ItemParts.AnyAsync(p => p.ItemId == itemId && p.SubPartId == subPartId && p.UserDeletionId == null))
            {
                TempData["ErrorMessage"] = L["Common_DuplicateData"].Value;
            }
            else
            {
                Db.ItemParts.Add(new ItemPart
                {
                    ItemId = itemId,
                    SubPartId = subPartId.Value,
                    IsAllowed = isAllowed ?? false,
                    UserCreationId = GetUserId(),
                    UserCreationDate = DateTime.Now
                });
                await Db.SaveChangesAsync();
                TempData["SuccessMessage"] = L["Common_SavedSuccessfully"].Value;
            }
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "AddPart", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return RedirectToAction(nameof(Parts), new { itemId, fAr, fEn, fType, fGroup, fFamily });
    }

    [HttpPost("EditPart/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPart(
        long id,
        long itemId,
        int? subPartTypeId,
        int? subPartId,
        bool? isAllowed,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        try
        {
            var part = await Db.ItemParts
                .FirstOrDefaultAsync(p => p.Id == id && p.ItemId == itemId && p.UserDeletionId == null);
            if (part == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
            }
            else if (!subPartId.HasValue)
            {
                TempData["ErrorMessage"] = L["Common_RequiredData"].Value;
            }
            else if (await Db.ItemParts.AnyAsync(p => p.ItemId == itemId && p.SubPartId == subPartId && p.UserDeletionId == null && p.Id != id))
            {
                TempData["ErrorMessage"] = L["Common_DuplicateData"].Value;
            }
            else
            {
                part.SubPartId = subPartId.Value;
                part.IsAllowed = isAllowed ?? false;
                part.UserUpdationId = GetUserId();
                part.UserUpdationDate = DateTime.Now;
                await Db.SaveChangesAsync();
                TempData["SuccessMessage"] = L["Common_UpdatedSuccessfully"].Value;
            }
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "EditPart", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return RedirectToAction(nameof(Parts), new { itemId, fAr, fEn, fType, fGroup, fFamily });
    }

    [HttpPost("DeletePart/{id:long}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePart(
        long id,
        long itemId,
        string? fAr = null, string? fEn = null,
        byte? fType = null, int? fGroup = null, int? fFamily = null)
    {
        try
        {
            var part = await Db.ItemParts
                .FirstOrDefaultAsync(p => p.Id == id && p.ItemId == itemId && p.UserDeletionId == null);
            if (part == null)
            {
                TempData["ErrorMessage"] = L["Common_NotFound"].Value;
            }
            else
            {
                part.UserDeletionId = GetUserId();
                part.UserDeletionDate = DateTime.Now;
                await Db.SaveChangesAsync();
                TempData["SuccessMessage"] = L["Common_DeletedSuccessfully"].Value;
            }
        }
        catch (DbUpdateException ex)
        {
            LogErrorToDb("Item", "DeletePart", ex.ToString());
            TempData["ErrorMessage"] = L["Common_RelatedData"].Value;
        }
        catch (Exception ex)
        {
            LogErrorToDb("Item", "DeletePart", ex.ToString());
            TempData["ErrorMessage"] = L["Common_ErrorOccurred"].Value;
        }
        return RedirectToAction(nameof(Parts), new { itemId, fAr, fEn, fType, fGroup, fFamily });
    }

    // ---------------------------------------------------------------- Excel export feed

    /// <summary>
    /// JSON behind the same filter as the list; the page turns it into a hidden table and
    /// downloads it through the legacy btoa Excel trick.
    /// </summary>
    [HttpGet("AllItem")]
    public async Task<IActionResult> AllItem(
        string? searchAr = null, string? searchEn = null,
        byte? itemTypeId = null, int? groupId = null, int? familyId = null)
    {
        var culture = CurrentCulture;
        var query = BuildFilterQuery(searchAr, searchEn, itemTypeId, groupId, familyId);

        var data = await query
            .OrderBy(i => i.NameAr).ThenBy(i => i.Id)
            .Select(i => new
            {
                itemType = Db.ItemTypes
                    .Where(t => t.Id == i.ItemTypeId)
                    .Select(t => culture == "ar" ? t.NameAr : t.NameEn)
                    .FirstOrDefault(),
                mainClass = i.Group != null && i.Group.SecClass != null && i.Group.SecClass.MainClass != null
                    ? (culture == "ar" ? i.Group.SecClass.MainClass.NameAr : i.Group.SecClass.MainClass.NameEn)
                    : null,
                group = i.Group != null ? (culture == "ar" ? i.Group.NameAr : i.Group.NameEn) : null,
                family = i.Family != null ? (culture == "ar" ? i.Family.NameAr : i.Family.NameEn) : null,
                nameAr = i.NameAr,
                nameEn = i.NameEn,
                scientificName = i.ScientificName,
                itemCode = i.ItemCode,
                picture = i.Picture,
                plantInEgypt = i.IsPlantInEgypt,
                forbiddenReason = i.ForbiddenReason,
                plantParts = i.ItemParts
                    .Where(p => p.UserDeletionId == null)
                    .Select(p => culture == "ar" ? p.SubPart.NameAr : p.SubPart.NameEn)
                    .ToList()
            })
            .ToListAsync();

        return Json(data);
    }

    // ---------------------------------------------------------------- pictures

    /// <summary>
    /// Streams an item picture. Stored paths come in three shapes: absolute http(s) (redirect),
    /// UNC <c>//server/share/...</c> (converted to <c>\\server\share</c> and served as a file),
    /// or a web-relative path such as <c>/img/Item/x.jpg</c> inside this host's wwwroot.
    /// </summary>
    [HttpGet("GetImage")]
    public IActionResult GetImage(string? path1)
    {
        if (string.IsNullOrWhiteSpace(path1))
        {
            return NotFound();
        }

        var path = path1.Trim();

        if (path.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            || path.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return Redirect(path);
        }

        // UNC //server/share/... or \\server\share\...
        if (path.StartsWith("//", StringComparison.Ordinal) || path.StartsWith("\\\\", StringComparison.Ordinal))
        {
            var unc = path.StartsWith("//", StringComparison.Ordinal)
                ? "\\" + path.Replace('/', '\\')
                : path;
            if (!System.IO.File.Exists(unc))
            {
                return NotFound();
            }
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(unc, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return PhysicalFile(unc, contentType);
        }

        // Web-relative: resolve under wwwroot with a traversal guard.
        var webRoot = _env.WebRootPath;
        if (string.IsNullOrEmpty(webRoot))
        {
            return NotFound();
        }

        var relative = path.TrimStart('/', '\\').Replace('\\', '/');
        var fullPath = Path.GetFullPath(Path.Combine(webRoot, relative));
        if (!fullPath.StartsWith(Path.GetFullPath(webRoot), StringComparison.OrdinalIgnoreCase))
        {
            return NotFound();
        }

        if (!System.IO.File.Exists(fullPath))
        {
            return NotFound();
        }

        var mime = new FileExtensionContentTypeProvider();
        if (!mime.TryGetContentType(fullPath, out var type))
        {
            type = "application/octet-stream";
        }
        return PhysicalFile(fullPath, type);
    }

    // ---------------------------------------------------------------- JSON option endpoints
    //
    // All of them return a bare [{ id, text }] array (the shape iscc-components.js accepts).
    // With no parent and no search term they return an empty array, which is exactly what
    // the cascade needs before the user picks the parent level.

    [HttpGet("MainClassOptions")]
    public async Task<IActionResult> MainClassOptions(byte? itemTypeId, string? term)
    {
        var query = Db.MainCalssifications.Where(m => m.UserDeletionId == null);
        if (itemTypeId.HasValue)
        {
            query = query.Where(m => m.ItemTypeId == itemTypeId);
        }
        else if (string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        return await CompleteOptionsAsync(query, m => m.Id, m => m.NameAr, m => m.NameEn, term);
    }

    [HttpGet("SecClassOptions")]
    public async Task<IActionResult> SecClassOptions(int? mainClassId, string? term)
    {
        if (!mainClassId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.SecondaryClassifications.Where(s => s.UserDeletionId == null);
        if (mainClassId.HasValue)
        {
            query = query.Where(s => s.MainClassId == mainClassId);
        }
        return await CompleteOptionsAsync(query, s => s.Id, s => s.NameAr, s => s.NameEn, term);
    }

    [HttpGet("GroupOptions")]
    public async Task<IActionResult> GroupOptions(int? secClassId, string? term)
    {
        if (!secClassId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.Groups.Where(g => g.UserDeletionId == null);
        if (secClassId.HasValue)
        {
            query = query.Where(g => g.SecClassId == secClassId);
        }
        return await CompleteOptionsAsync(query, g => g.Id, g => g.NameAr, g => g.NameEn, term);
    }

    [HttpGet("PhylumOptions")]
    public async Task<IActionResult> PhylumOptions(int? kingdomId, string? term)
    {
        if (!kingdomId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.PhylumSubphylums.Where(p => p.UserDeletionId == null);
        if (kingdomId.HasValue)
        {
            query = query.Where(p => p.KingdomId == kingdomId);
        }
        return await CompleteOptionsAsync(query, p => p.Id, p => p.NameAr, p => p.NameEn, term);
    }

    [HttpGet("OrderOptions")]
    public async Task<IActionResult> OrderOptions(int? phylumId, string? term)
    {
        if (!phylumId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.Orders.Where(o => o.UserDeletionId == null);
        if (phylumId.HasValue)
        {
            query = query.Where(o => o.PhylumId == phylumId);
        }
        return await CompleteOptionsAsync(query, o => o.Id, o => o.NameAr, o => o.NameEn, term);
    }

    [HttpGet("FamilyOptions")]
    public async Task<IActionResult> FamilyOptions(int? orderId, string? term)
    {
        if (!orderId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.Families.Where(f => f.UserDeletionId == null);
        if (orderId.HasValue)
        {
            query = query.Where(f => f.OrderId == orderId);
        }
        return await CompleteOptionsAsync(query, f => f.Id, f => f.NameAr, f => f.NameEn, term);
    }

    [HttpGet("SubPartOptions")]
    public async Task<IActionResult> SubPartOptions(byte? itemTypeId, int? subPartTypeId, string? term)
    {
        if (!subPartTypeId.HasValue && string.IsNullOrWhiteSpace(term))
        {
            return Json(Array.Empty<object>());
        }
        var query = Db.SubParts.Where(s => s.UserDeletionId == null);
        if (itemTypeId.HasValue)
        {
            // Sub-parts without a type are universal, so they stay available to every type.
            query = query.Where(s => s.ItemTypeId == null || s.ItemTypeId == itemTypeId);
        }
        if (subPartTypeId.HasValue)
        {
            query = query.Where(s => s.SubPartTypeId == subPartTypeId);
        }
        return await CompleteOptionsAsync(query, s => s.Id, s => s.NameAr, s => s.NameEn, term);
    }

    /// <summary>
    /// Applies the current-culture name filter (if any) and projects to [{ id, text }],
    /// capped so a stray broad search cannot stream an unbounded list to the browser.
    /// </summary>
    private async Task<IActionResult> CompleteOptionsAsync<T>(
        IQueryable<T> query,
        Expression<Func<T, int>> idSelector,
        Expression<Func<T, string?>> nameArSelector,
        Expression<Func<T, string?>> nameEnSelector,
        string? term)
    {
        var culture = CurrentCulture;
        var name = culture == "ar" ? nameArSelector : nameEnSelector;

        if (!string.IsNullOrWhiteSpace(term))
        {
            // name.Contains(term) with a null guard, composed by hand because the selector
            // arrives as a value rather than being written inline in this lambda.
            var needle = term.Trim();
            var parameter = name.Parameters[0];
            var notNull = Expression.NotEqual(name.Body, Expression.Constant(null, typeof(string)));
            var contains = Expression.Call(
                name.Body,
                typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!,
                Expression.Constant(needle));
            query = query.Where(Expression.Lambda<Func<T, bool>>(Expression.AndAlso(notNull, contains), parameter));
        }

        // OrderBy gets the expression directly (EF composes it); the id/text projection is
        // done in memory over at most 500 rows rather than fighting to build a New-expression.
        var entities = await query.OrderBy(name).Take(500).ToListAsync();
        var idFunc = idSelector.Compile();
        var textFunc = name.Compile();
        var options = entities.Select(e => new { id = idFunc(e), text = textFunc(e) }).ToList();

        return Json(options);
    }

    // ---------------------------------------------------------------- helpers

    private IQueryable<Item> BuildFilterQuery(string? searchAr, string? searchEn, byte? itemTypeId, int? groupId, int? familyId)
    {
        var query = Db.Items.Where(i => i.UserDeletionId == null);

        if (!string.IsNullOrWhiteSpace(searchAr))
        {
            var ar = searchAr.Trim();
            query = query.Where(i => i.NameAr != null && i.NameAr.StartsWith(ar));
        }
        if (!string.IsNullOrWhiteSpace(searchEn))
        {
            var en = searchEn.Trim();
            query = query.Where(i => i.NameEn != null && i.NameEn.StartsWith(en));
        }
        // Each picked filter is an independent AND; unpicked ones are simply not applied.
        if (itemTypeId.HasValue)
        {
            query = query.Where(i => i.ItemTypeId == itemTypeId);
        }
        if (groupId.HasValue)
        {
            query = query.Where(i => i.GroupId == groupId);
        }
        if (familyId.HasValue)
        {
            query = query.Where(i => i.FamilyId == familyId);
        }
        return query;
    }

    /// <summary>Full option lists for the Index/List filter bar (type excludes id 2).</summary>
    private async Task LoadSearchDropdownsAsync()
    {
        ViewBag.ItemTypes = await Db.ItemTypes
            .Where(t => t.UserDeletionId == null && t.Id != 2)
            .OrderBy(t => t.Id)
            .Select(t => new SelectOption { Value = t.Id.ToString(), TextAr = t.NameAr, TextEn = t.NameEn })
            .ToListAsync();

        ViewBag.Groups = await Db.Groups
            .Where(g => g.UserDeletionId == null)
            .OrderBy(g => g.NameAr)
            .Select(g => new SelectOption { Value = g.Id.ToString(), TextAr = g.NameAr, TextEn = g.NameEn })
            .ToListAsync();

        ViewBag.Families = await Db.Families
            .Where(f => f.UserDeletionId == null)
            .OrderBy(f => f.NameAr)
            .Select(f => new SelectOption { Value = f.Id.ToString(), TextAr = f.NameAr, TextEn = f.NameEn })
            .ToListAsync();
    }

    /// <summary>
    /// Builds every dropdown for the create/edit forms. Both chains are walked from the
    /// item's stored foreign keys (GroupId -> sec -> main, FamilyId -> order -> phylum ->
    /// kingdom), so an existing item opens with its full chain pre-selected. Each level
    /// lists the children of its parent, plus the current value when it disagrees with the
    /// chain (otherwise the select would silently fall back to its first option).
    /// </summary>
    private async Task LoadCascadeAsync(Item model)
    {
        ViewBag.ItemTypes = await Db.ItemTypes
            .Where(t => t.UserDeletionId == null && (t.Id != 2 || t.Id == model.ItemTypeId))
            .OrderBy(t => t.Id)
            .Select(t => new SelectOption { Value = t.Id.ToString(), TextAr = t.NameAr, TextEn = t.NameEn })
            .ToListAsync();

        ViewBag.Kingdoms = await Db.Kingdoms
            .Where(k => k.UserDeletionId == null)
            .OrderBy(k => k.Id)
            .Select(k => new SelectOption { Value = k.Id.ToString(), TextAr = k.NameAr, TextEn = k.NameEn })
            .ToListAsync();

        int? secId = null, mainId = null, orderId = null, phylumId = null, kingdomId = null;

        if (model.GroupId.HasValue)
        {
            secId = await Db.Groups
                .Where(g => g.Id == model.GroupId)
                .Select(g => g.SecClassId)
                .FirstOrDefaultAsync();
        }
        if (secId.HasValue)
        {
            mainId = await Db.SecondaryClassifications
                .Where(s => s.Id == secId)
                .Select(s => s.MainClassId)
                .FirstOrDefaultAsync();
        }
        if (model.FamilyId.HasValue)
        {
            orderId = await Db.Families
                .Where(f => f.Id == model.FamilyId)
                .Select(f => f.OrderId)
                .FirstOrDefaultAsync();
        }
        if (orderId.HasValue)
        {
            phylumId = await Db.Orders
                .Where(o => o.Id == orderId)
                .Select(o => o.PhylumId)
                .FirstOrDefaultAsync();
        }
        if (phylumId.HasValue)
        {
            kingdomId = await Db.PhylumSubphylums
                .Where(p => p.Id == phylumId)
                .Select(p => p.KingdomId)
                .FirstOrDefaultAsync();
        }

        var typeId = model.ItemTypeId;

        var mains = await Db.MainCalssifications
            .Where(m => m.UserDeletionId == null
                && ((typeId.HasValue && m.ItemTypeId == typeId) || (mainId.HasValue && m.Id == mainId)))
            .OrderBy(m => m.NameAr)
            .Select(m => new SelectOption { Value = m.Id.ToString(), TextAr = m.NameAr, TextEn = m.NameEn })
            .ToListAsync();

        var secs = await Db.SecondaryClassifications
            .Where(s => s.UserDeletionId == null
                && ((mainId.HasValue && s.MainClassId == mainId) || (secId.HasValue && s.Id == secId)))
            .OrderBy(s => s.NameAr)
            .Select(s => new SelectOption { Value = s.Id.ToString(), TextAr = s.NameAr, TextEn = s.NameEn })
            .ToListAsync();

        var groups = await Db.Groups
            .Where(g => g.UserDeletionId == null
                && ((secId.HasValue && g.SecClassId == secId) || (model.GroupId.HasValue && g.Id == model.GroupId)))
            .OrderBy(g => g.NameAr)
            .Select(g => new SelectOption { Value = g.Id.ToString(), TextAr = g.NameAr, TextEn = g.NameEn })
            .ToListAsync();

        var phylums = await Db.PhylumSubphylums
            .Where(p => p.UserDeletionId == null
                && ((kingdomId.HasValue && p.KingdomId == kingdomId) || (phylumId.HasValue && p.Id == phylumId)))
            .OrderBy(p => p.NameAr)
            .Select(p => new SelectOption { Value = p.Id.ToString(), TextAr = p.NameAr, TextEn = p.NameEn })
            .ToListAsync();

        var orders = await Db.Orders
            .Where(o => o.UserDeletionId == null
                && ((phylumId.HasValue && o.PhylumId == phylumId) || (orderId.HasValue && o.Id == orderId)))
            .OrderBy(o => o.NameAr)
            .Select(o => new SelectOption { Value = o.Id.ToString(), TextAr = o.NameAr, TextEn = o.NameEn })
            .ToListAsync();

        var families = await Db.Families
            .Where(f => f.UserDeletionId == null
                && ((orderId.HasValue && f.OrderId == orderId) || (model.FamilyId.HasValue && f.Id == model.FamilyId)))
            .OrderBy(f => f.NameAr)
            .Select(f => new SelectOption { Value = f.Id.ToString(), TextAr = f.NameAr, TextEn = f.NameEn })
            .ToListAsync();

        var culture = CurrentCulture;

        ViewBag.MainClasses = mains;
        ViewBag.SecClasses = secs;
        ViewBag.Phylums = phylums;
        ViewBag.Orders = orders;
        ViewBag.Groups = groups.Select(g => new SelectListItem(g.Text(culture), g.Value)).ToList();
        ViewBag.Families = families.Select(f => new SelectListItem(f.Text(culture), f.Value)).ToList();

        ViewBag.KingdomId = kingdomId?.ToString();
        ViewBag.PhylumId = phylumId?.ToString();
        ViewBag.OrderId = orderId?.ToString();
        ViewBag.MainClassId = mainId?.ToString();
        ViewBag.SecClassId = secId?.ToString();
    }

    /// <summary>Shared validation for create and edit.</summary>
    private void ValidateItem(Item model)
    {
        if (string.IsNullOrWhiteSpace(model.NameAr))
        {
            ModelState.AddModelError(nameof(model.NameAr), L["Common_RequiredData"].Value);
        }
        if (string.IsNullOrWhiteSpace(model.NameEn))
        {
            ModelState.AddModelError(nameof(model.NameEn), L["Common_RequiredData"].Value);
        }
        if (string.IsNullOrWhiteSpace(model.DescreptionAr))
        {
            ModelState.AddModelError(nameof(model.DescreptionAr), L["Common_RequiredData"].Value);
        }
        if (string.IsNullOrWhiteSpace(model.DescreptionEn))
        {
            ModelState.AddModelError(nameof(model.DescreptionEn), L["Common_RequiredData"].Value);
        }
        if (!model.ItemTypeId.HasValue)
        {
            ModelState.AddModelError(nameof(model.ItemTypeId), L["Common_RequiredData"].Value);
        }
        if (!model.GroupId.HasValue)
        {
            ModelState.AddModelError(nameof(model.GroupId), L["Common_RequiredData"].Value);
        }
        if (!model.FamilyId.HasValue)
        {
            ModelState.AddModelError(nameof(model.FamilyId), L["Common_RequiredData"].Value);
        }
        if (model.IsForbidden && string.IsNullOrWhiteSpace(model.ForbiddenReason))
        {
            ModelState.AddModelError(nameof(model.ForbiddenReason), L["Common_RequiredData"].Value);
        }
    }

    /// <summary>
    /// Legacy GetAny semantics: a non-deleted item of the same type sharing either the Arabic
    /// or the English name (excluding the row being edited) counts as a duplicate.
    /// </summary>
    private async Task<bool> IsDuplicateAsync(Item model, long? excludeId)
    {
        var nameAr = model.NameAr;
        var nameEn = model.NameEn;
        var typeId = model.ItemTypeId;
        return await Db.Items.AnyAsync(i => i.UserDeletionId == null
            && i.ItemTypeId == typeId
            && (i.NameAr == nameAr || i.NameEn == nameEn)
            && (excludeId == null || i.Id != excludeId));
    }

    private async Task<string> SavePictureAsync(IFormFile file)
    {
        var webRoot = _env.WebRootPath;
        if (string.IsNullOrEmpty(webRoot))
        {
            webRoot = Path.Combine(_env.ContentRootPath, "wwwroot");
        }
        var directory = Path.Combine(webRoot, "img", "Item");
        Directory.CreateDirectory(directory);

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName).ToLowerInvariant();
        await using var stream = System.IO.File.Create(Path.Combine(directory, fileName));
        await file.CopyToAsync(stream);
        return "/img/Item/" + fileName;
    }

    private static bool IsImageFile(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return extension is ".jpg" or ".jpeg" or ".png";
    }

    /// <summary>Reads the UserId claim defensively; a missing/unparsable claim yields 0.</summary>
    private short GetUserId()
    {
        var raw = User.FindFirstValue("UserId");
        return short.TryParse(raw, out var id) ? id : (short)0;
    }

    private void SetFilterBag(string? fAr, string? fEn, byte? fType, int? fGroup, int? fFamily)
    {
        ViewBag.SearchAr = fAr;
        ViewBag.SearchEn = fEn;
        ViewBag.ItemTypeId = fType;
        ViewBag.GroupId = fGroup;
        ViewBag.FamilyId = fFamily;
    }

    private static object FilterRoute(string? fAr, string? fEn, byte? fType, int? fGroup, int? fFamily) =>
        new { searchAr = fAr, searchEn = fEn, itemTypeId = fType, groupId = fGroup, familyId = fFamily };
}
