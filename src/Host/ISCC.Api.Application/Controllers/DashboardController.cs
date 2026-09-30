using ISCC.Application.Dashboard;
using ISCC.Application.Dashboard.Dtos;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Public statistics dashboard. Migrated from
/// <c>Capqwebsite/Controllers/dashBoardController.cs</c> (127 lines).
/// </summary>
/// <remarks>
/// The legacy class was named <c>dashBoardController</c> with a lowercase first letter and
/// carried no route attribute, so it only resolved via conventional routing at
/// <c>/dashBoard/dash</c>. The class name is normalised here and an explicit route pins the
/// URL, because the navigation menu links to <c>~/dashBoard/dash</c> by literal string.
/// <para>
/// The legacy <c>Index</c> action is deliberately not ported — see the remarks on
/// <see cref="Dash"/>.
/// </para>
/// </remarks>
public class DashboardController : BaseController
{
    private readonly IDashboardService _dashboard;

    public DashboardController(IDashboardService dashboard, IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _dashboard = dashboard;
    }

    /// <summary>The statistics dashboard.</summary>
    /// <remarks>
    /// The legacy controller also had an <c>Index</c> action returning
    /// <c>dbContext.WebsiteTypeDetails.ToList()</c> — the entire CMS section table, unfiltered,
    /// rendered through a 24-line view that polled itself every 60 seconds via
    /// <c>$.load(location.href + ' #refreshable-content &gt; *')</c>. Nothing in the solution
    /// references that route: the navigation menu links to <c>/dashBoard/dash</c>. It is
    /// dropped rather than ported, since porting it would mean carrying an unrouted
    /// full-table dump and a self-refreshing request loop into the new solution.
    /// </remarks>
    [AllowAnonymous]
    [Route("/dashBoard/dash")]
    public async Task<IActionResult> Dash(CancellationToken cancellationToken)
    {
        try
        {
            DashboardDto dashboard = await _dashboard.GetAsync(cancellationToken);
            return View("dash", dashboard);
        }
        catch (Exception ex)
        {
            LogErrorToDb(nameof(DashboardController), nameof(Dash), ex.Message);
            throw;
        }
    }
}