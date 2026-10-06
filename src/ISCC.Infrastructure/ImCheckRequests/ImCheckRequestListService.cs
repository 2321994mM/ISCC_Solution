using ISCC.Application.ImCheckRequests;
using ISCC.Application.ImCheckRequests.Dtos;
using ISCC.Application.ReferenceData.Dtos;
using ISCC.Domain.Abstraction.IRepository;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Shared.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ISCC.Infrastructure.ImCheckRequests;

/// <summary>
/// EF Core implementation of <see cref="IImCheckRequestListService"/>.
/// </summary>
/// <remarks>
/// <para>
/// The list itself is <c>List_ImCheckRequest_Data</c>: tuned T-SQL over 321k
/// <c>Im_CheckRequest_Data</c> rows with a <c>ROW_NUMBER()</c> paging plan, so it stays a
/// stored procedure reached through <c>SqlQueryRaw&lt;T&gt;</c>. The two dropdowns are small
/// LINQ joins and follow the <see cref="ISCC.Infrastructure.ReferenceData.ReferenceDataService"/>
/// conventions (split polymorphic join, bilingual <see cref="SelectOption"/>).
/// </para>
/// <para>
/// The procedure was improved during porting (paging, <c>RECOMPILE</c>, varchar(50) request
/// number) and now forces <c>@PageSize = 25</c>; the caller only supplies the page number
/// and the filter values. The six day/month/year parameters are still passed because the
/// current application call supplies them, and the procedure keeps them for compatibility.
/// </para>
/// </remarks>
public class ImCheckRequestListService : IImCheckRequestListService
{
    /// <summary>The procedure's fixed page size. Passed only so the pager can be built.</summary>
    private const int PageSize = 25;

    private readonly PlantQuarantineDbContext _db;
    private readonly IUnitOfWork _unitOfWork;

    public ImCheckRequestListService(PlantQuarantineDbContext db, IUnitOfWork unitOfWork)
    {
        _db = db;
        _unitOfWork = unitOfWork;
    }

    public async Task<ImCheckRequestListResult> SearchAsync(
        ImCheckRequestListQuery query, CancellationToken cancellationToken)
    {
        var pageNumber = query.PageNumber < 1 ? 1 : query.PageNumber;
        var dateFrom = query.DateFrom.Date;
        var dateTo = query.DateTo.Date;

        // Legacy called with the endpoint date plus one day decomposed into its
        // day/month/year parts; the procedure uses those six parameters only for
        // compatibility, so the decomposition is preserved for the same reason.
        var end = dateTo.AddDays(1);

        var sql = """
            EXEC [dbo].[List_ImCheckRequest_Data]
                @long=@p0, @outlet_User=@p1, @DateFrom=@p2, @DateEnd=@p3,
                @selectApproveId=@p4, @FinalResultListId=@p5, @CheckRequest_Number=@p6,
                @Company_ID=@p7, @dayStart=@p8, @monthStart=@p9, @yearStart=@p10,
                @dayEnd=@p11, @monthEnd=@p12, @yearEnd=@p13, @PageNumber=@p14
            """;

        var parameters = new SqlParameter[]
        {
            // @long decides which language the procedure projects. "1" is Arabic, the
            // legacy convention for the mode the screen defaults to.
            new("@p0", SqlDbType.NVarChar, 1) { Value = query.IsArabic ? "1" : "0" },
            new("@p1", SqlDbType.BigInt) { Value = query.OutletId },
            new("@p2", SqlDbType.Date) { Value = dateFrom },
            new("@p3", SqlDbType.Date) { Value = dateTo },
            new("@p4", SqlDbType.Int) { Value = query.SelectApproveId },
            new("@p5", SqlDbType.Int) { Value = query.FinalResultListId },
            // varchar to match the column type and let SQL Server use the number index.
            new("@p6", SqlDbType.VarChar, 50) { Value = query.CheckRequestNumber ?? string.Empty },
            new("@p7", SqlDbType.BigInt) { Value = query.CompanyId },
            new("@p8", SqlDbType.Int) { Value = dateFrom.Day },
            new("@p9", SqlDbType.Int) { Value = dateFrom.Month },
            new("@p10", SqlDbType.Int) { Value = dateFrom.Year },
            new("@p11", SqlDbType.Int) { Value = end.Day },
            new("@p12", SqlDbType.Int) { Value = end.Month },
            new("@p13", SqlDbType.Int) { Value = end.Year },
            new("@p14", SqlDbType.Int) { Value = pageNumber },
        };

        var rows = await _db.Database
            .SqlQueryRaw<ImCheckRequestListRow>(sql, parameters)
            .ToListAsync(cancellationToken);

        // COUNT_BIG(1) OVER () is carried on every row; when there are none the count is
        // zero. The list itself is the rows, paged by the procedure.
        var totalCount = rows.Count == 0 ? 0 : rows[0].TotalCount;

        return new ImCheckRequestListResult(rows, totalCount, pageNumber, PageSize);
    }

