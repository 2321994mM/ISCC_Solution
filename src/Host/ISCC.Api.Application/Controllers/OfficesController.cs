using ISCC.Application.Cms;
using ISCC.Application.Cms.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// "Our offices" listing. Migrated from <c>Capqwebsite/Controllers/OfficesController.cs</c>.
/// </summary>
/// <remarks>
/// The legacy action hard-coded <c>WebsitetypeID == 12</c> and used
/// <c>IsActive == true</c> — unlike every other CMS controller, which also accepts NULL.
/// That stricter rule is preserved via <see cref="CmsActiveFilter.TrueOnly"/> so no
/// content disappears or appears during migration.
/// </remarks>
public class OfficesController : BaseController
{
    private readonly ICmsContentService _cms;

    public OfficesController(ICmsContentService cms, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _cms = cms;
    }

    [AllowAnonymous]
    [Route("/Offices/Index")]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        try
        {
            List<CmsContentItemDto> list = await _cms.GetBySectionAsync(
                CmsSection.Offices,
                CmsActiveFilter.TrueOnly,
                take: null,
                orderByDateDescending: false,
                summaryLength: null,
                cancellationToken);

            CmsSectionDto? section = await _cms.GetSectionAsync(
                CmsSection.Offices, CmsActiveFilter.TrueOnly, cancellationToken);

            ViewBag.TypeAr = section?.TypeAr;
            return View(list);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(OfficesController), nameof(Index), ex.Message);
            throw;
        }
    }
}