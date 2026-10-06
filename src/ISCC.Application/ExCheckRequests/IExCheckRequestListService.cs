using ISCC.Application.ExCheckRequests.Dtos;

namespace ISCC.Application.ExCheckRequests;

/// <summary>
/// The "طلبات فحص الصادر" screen (menu 100): the outlet's export inspection requests,
/// reachable either by the user's examination stations or by the outlet itself.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>PlantQuar.WEB/Areas/Export_CheckRequest/Controllers/List_EXCheckRequestController</c>
/// chain: the WEB controller called <c>EX_CheckRequests_API</c>, which ran
/// <c>GetListWithPage_List_filter</c> over the <c>dbo.Ex_List</c> database view. The view is
/// the source of truth here too — it is a server-side VIEW with the four permission scopes
/// (outlet examination, station examination, outlet genshi, station genshi) pre-joined —
/// so the list stays a raw query over it, reached through <c>SqlQueryRaw&lt;T&gt;</c>.
/// </para>
/// <para>
/// Unlike the import screen there is no stored procedure, no date window and no status
/// dropdown: the legacy screen searched only by request number and paged ten rows at a
/// time. The four <c>CanView/CanAdd/CanEdit/CanDelete</c> session flags the WEB controller
/// read are <b>not</b> part of the query — <c>GetListWithPage_List_filter</c> ignores them
/// and scopes purely by station membership and outlet id.
/// </para>
/// </remarks>
public interface IExCheckRequestListService
{
    /// <summary>
    /// Runs the paged export-request search against <c>dbo.Ex_List</c>. Page size is always
    /// 10, matching the legacy screen.
    /// </summary>
    /// <param name="query">The user, outlet, optional request-number search and page.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<ExCheckRequestListResult> SearchAsync(ExCheckRequestListQuery query, CancellationToken cancellationToken);
}