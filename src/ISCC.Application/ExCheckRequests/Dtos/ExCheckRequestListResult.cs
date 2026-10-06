namespace ISCC.Application.ExCheckRequests.Dtos;

/// <summary>
/// One page of the <c>dbo.Ex_List</c> output.
/// </summary>
/// <remarks>
/// The screen always pages ten rows (<see cref="PageSize"/> is informational, for building
/// the pager). <see cref="TotalCount"/> is the un-paged count, computed on every row via
/// <c>COUNT_BIG(1) OVER ()</c> before the <c>OFFSET/FETCH</c> applies, so it is read from
/// the first row — the same shape the import screen's procedure uses.
/// </remarks>
public sealed record ExCheckRequestListResult(
    IReadOnlyList<ExCheckRequestListRow> Items,
    long TotalCount,
    int PageNumber,
    int PageSize);