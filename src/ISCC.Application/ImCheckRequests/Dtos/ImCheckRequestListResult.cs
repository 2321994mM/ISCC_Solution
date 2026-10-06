namespace ISCC.Application.ImCheckRequests.Dtos;

/// <summary>
/// One page of <c>List_ImCheckRequest_Data</c> output.
/// </summary>
/// <remarks>
/// The procedure always returns 25 rows per page — it reassigns <c>@PageSize</c> itself —
/// so the caller cannot change <see cref="PageSize"/>; it is informational, for building the
/// pager. <see cref="TotalCount"/> is the un-paged count the procedure computes on every
/// row via <c>COUNT_BIG(1) OVER ()</c>, so it is read from the first row.
/// </remarks>
public sealed record ImCheckRequestListResult(
    IReadOnlyList<ImCheckRequestListRow> Items,
    long TotalCount,
    int PageNumber,
    int PageSize);