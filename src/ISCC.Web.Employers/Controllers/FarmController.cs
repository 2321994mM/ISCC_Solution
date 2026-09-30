using ISCC.Application.ReferenceData;
using ISCC.Application.ReferenceData.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Web.Employers.Controllers;

/// <summary>
/// Suspended farms lookup. Migrated from <c>Capqwebsite/Controllers/FarmController.cs</c>.
/// </summary>
/// <remarks>
/// Legacy behaviour preserved: when <c>FarmCode</c> is absent the query still ran and
/// returned every row in <c>FarmStop</c>. Callers always pass a code, so this is
/// harmless, but it is preserved rather than "fixed" to avoid changing result sets.
/// </remarks>
public class FarmController : BaseController
{
    private readonly IReferenceDataService _referenceData;

    public FarmController(IReferenceDataService referenceData, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _referenceData = referenceData;
    }

    [AllowAnonymous]
    [Route("/Farm/Index")]
    public async Task<IActionResult> Index(string? FarmCode, CancellationToken cancellationToken)
    {
        try
        {
            List<FarmStopDto> farms = await _referenceData.GetFarmStopsAsync(FarmCode, cancellationToken);
            return View(farms);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(FarmController), nameof(Index), ex.Message);
            throw;
        }
    }
}