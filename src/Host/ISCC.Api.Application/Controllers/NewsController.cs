using ISCC.Application.Cms;
using ISCC.Application.Cms.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// News and general CMS listing pages. Migrated from <c>Capqwebsite/Controllers/NewsController.cs</c>.
/// </summary>
/// <remarks>
/// Two fixes over the legacy code:
/// <list type="number">
///   <item>The list truncated descriptions by comparing against 150 but taking 200 characters.</item>
///   <item><c>RowDetail</c> dereferenced the row without a null check and threw a
///   NullReferenceException for an unknown id; it now returns 404.</item>
/// </list>
/// </remarks>
public class NewsController : BaseController
{
    /// <summary>Description length for list rows. Legacy intended 150 but used 200.</summary>
    private const int SummaryLength = 150;

    private readonly ICmsContentService _cms;

    public NewsController(ICmsContentService cms, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _cms = cms;
    }

    [AllowAnonymous]
    [Route("/News/Index")]
    public async Task<IActionResult> Index(int ID, CancellationToken cancellationToken)
    {
        try
        {
            List<CmsContentItemDto> list = await _cms.GetBySectionAsync(
                ID,
                CmsActiveFilter.TrueOrNull,
                take: null,
                orderByDateDescending: true,
                summaryLength: SummaryLength,
                cancellationToken);

            CmsSectionDto? section = await _cms.GetSectionAsync(ID, CmsActiveFilter.TrueOrNull, cancellationToken);
            ViewBag.TypeAr = section?.TypeAr;
            ViewBag.SectionId = ID;

            return View(list);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(NewsController), nameof(Index), ex.Message);
            throw;
        }
    }

    /// <summary>Single news/content item.</summary>
    [AllowAnonymous]
    public async Task<IActionResult> RowDetail(int ID, string? Type, CancellationToken cancellationToken)
    {
        try
        {
            CmsContentItemDto? row = await _cms.GetByIdAsync(ID, CmsActiveFilter.TrueOrNull, cancellationToken);
            if (row is null)
                return NotFound();

            ViewBag.TypeAr = Type;
            ViewBag.SectionId = row.SectionId;

            return View(row);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(NewsController), nameof(RowDetail), ex.Message);
            throw;
        }
    }
}