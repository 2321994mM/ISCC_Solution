using ISCC.Domain.Entities;

namespace ISCC.Domain.Interfaces;

public interface IInspectionService
{
    Task<Inspection> CreateInspectionAsync(Inspection inspection, CancellationToken cancellationToken = default);
    Task<Inspection?> GetInspectionByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Inspection>> GetInspectionsByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
}
