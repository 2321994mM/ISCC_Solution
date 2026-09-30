using ISCC.Domain.Entities;
using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class InspectionService : IInspectionService
{
    private readonly ISCCDbContext _context;

    public InspectionService(ISCCDbContext context)
    {
        _context = context;
    }

    public async Task<Inspection> CreateInspectionAsync(Inspection inspection, CancellationToken cancellationToken = default)
    {
        await _context.Inspections.AddAsync(inspection, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return inspection;
    }

    public async Task<Inspection?> GetInspectionByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Inspections.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<Inspection>> GetInspectionsByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await _context.Inspections
            .Where(i => i.ClientId == clientId && !i.IsDeleted)
            .ToListAsync(cancellationToken);
    }
}
