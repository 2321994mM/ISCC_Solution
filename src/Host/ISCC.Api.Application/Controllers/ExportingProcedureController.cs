using ISCC.Application.TradeProcedures;
using ISCC.Application.TradeProcedures.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Export phytosanitary requirements. Migrated from
/// <c>Capqwebsite/Controllers/ExportingProcedureController.cs</c> (368 live lines; the
/// remainder was a commented-out earlier version — dropped).
/// </summary>
/// <remarks>
/// Deliberately the mirror image of <see cref="ImportingProcedureController"/>: the same
/// country → variety → requirements cascade, but reached through
/// <c>Ex_CountryConstrains</c> rather than <c>Im_Initiators</c>, with a different
/// soft-delete rule. Both are served by <see cref="ITradeProcedureService"/>.
/// </remarks>
public class ExportingProcedureController : BaseController
{
    private readonly ITradeProcedureService _trade;

    public ExportingProcedureController(ITradeProcedureService trade, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _trade = trade;
    }

    [AllowAnonymous]
    [Route("/ExportingProcedure/Index")]
    public async Task<IActionResult> Index(long CountryID = 0, long ItemID = 0, CancellationToken cancellationToken = default)
    {
        try
        {
            List<CountryOptionDto> countries = await _trade.GetExportCountriesAsync(cancellationToken);

            ViewData["CountryList"] = new SelectList(countries, nameof(CountryOptionDto.Id),
                nameof(CountryOptionDto.NameAr), CountryID);

            List<ItemOptionDto> items = CountryID > 0
                ? await _trade.GetExportItemsAsync(CountryID, cancellationToken)
                : new List<ItemOptionDto>();

            ViewData["ItemList"] = new SelectList(items, nameof(ItemOptionDto.Id),
                nameof(ItemOptionDto.NameAr), ItemID);

            List<ExportConstraintDto> constraints = CountryID > 0 && ItemID > 0
                ? await _trade.GetExportConstraintsAsync(CountryID, ItemID, cancellationToken)
                : new List<ExportConstraintDto>();

            return View(constraints);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ExportingProcedureController), nameof(Index), ex.Message);
            throw;
        }
    }

    /// <summary>AJAX: refill the plant-variety drop-down when the country changes.</summary>
    [HttpGet]
    [AllowAnonymous]
    [Route("/ExportingProcedure/GetItemsByCountry")]
    public async Task<IActionResult> GetItemsByCountry(long CountryID, CancellationToken cancellationToken)
    {
        try
        {
            if (CountryID <= 0)
                return Json(new List<ItemOptionDto>());

            List<ItemOptionDto> items = await _trade.GetExportItemsAsync(CountryID, cancellationToken);
            return Json(items);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ExportingProcedureController), nameof(GetItemsByCountry), ex.Message);
            throw;
        }
    }

    /// <summary>AJAX: refresh the requirements table when either drop-down changes.</summary>
    [HttpGet]
    [AllowAnonymous]
    [Route("/ExportingProcedure/GetConstraints")]
    public async Task<IActionResult> GetConstraints(long CountryID, long ItemID, CancellationToken cancellationToken)
    {
        try
        {
            if (CountryID <= 0 || ItemID <= 0)
                return PartialView("_PartialExporting", new List<ExportConstraintDto>());

            List<ExportConstraintDto> constraints =
                await _trade.GetExportConstraintsAsync(CountryID, ItemID, cancellationToken);

            return PartialView("_PartialExporting", constraints);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(ExportingProcedureController), nameof(GetConstraints), ex.Message);
            throw;
        }
    }
}
