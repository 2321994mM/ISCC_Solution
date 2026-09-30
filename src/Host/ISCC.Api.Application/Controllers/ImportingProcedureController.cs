using ISCC.Application.TradeProcedures;
using ISCC.Application.TradeProcedures.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Import phytosanitary requirements. Migrated from
/// <c>Capqwebsite/Controllers/ImportingProcedureController.cs</c> (379 lines, of which
/// lines 281-379 were a commented-out earlier version — dropped).
/// </summary>
/// <remarks>
/// All four query blocks now call <see cref="ITradeProcedureService"/>, which reproduces
/// the legacy soft-delete filtering exactly — including the places where the legacy code
/// skipped a filter it applied elsewhere. See that interface for the full list.
/// </remarks>
public class ImportingProcedureController : BaseController
{
    private readonly ITradeProcedureService _trade;

    public ImportingProcedureController(ITradeProcedureService trade, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _trade = trade;
    }

    [AllowAnonymous]
    [Route("/ImportingProcedure/Index")]
    public async Task<IActionResult> Index(long ImInitiatorID = 0, long ItemID = 0, CancellationToken cancellationToken = default)
    {
        try
        {
            // Both drop-downs are always populated; the requirements table only when a
            // country and a variety have both been chosen. Legacy returned an empty list
            // (not a null model) in that case, and the view branches on Model.Any().
            List<CountryOptionDto> countries = await _trade.GetImportCountriesAsync(cancellationToken);

            ViewData["ImInitiatorList"] = new SelectList(countries, nameof(CountryOptionDto.Id),
                nameof(CountryOptionDto.NameAr), ImInitiatorID);

            List<ItemOptionDto> items = ImInitiatorID > 0
                ? await _trade.GetImportItemsAsync(ImInitiatorID, cancellationToken)
                : new List<ItemOptionDto>();

            ViewData["ItemList"] = new SelectList(items, nameof(ItemOptionDto.Id),
                nameof(ItemOptionDto.NameAr), ItemID);

            List<ImportConstraintDto> constraints = ImInitiatorID > 0 && ItemID > 0
                ? await _trade.GetImportConstraintsAsync(ImInitiatorID, ItemID, cancellationToken)
                : new List<ImportConstraintDto>();

            return View(constraints);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImportingProcedureController), nameof(Index), ex.Message);
            throw;
        }
    }

    /// <summary>AJAX: refill the plant-variety drop-down when the country changes.</summary>
    [HttpGet]
    [AllowAnonymous]
    [Route("/ImportingProcedure/GetItemsByInitiator")]
    public async Task<IActionResult> GetItemsByInitiator(long ImInitiatorID, CancellationToken cancellationToken)
    {
        try
        {
            if (ImInitiatorID <= 0)
                return Json(new List<ItemOptionDto>());

            List<ItemOptionDto> items = await _trade.GetImportItemsAsync(ImInitiatorID, cancellationToken);
            return Json(items);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImportingProcedureController), nameof(GetItemsByInitiator), ex.Message);
            throw;
        }
    }

    /// <summary>AJAX: refresh the requirements table when either drop-down changes.</summary>
    [HttpGet]
    [AllowAnonymous]
    [Route("/ImportingProcedure/GetConstraints")]
    public async Task<IActionResult> GetConstraints(long ImInitiatorID, long ItemID, CancellationToken cancellationToken)
    {
        try
        {
            if (ImInitiatorID <= 0 || ItemID <= 0)
                return PartialView("_PartialImporting", new List<ImportConstraintDto>());

            List<ImportConstraintDto> constraints =
                await _trade.GetImportConstraintsAsync(ImInitiatorID, ItemID, cancellationToken);

            return PartialView("_PartialImporting", constraints);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ImportingProcedureController), nameof(GetConstraints), ex.Message);
            throw;
        }
    }

    /// <summary>
    /// "Open a factory" information page.
    /// </summary>
    /// <remarks>
    /// The legacy controller had this action but no matching view anywhere in the Views
    /// tree, so calling it threw a view-not-found error. Nothing links to it — the nav
    /// points at the CMS section <c>?ID=13</c> instead. It is kept so the route still
    /// exists, but returns 404 rather than a 500.
    /// </remarks>
    [AllowAnonymous]
    [Route("/ImportingProcedure/OpenSource")]
    public IActionResult OpenSource() => NotFound();
}
