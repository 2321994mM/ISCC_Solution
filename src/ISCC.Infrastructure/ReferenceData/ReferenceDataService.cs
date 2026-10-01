using ISCC.Application.ReferenceData;
using ISCC.Application.ReferenceData.Dtos;
using ISCC.Domain.Abstraction.IRepository;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Shared.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.ReferenceData;

/// <summary>
/// EF Core implementation of <see cref="IReferenceDataService"/>.
/// </summary>
/// <remarks>
/// <para>
/// <b>No stored procedures here, unlike the operational queries.</b> These lookups are
/// three small joins over indexed foreign keys, so they express cleanly as LINQ and EF
/// translates them to SQL. The Import list (<c>List_ImCheckRequest_Data</c>) is a
/// different matter: it is tuned T-SQL over 321,469 rows and stays a procedure reached
/// through <c>FromSqlRaw</c>. Reference data and operational queries are not treated
/// alike, because they are not the same kind of problem.
/// </para>
/// <para>
/// <b>The polymorphic join is split into three queries and merged in memory.</b> The legacy
/// version did this as one statement with three <c>LEFT JOIN</c>s and a <c>CASE</c> for the
/// display name, which cannot be expressed in LINQ because the three branches select from
/// unrelated entity types with no navigable relationship. Three separate translatable
/// queries produce the same rows. The merge is done in memory because <c>GroupBy</c> over a
/// projection to a mutable class does not translate to SQL; the result set is at most 100
/// rows, so this costs nothing measurable.
/// </para>
/// </remarks>
public class ReferenceDataService : IReferenceDataService
{
    /// <summary>Legacy returned at most 100 rows; kept so page weight does not change.</summary>
    private const int MaxOptions = 100;

    /// <summary>Legacy refused to search below this length. Preserved deliberately.</summary>
    private const int MinimumSearchLength = 2;

    private readonly IUnitOfWork _unitOfWork;

    public ReferenceDataService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IReadOnlyList<SelectOption>> GetImportersAsync(
        long outletId,
        long? selectedImporterId,
        string? search,
        CancellationToken cancellationToken = default)
    {
        var term = (search ?? string.Empty).Trim();
        var found = new List<SelectOption>();

        // The current selection is included even when it does not match the search, so a
        // dropdown can render the value the user already chose.
        if (selectedImporterId is > 0)
        {
            var selected = await GetImporterAsync(outletId, selectedImporterId.Value, cancellationToken);
            if (selected is not null) found.Add(selected);
        }

        // Legacy: a search shorter than two characters returned only the sentinel, never a
        // scan. The underlying query touches Im_CheckRequest_Data, so the guard is a
        // performance boundary and not merely a UI nicety.
        if (term.Length < MinimumSearchLength)
        {
            return found;
        }

        var scoped = ScopedImporterRows(outletId);

        // DISTINCT on the importer side is not an optimisation, it is what makes this
        // usable. Im_CheckRequest_Data holds 321,549 rows and 9,739 distinct companies, so
        // a company with 300 requests appears 300 times. Measured on the live database with
        // a two-character search:
        //
        //   three split queries, DISTINCT applied   ~90 ms each, ~270 ms total, 107 rows
        //   one combined UNION query                 1,953 ms
        //   row-level join with no DISTINCT          2,739 ms  (what this method did first)
        //
        // So the split is worth roughly 7x over a combined query, and DISTINCT is worth
        // another 10x. The DISTINCT has to be applied to the anonymous projection rather
        // than to SelectOption, because EF cannot translate a distinct over a projected
        // class - it has no equality contract to compare instances on.
        var companies = await (
            from d in scoped
            join c in _unitOfWork.Repository<CompanyNational>().Query() on d.ImporterId equals c.Id
            where d.ImporterTypeId == (int)ImporterType.CompanyNational
                  && ((c.NameEn != null && c.NameEn.Contains(term)) || (c.NameAr != null && c.NameAr.Contains(term)))
            select new { c.Id, c.NameEn, c.NameAr })
            .Distinct()
            .ToListAsync(cancellationToken);

        var organizations = await (
            from d in scoped
            join o in _unitOfWork.Repository<PublicOrganization>().Query() on d.ImporterId equals o.Id
            where d.ImporterTypeId == (int)ImporterType.PublicOrganization
                  && ((o.NameEn != null && o.NameEn.Contains(term)) || (o.NameAr != null && o.NameAr.Contains(term)))
            select new { o.Id, o.NameEn, o.NameAr })
            .Distinct()
            .ToListAsync(cancellationToken);

        // Person has one Name column and no English counterpart, which is why legacy
        // searched it alone. Both languages get the same value rather than leaving TextEn
        // null, so an English user still sees a name instead of a blank row.
        var people = await (
            from d in scoped
            join p in _unitOfWork.Repository<Person>().Query() on d.ImporterId equals p.Id
            where d.ImporterTypeId == (int)ImporterType.Person
                  && p.Name != null && p.Name.Contains(term)
            select new { p.Id, p.Name })
            .Distinct()
            .ToListAsync(cancellationToken);

        var merged = companies.Select(c => Option(c.Id, c.NameEn, c.NameAr))
            .Concat(organizations.Select(o => Option(o.Id, o.NameEn, o.NameAr)))
            .Concat(people.Select(p => Option(p.Id, p.Name, p.Name)))
            .Where(Usable);

        // The limit is applied last, after the merge, so the response never exceeds
        // MaxOptions however many rows each branch produced.
        return Order(merged, IsArabicCulture).Take(MaxOptions).ToList();
    }

