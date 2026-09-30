using ISCC.Application.Cms;
using ISCC.Application.Cms.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Web.Employers.Controllers;

/// <summary>
/// Legislation pages (agriculture law, ministerial decrees, pest lists).
/// Migrated from <c>Capqwebsite/Controllers/AgricultureLawController.cs</c>.
/// </summary>
/// <remarks>
/// The legacy action took the section id from the query string — the navigation calls it
/// with <c>?ID=1</c>, <c>?ID=2</c>, <c>?ID=3</c>, and <c>?ID=13</c> through <c>16</c>.
/// It used <c>IsActive != false</c>, a third distinct rule, preserved here as
/// <see cref="CmsActiveFilter.NotFalse"/>.
/// </remarks>
public class AgricultureLawController : BaseController
{
    private readonly ICmsContentService _cms;

    public AgricultureLawController(ICmsContentService cms, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _cms = cms;
    }

    [AllowAnonymous]
    [Route("/AgricultureLaw/Index")]
    public async Task<IActionResult> Index(int ID, CancellationToken cancellationToken)
    {
        try
        {
            List<CmsContentItemDto> list = await _cms.GetBySectionAsync(
                ID,
                CmsActiveFilter.NotFalse,
                take: null,
                orderByDateDescending: false,
                summaryLength: null,
                cancellationToken);

            CmsSectionDto? section = await _cms.GetSectionAsync(ID, CmsActiveFilter.NotFalse, cancellationToken);

            ViewBag.TypeAr = section?.TypeAr;
            ViewBag.SectionId = ID;

            return View(list);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(AgricultureLawController), nameof(Index), ex.Message);
            throw;
        }
    }
}