    public async Task<IReadOnlyList<SelectOption>> GetCompaniesAsync(
        long outletId, CancellationToken cancellationToken)
    {
        // Same split as ReferenceDataService.GetImportersAsync, without the search term or
        // the 100-row cap: this dropdown shows every distinct importer of the outlet, as
        // the legacy FillDrop_Im_CheckRequest did.
        var scoped = ScopedImporterRows(outletId);

        var companies = await (
            from d in scoped
            join c in _unitOfWork.Repository<CompanyNational>().Query() on d.ImporterId equals c.Id
            where d.ImporterTypeId == (int)ImporterType.CompanyNational
            select new { c.Id, c.NameEn, c.NameAr })
            .Distinct()
            .ToListAsync(cancellationToken);

        var organizations = await (
            from d in scoped
            join o in _unitOfWork.Repository<PublicOrganization>().Query() on d.ImporterId equals o.Id
            where d.ImporterTypeId == (int)ImporterType.PublicOrganization
            select new { o.Id, o.NameEn, o.NameAr })
            .Distinct()
            .ToListAsync(cancellationToken);

        // Person has one Name column; both languages get the same value so an English
        // user still sees a name instead of a blank row.
        var people = await (
            from d in scoped
            join p in _unitOfWork.Repository<Person>().Query() on d.ImporterId equals p.Id
            where d.ImporterTypeId == (int)ImporterType.Person
            select new { p.Id, p.Name })
            .Distinct()
            .ToListAsync(cancellationToken);

        var merged = companies.Select(c => Option(c.Id, c.NameEn, c.NameAr))
            .Concat(organizations.Select(o => Option(o.Id, o.NameEn, o.NameAr)))
            .Concat(people.Select(p => Option(p.Id, p.Name, p.Name)))
            .Where(Usable);

        return Order(merged, IsArabicCulture).ToList();
    }

    public async Task<IReadOnlyList<SelectOption>> GetFinalResultOptionsAsync(
        int selectApproveId, CancellationToken cancellationToken)
    {
        // The working/not-working branches (selectApproveId 6/7) filter the list by the
        // final result's Status column: 6 looks for Status true, 7 for false. The legacy
        // chain enabled Status true for selectApproveId 1 and 6; the screen only calls
        // this for 6/7, so the same rule reproduces it exactly.
        var status = selectApproveId == 1 || selectApproveId == 6;

        var rows = await _unitOfWork.Repository<ImFinalResult>().Query()
            .Where(r => r.Status == status && r.UserDeletionId == null && r.IsActive == true)
            .Select(r => new SelectOption { Value = r.Id.ToString(), TextEn = r.EnName, TextAr = r.ArName })
            .ToListAsync(cancellationToken);

        return Order(rows.Where(Usable), IsArabicCulture).ToList();
    }

    /// <summary>
    /// Importer rows restricted to one outlet, or all outlets when the id is zero.
    /// </summary>
    /// <remarks>
    /// An inner join, not a left join: an importer row with no parent request cannot be
    /// attributed to an outlet and must not appear in a list scoped by one. Legacy's
    /// <c>INNER JOIN Im_CheckRequest</c> did the same.
    /// </remarks>
    private IQueryable<ImCheckRequestDatum> ScopedImporterRows(long outletId)
    {
        var data = _unitOfWork.Repository<ImCheckRequestDatum>().Query();

        if (outletId <= 0) return data;

        return from d in data
               join r in _unitOfWork.Repository<ImCheckRequest>().Query() on d.ImCheckRequestId equals r.Id
               where r.OutletId == outletId
               select d;
    }

    /// <summary>
    /// Sorts by whichever name the request will render, so the list reads in the user's
    /// language rather than always in Arabic as the legacy <c>ORDER BY Ar_Name</c> did.
    /// </summary>
    private static IEnumerable<SelectOption> Order(IEnumerable<SelectOption> source, bool isArabic) =>
        isArabic
            ? source.OrderBy(o => o.TextAr, StringComparer.CurrentCulture)
                   .ThenBy(o => o.TextEn, StringComparer.CurrentCulture)
            : source.OrderBy(o => o.TextEn, StringComparer.CurrentCulture)
                   .ThenBy(o => o.TextAr, StringComparer.CurrentCulture);

    /// <summary>Whether the request culture is Arabic, read from the flowed UI culture.</summary>
    private static bool IsArabicCulture =>
        System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            .StartsWith("ar", StringComparison.OrdinalIgnoreCase);

    /// <summary>Builds an option from a long id and its two names.</summary>
    private static SelectOption Option(long id, string? en, string? ar) =>
        new() { Value = id.ToString(), TextEn = en, TextAr = ar };

    /// <summary>
    /// Whether an option can be shown: a real id, and a name in at least one language.
    /// </summary>
    private static bool Usable(SelectOption? option) =>
        option is not null
        && option.Value != "0"
        && (!string.IsNullOrWhiteSpace(option.TextEn) || !string.IsNullOrWhiteSpace(option.TextAr));
}