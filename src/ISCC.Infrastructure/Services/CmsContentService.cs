using ISCC.Application.Cms;
using ISCC.Application.Cms.Dtos;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class CmsContentService : ICmsContentService
{
    private readonly PlantQuarantineDbContext _context;

    public CmsContentService(PlantQuarantineDbContext context)
    {
        _context = context;
    }

    public async Task<HomePageDto> GetHomePageAsync(CancellationToken cancellationToken = default)
    {
        // Legacy issued five separate queries here. They are issued sequentially below
        // rather than via Task.WhenAll: a single DbContext does not support concurrent
        // operations, so parallelism would throw.
        var page = new HomePageDto
        {
            // Section 9: legacy applied no ordering and no limit.
            Slider = await Project(Section(CmsSection.Slider, CmsActiveFilter.TrueOrNull), null, false, null)
                .ToListAsync(cancellationToken),

            // Section 11: ordered by Date desc, single row.
            Intro = await Project(Section(CmsSection.IntroductionOfMinistry, CmsActiveFilter.TrueOrNull), 1, true, null)
                .ToListAsync(cancellationToken),

            // Section 7: ordered by Date desc, 3 rows, description truncated to 100.
            News = await Project(Section(CmsSection.News, CmsActiveFilter.TrueOrNull), 3, true, 100)
                .ToListAsync(cancellationToken),

            // Section 8: ordered by Date desc, 3 rows, description NOT truncated.
            Advertisements = await Project(Section(CmsSection.Advertisment, CmsActiveFilter.TrueOrNull), 3, true, null)
                .ToListAsync(cancellationToken),

            // Section 10: legacy applied no ordering and no limit.
            Alerts = await Project(Section(CmsSection.Alerts, CmsActiveFilter.TrueOrNull), null, false, null)
                .ToListAsync(cancellationToken),
        };

        return page;
    }

    public async Task<List<CmsContentItemDto>> GetBySectionAsync(
        int sectionId,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        int? take = null,
        bool orderByDateDescending = true,
        int? summaryLength = null,
        CancellationToken cancellationToken = default)
    {
        var query = Project(Section(sectionId, filter), take, orderByDateDescending, summaryLength);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<CmsContentItemDto?> GetByIdAsync(
        int id,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        CancellationToken cancellationToken = default)
    {
        // Filter on the entity before projecting: the async LINQ operators that require
        // an entity type (FirstOrAsync et al.) do not apply to a projected DTO.
        var entity = await Section(null, filter)
            .Where(w => w.Id == id)
            .Select(w => (WebsiteTypeDetail?)w)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return null;

        return new CmsContentItemDto
        {
            Id = entity.Id,
            SectionId = entity.WebsitetypeId ?? 0,
            TitleAr = entity.TitleAr,
            TitleEn = entity.TitleEn,
            DescAr = entity.DescAr,
            DescEn = entity.DescEn,
            FilePath = entity.Filepath,
            LinkUrl = entity.LinkUrl,
            Date = entity.Date,
            UserCreationDate = entity.UserCreationDate,
        };
    }

    public async Task<CmsSectionDto?> GetSectionAsync(
        int sectionId,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Websitetypes.AsNoTracking();

        query = filter switch
        {
            CmsActiveFilter.TrueOnly => query.Where(w => w.IsActive == true),
            CmsActiveFilter.NotFalse => query.Where(w => w.IsActive != false),
            _ => query.Where(w => w.IsActive == true || w.IsActive == null),
        };

        return await query
            .Where(w => w.Id == sectionId)
            .Select(w => new CmsSectionDto { Id = w.Id, TypeAr = w.TypeAr, TypeEn = w.TypeEn })
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>Applies the legacy per-controller active rule. See <see cref="CmsActiveFilter"/>.</summary>
    private IQueryable<WebsiteTypeDetail> Section(int? sectionId, CmsActiveFilter filter)
    {
        var query = _context.WebsiteTypeDetails.AsNoTracking();

        query = filter switch
        {
            CmsActiveFilter.TrueOnly => query.Where(w => w.IsActive == true),
            CmsActiveFilter.NotFalse => query.Where(w => w.IsActive != false),
            _ => query.Where(w => w.IsActive == true || w.IsActive == null),
        };

        if (sectionId.HasValue)
            query = query.Where(w => w.WebsitetypeId == sectionId.Value);

        return query;
    }

    private static IQueryable<CmsContentItemDto> Project(
        IQueryable<WebsiteTypeDetail> query, int? take, bool orderByDateDescending, int? summaryLength)
    {
        if (orderByDateDescending)
            query = query.OrderByDescending(w => w.Date);

        if (take.HasValue)
            query = query.Take(take.Value);

        var projected = query.Select(w => new CmsContentItemDto
        {
            Id = w.Id,
            SectionId = w.WebsitetypeId ?? 0,
            TitleAr = w.TitleAr,
            TitleEn = w.TitleEn,
            DescAr = summaryLength.HasValue && w.DescAr != null && w.DescAr.Length > summaryLength.Value
                ? w.DescAr.Substring(0, summaryLength.Value)
                : w.DescAr,
            DescEn = summaryLength.HasValue && w.DescEn != null && w.DescEn.Length > summaryLength.Value
                ? w.DescEn.Substring(0, summaryLength.Value)
                : w.DescEn,
            FilePath = w.Filepath,
            LinkUrl = w.LinkUrl,
            Date = w.Date,
            UserCreationDate = w.UserCreationDate,
        });

        return projected;
    }
}