using ISCC.Application.ExCheckRequests;
using ISCC.Application.ExCheckRequests.Dtos;
using ISCC.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ISCC.Infrastructure.ExCheckRequests;

/// <summary>
/// EF Core implementation of <see cref="IExCheckRequestListService"/>.
/// </summary>
/// <remarks>
/// <para>
/// The list is a raw query over the <c>dbo.Ex_List</c> database view, reached through
/// <c>SqlQueryRaw&lt;T&gt;</c>. The view already carries the four permission scopes the
/// legacy chain filtered on (outlet examination, station examination, outlet genshi,
/// station genshi) plus the bilingual labels collapsed to Arabic, so the query needs only
/// the scope predicate and the request-number contains-filter — exactly what the legacy
/// <c>GetListWithPage_List_filter</c> LINQ compiled to.
/// </para>
/// <para>
/// The station predicate is written as two <c>EXISTS</c> subqueries against
/// <c>Station_Emp</c> (the user's active, non-deleted stations whose <c>Date_To</c> has not
/// passed), which is what EF produced for <c>List_Station_Emp.Contains(...)</c>. Empty
/// search means no filter: the query keeps one shape and lets <c>@search = N''</c> match
/// everything, exactly as the legacy <c>LIKE '%%'</c> branch did.
/// </para>
/// </remarks>
public class ExCheckRequestListService : IExCheckRequestListService
{
    /// <summary>The screen's fixed page size, matching the legacy <c>pageSize = 10</c>.</summary>
    private const int PageSize = 10;

    private readonly PlantQuarantineDbContext _db;

    public ExCheckRequestListService(PlantQuarantineDbContext db)
    {
        _db = db;
    }

    public async Task<ExCheckRequestListResult> SearchAsync(
        ExCheckRequestListQuery query, CancellationToken cancellationToken)
    {
        var pageNumber = query.PageNumber < 1 ? 1 : query.PageNumber;
        var search = query.Search.Trim();
        // Legacy computed "today" on the web server (DateTime.Now.Date) and compared it
        // against Station_Emp.Date_To; pass the same value as a date parameter rather than
        // letting SQL Server use its own clock.
        var today = DateTime.Today;

        var sql = """
            SELECT
                exl.Outlet_User_ID,
                exl.Outlet_User_Name,
                exl.Center_ID,
                exl.Ex_CheckRequest_ID,
                exl.ImCheckRequest_Number,
                exl.Creation_Date,
                exl.IsAccepted,
                exl.IsActive,
                exl.ExportCountryName,
                exl.Importer_ID,
                exl.ImporterType_Id,
                exl.IsPaid,
                exl.Outlet_ID,
                exl.ImporterTypeName,
                exl.ImporterName,
                exl.f,
                exl.g,
                exl.Outlet_Examination_ID,
                exl.Outlet_Examination_Name,
                exl.Station_Examination_ID,
                exl.Outlet_Genshi_ID,
                exl.Outlet_Genshi_Name,
                exl.Station_Genshi_ID,
                exl.Closed_Request,
                exl.Final_Result_ID,
                exl.Final_Result_Name,
                exl.Station_Examination_Name,
                exl.Station_Genshi_Name,
                COUNT_BIG(1) OVER () AS TotalCount
            FROM dbo.Ex_List AS exl
            WHERE
                (
                    EXISTS (
                        SELECT 1
                        FROM dbo.Station_Emp AS se
                        WHERE se.Emp_Id = @p0
                          AND se.IsActive = 1
                          AND se.User_Deletion_Date IS NULL
                          AND se.Date_To >= @p4
                          AND se.Station_Id = exl.Station_Examination_ID)
                    OR EXISTS (
                        SELECT 1
                        FROM dbo.Station_Emp AS se
                        WHERE se.Emp_Id = @p0
                          AND se.IsActive = 1
                          AND se.User_Deletion_Date IS NULL
                          AND se.Date_To >= @p4
                          AND se.Station_Id = exl.Station_Genshi_ID)
                    OR exl.Outlet_Examination_ID = @p1
                    OR exl.Outlet_Genshi_ID = @p1
                )
                AND (@p2 = N'' OR exl.ImCheckRequest_Number LIKE N'%' + @p2 + N'%')
            ORDER BY exl.Ex_CheckRequest_ID DESC
            OFFSET (@p3 - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;
            """;

        var parameters = new SqlParameter[]
        {
            new("@p0", SqlDbType.BigInt) { Value = query.UserId },
            new("@p1", SqlDbType.BigInt) { Value = query.OutletId },
            new("@p2", SqlDbType.NVarChar, 50) { Value = search },
            new("@p3", SqlDbType.Int) { Value = pageNumber },
            new("@p4", SqlDbType.Date) { Value = today },
        };

        var rows = await _db.Database
            .SqlQueryRaw<ExCheckRequestListRow>(sql, parameters)
            .ToListAsync(cancellationToken);

        // COUNT_BIG(1) OVER () runs before OFFSET/FETCH, so every row carries the unpaged
        // count; when there are none the count is zero.
        var totalCount = rows.Count == 0 ? 0 : rows[0].TotalCount;

        return new ExCheckRequestListResult(rows, totalCount, pageNumber, PageSize);
    }
}