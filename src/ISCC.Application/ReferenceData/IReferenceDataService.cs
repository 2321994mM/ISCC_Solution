using ISCC.Application.ReferenceData.Dtos;
using ISCC.Shared.Contracts;

namespace ISCC.Application.ReferenceData;

/// <summary>
/// Read-only lookups that populate dropdowns across every portal.
/// </summary>
/// <remarks>
/// <para>
/// Every method returns <see cref="SelectOption"/>, which is bilingual and resolves its
/// own display text per request culture. Nothing here takes a language parameter.
/// </para>
/// <para>
/// The legacy implementation did the opposite: <c>ImportCheckRequestService</c> took an
/// <c>_language</c> int from <c>Import:DefaultLanguage</c> and returned a single
/// <c>Text</c> string chosen by <c>_language == 1 ? Ar : En</c>. That put the display
/// decision in a constructor-injected config value, so the language of a page was fixed
/// when the service was built rather than when the response was written, and an English
/// user with <c>Import:DefaultLanguage=1</c> got Arabic names.
/// </para>
/// </remarks>
public interface IReferenceDataService
{
    /// <summary>
    /// Importers that actually appear on a check request, for one outlet.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is deliberately <b>not</b> a master list of every company in
    /// <c>Company_National</c>. It returns only importers that are referenced by a check
    /// request, which is what makes it cheap enough to drive a type-ahead and is the
    /// behaviour the legacy dropdown had. Changing it to a full master list is a product
    /// decision, not a port.
    /// </para>
    /// <para>
    /// Callers should prepend their own "all" sentinel rather than expecting one here —
    /// see <c>ReferenceDataController</c>. A sentinel mixed into data cannot be told
    /// apart from a real row.
    /// </para>
    /// </remarks>
    /// <param name="outletId">
    /// Restricts to one outlet. Zero means every outlet, matching the legacy
    /// <c>@OutletId = 0 OR</c> behaviour used by the staff view.
    /// </param>
    /// <param name="selectedImporterId">
    /// An importer to include even when it does not match <paramref name="search"/>, so a
    /// dropdown can always display its current value. Zero or null to omit.
    /// </param>
    /// <param name="search">
    /// Free-text filter. The legacy code refused to search on fewer than two characters;
    /// that guard is preserved, because the underlying query scans check-request rows.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// At most 100 options, deduplicated by <see cref="SelectOption.Value"/>, ordered by
    /// the current request culture's name.
    /// </returns>
    Task<IReadOnlyList<SelectOption>> GetImportersAsync(
        long outletId,
        long? selectedImporterId,
        string? search,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Resolves a single importer's option, for prefilling a filter.
    /// </summary>
    /// <remarks>
    /// Needed because the importer id is meaningless without its
    /// <see cref="ImporterType"/>: id 42 may be a company, an organization and a person.
    /// The type is recovered by looking for the id in all three tables, so the caller
    /// never has to know it.
    /// </remarks>
    /// <param name="outletId">Restricts to one outlet. Zero means every outlet.</param>
    /// <param name="importerId">The importer id to resolve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The option, or null when no importer with that id is referenced by a check request.</returns>
    Task<SelectOption?> GetImporterAsync(
        long outletId,
        long importerId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Active final quarantine results, used as a filter on the Import screens.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<IReadOnlyList<SelectOption>> GetImportFinalResultsAsync(
        CancellationToken cancellationToken = default);
}
