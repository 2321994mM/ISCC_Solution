using ISCC.Application.ReferenceData;
using ISCC.Application.ReferenceData.Dtos;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class ReferenceDataService : IReferenceDataService
{
    private readonly PlantQuarantineDbContext _context;

    public ReferenceDataService(PlantQuarantineDbContext context)
    {
        _context = context;
    }

    public async Task<List<FarmStopDto>> GetFarmStopsAsync(string? farmCode, CancellationToken cancellationToken = default)
    {
        var query = _context.FarmStops.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(farmCode))
            query = query.Where(f => f.Farmcode == farmCode);

        return await query
            .Select(f => new FarmStopDto
            {
                Id = f.Id,
                Farmcode = f.Farmcode,
                Farmname = f.Farmname,
                Compname = f.Compname,
                Cropname = f.Cropname,
                StopDate = f.StopDate,
                Previewdate = f.Previewdate,
                Text104 = f.Text104,
            })
            .ToListAsync(cancellationToken);
    }
}