using ISCC.Application.Dashboard.Dtos;

namespace ISCC.Application.Dashboard;

/// <summary>
/// Public statistics dashboard: registered-entity counts plus four top-N tonnage charts.
/// </summary>
public interface IDashboardService
{
    /// <summary>Builds the whole dashboard in one round trip.</summary>
    Task<DashboardDto> GetAsync(CancellationToken cancellationToken = default);
}