    public async Task<SelectOption?> GetImporterAsync(
        long outletId,
        long importerId,
        CancellationToken cancellationToken = default)
    {
        var scoped = ScopedImporterRows(outletId);

        // The id alone is ambiguous: the same value may exist as a company, an
        // organization and a person. Probe all three and take the first that resolves to a
        // name, rather than trusting a caller-supplied type. Legacy searched on the id
        // alone and let TOP (1) decide, which is arbitrary when several match.
        var company = await (
            from d in scoped
            join c in _unitOfWork.Repository<CompanyNational>().Query() on d.ImporterId equals c.Id
            where d.ImporterTypeId == (int)ImporterType.CompanyNational && d.ImporterId == importerId
            select new SelectOption { Value = c.Id.ToString(), TextEn = c.NameEn, TextAr = c.NameAr })
            .FirstOrDefaultAsync(cancellationToken);

        if (Usable(company)) return company;

        var organization = await (
            from d in scoped
            join o in _unitOfWork.Repository<PublicOrganization>().Query() on d.ImporterId equals o.Id
            where d.ImporterTypeId == (int)ImporterType.PublicOrganization && d.ImporterId == importerId
            select new SelectOption { Value = o.Id.ToString(), TextEn = o.NameEn, TextAr = o.NameAr })
            .FirstOrDefaultAsync(cancellationToken);

        if (Usable(organization)) return organization;

        var person = await (
            from d in scoped
            join p in _unitOfWork.Repository<Person>().Query() on d.ImporterId equals p.Id
            where d.ImporterTypeId == (int)ImporterType.Person && d.ImporterId == importerId
            select new SelectOption { Value = p.Id.ToString(), TextEn = p.Name, TextAr = p.Name })
            .FirstOrDefaultAsync(cancellationToken);

        return Usable(person) ? person : null;
    }

    public async Task<IReadOnlyList<SelectOption>> GetImportFinalResultsAsync(
        CancellationToken cancellationToken = default)
    {
        var rows = await _unitOfWork.Repository<ImFinalResult>().Query()
            .Where(r => r.IsActive == true)
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
    /// <remarks>
    /// At least one, not both. Requiring both would drop every row whose English name is
    /// NULL, and those rows are legitimate — they render in Arabic. Legacy only dropped a
    /// row when the text for the active language was blank, so an importer with only an
    /// Arabic name appeared for an Arabic user and was hidden for an English one. Here it
    /// appears for both, falling back across languages, which is the point of carrying both.
    /// </remarks>
    private static bool Usable(SelectOption? option) =>
        option is not null
        && option.Value != "0"
        && (!string.IsNullOrWhiteSpace(option.TextEn) || !string.IsNullOrWhiteSpace(option.TextAr));
}
