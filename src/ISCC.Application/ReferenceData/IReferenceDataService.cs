using ISCC.Application.ReferenceData.Dtos;

namespace ISCC.Application.ReferenceData;

/// <summary>Read access to published reference data (approved/suspended farms, stations).</summary>
public interface IReferenceDataService
{
    /// <summary>
    /// Suspended farms for a farm code. Legacy matched <c>Farmcode == FarmCode</c> exactly,
    /// with no ordering and no paging.
    /// </summary>
    Task<List<FarmStopDto>> GetFarmStopsAsync(string? farmCode, CancellationToken cancellationToken = default);
}