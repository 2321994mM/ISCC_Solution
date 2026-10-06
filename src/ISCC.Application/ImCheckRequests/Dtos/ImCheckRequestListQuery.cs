namespace ISCC.Application.ImCheckRequests.Dtos;

/// <summary>
/// The inputs of the "طلبات الفحص الحالية - وارد" search, as submitted by the form.
/// </summary>
/// <remarks>
/// Mirrors the parameter list of <c>List_ImCheckRequest_Data</c> plus the culture flag
/// that selects the procedure's language columns (<c>@long</c>). Every value is carried
/// explicitly because the procedure's parameters are all optional in name but the call
/// convention passes every one of them.
/// </remarks>
public sealed record ImCheckRequestListQuery(
    long OutletId,
    DateTime DateFrom,
    DateTime DateTo,
    int SelectApproveId,
    int FinalResultListId,
    string CheckRequestNumber,
    long CompanyId,
    int PageNumber,
    bool IsArabic);