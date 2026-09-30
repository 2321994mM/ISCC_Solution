using ISCC.Domain.Entities;
using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly ISCCDbContext _context;

    public PaymentService(ISCCDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> CreatePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        await _context.Payments.AddAsync(payment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return payment;
    }

    public async Task<Payment?> GetPaymentByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Payments.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetPaymentsByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Where(p => p.ClientId == clientId && !p.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetPaymentsByEmployerIdAsync(int employerId, CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Where(p => p.EmployerId == employerId && !p.IsDeleted)
            .ToListAsync(cancellationToken);
    }
}
