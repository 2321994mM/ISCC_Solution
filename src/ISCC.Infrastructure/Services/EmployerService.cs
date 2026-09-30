using ISCC.Domain.Entities;
using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class EmployerService : IEmployerService
{
    private readonly ISCCDbContext _context;

    public EmployerService(ISCCDbContext context)
    {
        _context = context;
    }

    public async Task<Employer> CreateEmployerAsync(Employer employer, CancellationToken cancellationToken = default)
    {
        await _context.Employers.AddAsync(employer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return employer;
    }

    public async Task<Employer?> GetEmployerByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Employers.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<Employer>> GetAllEmployersAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Employers
            .Where(e => !e.IsDeleted)
            .ToListAsync(cancellationToken);
    }
}
