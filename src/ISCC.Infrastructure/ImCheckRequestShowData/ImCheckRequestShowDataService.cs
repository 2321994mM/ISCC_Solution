using ISCC.Application.ImCheckRequestShowData;
using ISCC.Application.ImCheckRequestShowData.Dtos;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.ImCheckRequestShowData;

/// <summary>
/// EF Core port of the legacy <c>Pro_Im_CheckRequest_ShowData</c> stored procedure, reached
/// through <c>Im_CheckRequest_ShowDataBLL</c> ("موقف طلبات الفحص الواردة", menu 165).
/// </summary>
/// <remarks>
/// <para>
/// The procedure is a single <c>GROUP BY o.Ar_Name, o.ID</c> over the inspection requests of
/// every outlet. It inner-joins <c>Im_CheckRequest_Data</c> and <c>Country</c> (so a request
/// without a data row, or whose export country no longer exists, is excluded) and left-joins
/// <c>Im_CheckRequest_Final_Result</c> → <c>Im_Final_Result</c> and <c>Outlet</c>. The
/// conditional counts are expressed here as <c>g.Count(predicate)</c>, which EF Core renders
/// as the same <c>COUNT(CASE WHEN ... THEN 1 END)</c>.
/// </para>
/// <para>
/// The grouping is done in the database; only the aggregated rows cross the wire.
/// </para>
/// </remarks>
public class ImCheckRequestShowDataService : IImCheckRequestShowDataService
{
    private readonly PlantQuarantineDbContext _db;

    public ImCheckRequestShowDataService(PlantQuarantineDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ImCheckRequestShowDataDto>> GetAllAsync(
        bool isArabic, CancellationToken cancellationToken)
    {
        // The join shape has to match the procedure exactly: the two INNER joins filter rows,
        // and a request may have more than one data row or more than one final-result row, so
        // the counts are counts of *joined* rows, not of distinct requests.
        var rows =
            from cc in _db.ImCheckRequests.AsNoTracking()
            join rr in _db.ImCheckRequestData.AsNoTracking()
                on cc.Id equals rr.ImCheckRequestId
            join co in _db.Countries.AsNoTracking()
                on rr.ExportCountryId equals co.Id
            from chfr in _db.ImCheckRequestFinalResults.AsNoTracking()
                .Where(f => f.ImCheckRequestId == cc.Id)
                .DefaultIfEmpty()
            from ifr in _db.ImFinalResults.AsNoTracking()
                .Where(f => f.Id == chfr.ImFinalResultId)
                .DefaultIfEmpty()
            from o in _db.Outlets.AsNoTracking()
                .Where(x => x.Id == cc.OutletId)
                .DefaultIfEmpty()
            select new
            {
                cc.IsAccepted,
                FinalStatus = (bool?)ifr.Status,
                OutletId = (long?)o.Id,
                o.ArName,
                o.EnName,
            };

        var result = await rows
            .GroupBy(x => new { x.OutletId, x.ArName, x.EnName })
            .Select(g => new ImCheckRequestShowDataDto
            {
                // The procedure emitted the string '0' when the outlet was NULL.
                outlet_ID = g.Key.OutletId ?? 0,
                outlet_Name = isArabic ? g.Key.ArName : g.Key.EnName,
                CheckRequest_Count_all = g.Count(),
                CheckRequest_Count_true = g.Count(x => x.IsAccepted == true),
                CheckRequest_Count_false = g.Count(x => x.IsAccepted == false),
                CheckRequest_Count_nulls = g.Count(x => x.IsAccepted == null),
                Closed_Request_true = g.Count(x => x.FinalStatus == true),
                Closed_Request_false = g.Count(x => x.FinalStatus == false),
                Closed_Request_nulls = g.Count(x => x.FinalStatus == null),
            })
            // The procedure had no ORDER BY, but SQL Server returned the groups in outlet-id
            // order; ordering explicitly keeps the board stable between runs.
            .OrderBy(r => r.outlet_ID)
            .ToListAsync(cancellationToken);

        return result;
    }
}
