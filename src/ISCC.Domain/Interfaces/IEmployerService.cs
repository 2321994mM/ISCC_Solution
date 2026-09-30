using ISCC.Domain.Entities;

namespace ISCC.Domain.Interfaces;

public interface IEmployerService
{
    Task<Employer> CreateEmployerAsync(Employer employer, CancellationToken cancellationToken = default);
    Task<Employer?> GetEmployerByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Employer>> GetAllEmployersAsync(CancellationToken cancellationToken = default);
}
