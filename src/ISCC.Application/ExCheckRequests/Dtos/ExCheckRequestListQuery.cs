namespace ISCC.Application.ExCheckRequests.Dtos;

/// <summary>
/// The inputs of the "طلبات فحص الصادر" search, as submitted by the form.
/// </summary>
/// <remarks>
/// Mirrors the parameters the legacy chain passed down:
/// <c>userId</c> (PR_User id, for the station-membership filter), <c>Outlet_User_ID</c>
/// (the business outlet id), <c>SearchALL</c> (the request-number contains-filter) and
/// <c>CurrentPage</c>. Page size is fixed at 10 by the screen and lives in the service.
/// </remarks>
public sealed record ExCheckRequestListQuery(
    long UserId,
    long OutletId,
    string Search,
    int PageNumber);