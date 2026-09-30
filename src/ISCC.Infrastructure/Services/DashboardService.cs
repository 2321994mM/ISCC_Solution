using ISCC.Application.Dashboard;
using ISCC.Application.Dashboard.Dtos;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly PlantQuarantineDbContext _context;

    public DashboardService(PlantQuarantineDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The legacy rule: the current year is used from April onwards, otherwise the previous
    /// year. So a visitor in February 2026 sees 2025 figures. The April boundary is odd
    /// (January would be the natural cut) but it is preserved exactly — the reporting year is
    /// printed in the Arabic subtitle and drives every figure on the page, so changing it
    /// would silently change what the dashboard claims to show.
    /// </summary>
    private static int ResolveReportingYear(DateTime today) =>
        today.Month > 3 ? today.Year : today.Year - 1;

    public async Task<DashboardDto> GetAsync(CancellationToken cancellationToken = default)
    {
        int year = ResolveReportingYear(DateTime.Now);

        return new DashboardDto
        {
            Year = year,

            // The legacy code called .ToList().Count() on each of these, pulling every row of
            // every table into memory just to take a row count. Same numbers, one COUNT(*)
            // in SQL instead of a full materialisation.
            PeopleCount = await _context.People.AsNoTracking().CountAsync(cancellationToken),
            PublicOrganizationCount = await _context.PublicOrganizations.AsNoTracking().CountAsync(cancellationToken),
            CompanyNationalCount = await _context.CompanyNationals.AsNoTracking().CountAsync(cancellationToken),

            ImportCountries = await GetImportCountriesAsync(year, cancellationToken),
            ExportCountries = await GetExportCountriesAsync(year, cancellationToken),
            ImportProducts = await GetImportProductsAsync(year, cancellationToken),
            ExportProducts = await GetExportProductsAsync(year, cancellationToken),
        };
    }

    // =================================================================
    // Inbound (import)
    // =================================================================

    private async Task<List<DashboardGroupDto>> GetImportCountriesAsync(int year, CancellationToken cancellationToken)
    {
        // "Country" here means the country of origin of an inbound consignment, so it groups
        // by Im_CheckRequest_Data.ExportCountry_Id rather than a column on the request.
        //
        // Reached through the shipping-method table, so a request whose shipping methods
        // carry no line items contributes nothing.
        List<GroupAggregate> grouped = await (
            from pr in _context.ImCheckRequests.AsNoTracking()
                // Accepted *and* accepted within the reporting year. The HasValue test is not
                // decorative: DATEPART(year, NULL) is NULL, so the comparison is already
                // false for a missing date, but stating it lets SQL Server seek on
                // IsAccepted_Date instead of scanning the whole table through DATEPART.
                .Where(a => a.IsAccepted == true && a.IsAcceptedDate.HasValue && a.IsAcceptedDate.Value.Year == year)
            join shipping in _context.ImCheckRequsetShippingMethods.AsNoTracking() on pr.Id equals shipping.ImCheckRequestId
            join item in _context.ImCheckRequestItems.AsNoTracking() on shipping.Id equals item.ImCheckRequsetShippingMethodId
            join data in _context.ImCheckRequestData.AsNoTracking() on pr.Id equals data.ImCheckRequestId
            join country in _context.Countries.AsNoTracking() on data.ExportCountryId equals country.Id
            group item by country.ArName into g
            // The legacy divided the summed weight by 1000 *after* aggregating; that order
            // of operations is kept here rather than the product charts' per-row division.
            select new GroupAggregate { Label = g.Key, Tonnes = (double)(g.Sum(x => x.GrossWeight ?? 0m) / 1000m) })
            .ToListAsync(cancellationToken);

        return Rank(grouped, take: 5);
    }

    private async Task<List<DashboardGroupDto>> GetImportProductsAsync(int year, CancellationToken cancellationToken)
    {
        // Note this query does not join Im_CheckRequest_Data — unlike the country chart it
        // never looks at which country the consignment came from.
        List<GroupAggregate> grouped = await (
            from pr in _context.ImCheckRequests.AsNoTracking()
                .Where(a => a.IsAccepted == true && a.IsAcceptedDate.HasValue && a.IsAcceptedDate.Value.Year == year)
            join shipping in _context.ImCheckRequsetShippingMethods.AsNoTracking() on pr.Id equals shipping.ImCheckRequestId
            join item in _context.ImCheckRequestItems.AsNoTracking() on shipping.Id equals item.ImCheckRequsetShippingMethodId
            join variety in _context.ItemShortNames.AsNoTracking() on item.ItemShortNameId equals variety.Id
            group item by variety.ShortNameAr into g
            // Here the legacy divided each row *before* summing. With decimal arithmetic,
            // summing per-row divisions is not always identical to dividing the sum, so the
            // same shape is pushed into SQL.
            select new GroupAggregate { Label = g.Key, Tonnes = (double)g.Sum(x => (x.GrossWeight ?? 0m) / 1000m) })
            .ToListAsync(cancellationToken);

        return Rank(grouped, take: 4);
    }

    // =================================================================
    // Outbound (export)
    // =================================================================

    private async Task<List<DashboardGroupDto>> GetExportCountriesAsync(int year, CancellationToken cancellationToken)
    {
        // Two deliberate differences from the inbound equivalent:
        //  1. It filters on User_Creation_Date, not IsAccepted_Date. So an export request
        //     created last year but accepted this year drops out, and vice versa.
        //  2. It reaches the line items directly (Ex_CheckRequest_Items.Ex_CheckRequest_ID),
        //     skipping the shipping-method table the inbound query goes through.
        // Both look like mistakes but changing them would change the published figures.
        List<GroupAggregate> grouped = await (
            from ex in _context.ExCheckRequests.AsNoTracking()
                .Where(a => a.IsAccepted == true && a.UserCreationDate.HasValue && a.UserCreationDate.Value.Year == year)
            join item in _context.ExCheckRequestItems.AsNoTracking() on ex.Id equals item.ExCheckRequestId
            join data in _context.ExCheckRequestData.AsNoTracking() on ex.Id equals data.ExCheckRequestId
            join country in _context.Countries.AsNoTracking() on data.ExportCountryId equals country.Id
            group item by country.ArName into g
            select new GroupAggregate { Label = g.Key, Tonnes = (double)(g.Sum(x => x.GrossWeight ?? 0m) / 1000m) })
            .ToListAsync(cancellationToken);

        return Rank(grouped, take: 5);
    }

    private async Task<List<DashboardGroupDto>> GetExportProductsAsync(int year, CancellationToken cancellationToken)
    {
        List<GroupAggregate> grouped = await (
            from ex in _context.ExCheckRequests.AsNoTracking()
                .Where(a => a.IsAccepted == true && a.UserCreationDate.HasValue && a.UserCreationDate.Value.Year == year)
            join item in _context.ExCheckRequestItems.AsNoTracking() on ex.Id equals item.ExCheckRequestId
            join variety in _context.ItemShortNames.AsNoTracking() on item.ItemShortNameId equals variety.Id
            group item by variety.ShortNameAr into g
            select new GroupAggregate { Label = g.Key, Tonnes = (double)g.Sum(x => (x.GrossWeight ?? 0m) / 1000m) })
            .ToListAsync(cancellationToken);

        return Rank(grouped, take: 4);
    }

    /// <summary>
    /// Intermediate projection: the group label plus the tonnage, unrounded.
    /// </summary>
    /// <remarks>
    /// Private and mutable purely so the LINQ query expressions above can construct it.
    /// Nothing outside this class sees it.
    /// </remarks>
    private sealed class GroupAggregate
    {
        public string? Label { get; set; }

        /// <summary>Unrounded tonnes. <see cref="Rank"/> does the rounding.</summary>
        public double Tonnes { get; set; }
    }

    /// <summary>
    /// Rounds, orders and truncates a grouped aggregate to the chart's top-N.
    /// </summary>
    /// <remarks>
    /// This has to run in memory. The legacy expressed the same idea as
    /// <c>orderby Math.Round((double)g.Sum(...))</c> inside the query, but <c>Math.Round</c>
    /// over a server-side aggregate is not translatable to SQL by any version of EF — it
    /// throws <c>NotSupportedException</c> at runtime rather than quietly returning wrong
    /// data. So the aggregate stays in SQL and only the rounding and ranking happen here.
    /// <para>
    /// <c>Math.Round</c> defaults to banker's rounding (to-even), which is what the legacy
    /// call resolved to, so the same overload semantics are kept. Ties on the rounded value
    /// are broken by the unrounded value so the top-N cut is deterministic rather than
    /// dependent on whatever order the database happened to return rows in.
    /// </para>
    /// </remarks>
    private static List<DashboardGroupDto> Rank(List<GroupAggregate> grouped, int take)
    {
        return grouped
            .OrderByDescending(g => Math.Round(g.Tonnes))
            .ThenByDescending(g => g.Tonnes)
            .ThenBy(g => g.Label, StringComparer.Ordinal)
            .Take(take)
            .Select(g => new DashboardGroupDto
            {
                Label = g.Label,
                TonnageTonnes = Math.Round(g.Tonnes),
            })
            .ToList();
    }
}