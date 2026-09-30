using ISCC.Domain.Entities;

namespace ISCC.Domain.Interfaces;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(Payment payment, CancellationToken cancellationToken = default);
    Task<Payment?> GetPaymentByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetPaymentsByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetPaymentsByEmployerIdAsync(int employerId, CancellationToken cancellationToken = default);
}
