using ISCC.Application.ReferenceData;
using ISCC.Shared.Contracts;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Dropdown data for the Import screens: importers and final results.
/// </summary>
/// <remarks>
/// <para>
/// Ported from <c>PlantQuarantine.NewMvc</c>'s <c>ImportCheckRequestService</c>, which
/// served the same two lookups from raw <c>SqlCommand</c> calls. Rewritten onto
/// <see cref="IReferenceDataService"/> and EF Core.
/// </para>
/// <para>
/// The legacy version hardcoded its "all" labels in Arabic regardless of the request
/// language — <c>"كل الشركات"</c> and <c>"كل مواقف الحجر"</c> — so an English user got an
/// Arabic first option. Those strings now come from the shared localizer.
/// </para>
/// </remarks>
[ApiController]
[Route("api/reference-data")]
[Produces("application/json")]
public class ReferenceDataController : ApiControllerBase
{
    private readonly IReferenceDataService _referenceData;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public ReferenceDataController(
        IReferenceDataService referenceData,
        IStringLocalizer<SharedResource> localizer)
    {
        _referenceData = referenceData;
        _localizer = localizer;
    }

    /// <summary>
    /// Importers that appear on a check request, for type-ahead search.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A search of fewer than two characters returns only the "all" sentinel, because the
    /// legacy dropdown refused to search below that length. Clients should treat an
    /// <c>items</c> array holding only the sentinel as "not searched yet" rather than as
    /// "no matches".
    /// </para>
    /// <para>
    /// At most 101 entries: the sentinel plus 100 importers. The cap is the legacy
    /// <c>SELECT TOP (100)</c>, applied to the importers themselves and not counting the
    /// sentinel. Ordering follows the request culture.
    /// </para>
    /// </remarks>
    /// <param name="outletId">Restrict to one outlet. Omit or pass 0 for all outlets.</param>
    /// <param name="selectedImporterId">
    /// Include this importer even if it does not match <paramref name="search"/>.
    /// </param>
    /// <param name="search">Free-text filter on the importer name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("importers")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<SelectOption>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<SelectOption>>>> GetImporters(
        [FromQuery] long outletId = 0,
        [FromQuery] long? selectedImporterId = null,
        [FromQuery] string? search = null,
        CancellationToken cancellationToken = default)
    {
        var options = await _referenceData.GetImportersAsync(
            outletId, selectedImporterId, search, cancellationToken);

        return ApiOk(WithAllSentinel(options, "AllCompanies"));
    }

    /// <summary>
    /// Resolves one importer to its display names, for prefilling a filter.
    /// </summary>
    /// <param name="importerId">The importer id.</param>
    /// <param name="outletId">Restrict to one outlet. Omit or pass 0 for all outlets.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("importers/{importerId:long}")]
    [ProducesResponseType(typeof(ApiResponse<SelectOption>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<SelectOption>>> GetImporter(
        long importerId,
        [FromQuery] long outletId = 0,
        CancellationToken cancellationToken = default)
    {
        var option = await _referenceData.GetImporterAsync(outletId, importerId, cancellationToken);

        // Split rather than a ternary: the success envelope is ApiResponse<SelectOption>
        // and the failure one is ApiResponse<object>. They are different generic types, so
        // the branches do not unify. The wire shape is unaffected — data is simply absent
        // on the failure — and a client parsing the envelope parses both.
        if (option is null)
        {
            return ApiNotFound<SelectOption>(
                $"No importer with id {importerId} is referenced by a check request.");
        }

        return ApiOk(option);
    }

    /// <summary>Active final quarantine results, for the Import result filter.</summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("import-final-results")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<SelectOption>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<SelectOption>>>> GetImportFinalResults(
        CancellationToken cancellationToken = default)
    {
        var options = await _referenceData.GetImportFinalResultsAsync(cancellationToken);

        return ApiOk(WithAllSentinel(options, "AllFinalResults"));
    }

    /// <summary>
    /// Prepends a localized "all" option carrying id 0.
    /// </summary>
    /// <remarks>
    /// Added here rather than in the service because it is a UI sentinel, not a row. In the
    /// data layer it would be indistinguishable from a real importer, and a filter that
    /// treats "0" as a real id would behave wrongly. Legacy had it inside the service
    /// alongside genuine rows, with no way to tell them apart.
    /// </remarks>
    /// <param name="options">Options to wrap.</param>
    /// <param name="resourceKey">Localizer key for the sentinel's label.</param>
    private IReadOnlyList<SelectOption> WithAllSentinel(
        IReadOnlyList<SelectOption> options, string resourceKey)
    {
        var label = _localizer[resourceKey];

        // Localizer returns the key itself when a resource is missing. Falling back to the
        // value keeps the option visible and makes the gap obvious instead of rendering
        // the raw key to a user.
        var text = label.ResourceNotFound
            ? _localizer[resourceKey, "All"].Value
            : label.Value;

        return new[] { new SelectOption { Value = "0", TextEn = text, TextAr = text } }
            .Concat(options)
            .ToList();
    }
}
