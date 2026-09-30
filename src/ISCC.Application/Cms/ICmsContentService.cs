using ISCC.Application.Cms.Dtos;

namespace ISCC.Application.Cms;

/// <summary>
/// Read access to the CMS content in <c>dbo.WebsitetypeDetail</c> + <c>dbo.Websitetype</c>.
/// </summary>
/// <remarks>
/// Extracted because six legacy controllers (<c>Home</c>, <c>News</c>, <c>Offices</c>,
/// <c>AgricultureLaw</c>, and the admin CMS) issue near-identical queries against these
/// two tables, each instantiating its own <c>AgricultureDBContext</c>.
/// </remarks>
public interface ICmsContentService
{
    /// <summary>Builds the whole home page: slider, intro, news, adverts, alerts.</summary>
    Task<HomePageDto> GetHomePageAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// All active rows of one CMS section.
    /// </summary>
    /// <param name="sectionId">A <see cref="CmsSection"/> value.</param>
    /// <param name="filter">How to interpret the nullable IsActive column.</param>
    /// <param name="take">Maximum rows; <c>null</c> for all.</param>
    /// <param name="orderByDateDescending">Legacy ordered some sections and not others.</param>
    /// <param name="summaryLength">
    /// When set, <c>DescAr</c> is truncated to this many characters for list display.
    /// The legacy News list compared against 150 but truncated to 200.
    /// </param>
    Task<List<CmsContentItemDto>> GetBySectionAsync(
        int sectionId,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        int? take = null,
        bool orderByDateDescending = true,
        int? summaryLength = null,
        CancellationToken cancellationToken = default);

    /// <summary>A single content row, or <c>null</c> when absent or inactive.</summary>
    Task<CmsContentItemDto?> GetByIdAsync(
        int id,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        CancellationToken cancellationToken = default);

    /// <summary>Display name of a section, or <c>null</c> when absent or inactive.</summary>
    Task<CmsSectionDto?> GetSectionAsync(
        int sectionId,
        CmsActiveFilter filter = CmsActiveFilter.TrueOrNull,
        CancellationToken cancellationToken = default);
}