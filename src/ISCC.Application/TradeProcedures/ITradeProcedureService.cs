using ISCC.Application.TradeProcedures.Dtos;

namespace ISCC.Application.TradeProcedures;

/// <summary>
/// Import/export phytosanitary requirement lookups.
/// </summary>
/// <remarks>
/// Backs two structurally identical legacy controllers — <c>ImportingProcedureController</c>
/// and <c>ExportingProcedureController</c> — each of which offered a
/// country drop-down, a plant-variety drop-down that depended on it, and a
/// requirements table that depended on both, with two AJAX endpoints to refill the
/// second drop-down and the table without a full page reload.
/// <para>
/// <b>Filter parity.</b> The two legacy controllers applied <i>different</i> soft-delete
/// rules, and each of their three queries applied different rules again. Every one of
/// those asymmetries is reproduced exactly in the implementation rather than
/// normalised, because normalising them would change which rows appear. Each is
/// documented at the method that preserves it.
/// </para>
/// </remarks>
public interface ITradeProcedureService
{
    // ---------- Import ----------

    /// <summary>Countries that have at least one active import requirement.</summary>
    Task<List<CountryOptionDto>> GetImportCountriesAsync(CancellationToken cancellationToken = default);

    /// <summary>Plant varieties available for an importing country.</summary>
    /// <param name="countryId">Country id; ignored when not positive.</param>
    Task<List<ItemOptionDto>> GetImportItemsAsync(long countryId, CancellationToken cancellationToken = default);

    /// <summary>Import requirement rows for a country and variety.</summary>
    Task<List<ImportConstraintDto>> GetImportConstraintsAsync(
        long countryId, long itemId, CancellationToken cancellationToken = default);

    // ---------- Export ----------

    /// <summary>Countries that have at least one active export requirement.</summary>
    Task<List<CountryOptionDto>> GetExportCountriesAsync(CancellationToken cancellationToken = default);

    /// <summary>Plant varieties with an active export requirement for a country.</summary>
    /// <param name="countryId">Country id; ignored when not positive.</param>
    Task<List<ItemOptionDto>> GetExportItemsAsync(long countryId, CancellationToken cancellationToken = default);

    /// <summary>Export requirement rows for a country and variety.</summary>
    Task<List<ExportConstraintDto>> GetExportConstraintsAsync(
        long countryId, long itemId, CancellationToken cancellationToken = default);
}
