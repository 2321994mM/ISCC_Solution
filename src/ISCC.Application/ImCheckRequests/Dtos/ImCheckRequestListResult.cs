namespace ISCC.Application.ImCheckRequests.Dtos;

/// <summary>
/// One page of <c>List_ImCheckRequest_Data</c> output.
/// </summary>
/// <remarks>
/// <para>
/// The procedure always returns 25 rows per page — it reassigns <c>@PageSize</c> itself —
/// so the caller cannot change <see cref="PageSize"/>; it is informational, for building the
/// pager. <see cref="TotalCount"/> is the un-paged count the procedure computes on every
/// row via <c>COUNT_BIG(1) OVER ()</c>, so it is read from the first row.
/// </para>
/// <para>
/// The procedure does not project <c>Im_CheckRequest.Completion_Status</c>, so the completion
/// workflow for the rows on the page is read separately and carried here rather than on the row.
/// A property on <see cref="ImCheckRequestListRow"/> would have to be a column of the
/// procedure's result: EF Core's <c>SqlQueryRaw&lt;T&gt;</c> fails the read outright — "The
/// required column 'CompletionStatus' was not present" — when a property has no matching column.
/// </para>
/// <para>
/// 1 = the customer must complete the request, 2 = the customer edited it and it is waiting for
/// review. Only requests that are still undecided (<c>IsAccepted is null</c>) can appear.
/// </para>
/// </remarks>
public sealed record ImCheckRequestListResult(
    IReadOnlyList<ImCheckRequestListRow> Items,
    long TotalCount,
    int PageNumber,
    int PageSize,
    IReadOnlyDictionary<long, byte> CompletionStatus)
{
    /// <summary>The completion state of one request, or <c>null</c> when none is running.</summary>
    public byte? CompletionStatusOf(long imCheckRequestId) =>
        CompletionStatus.TryGetValue(imCheckRequestId, out var status) ? status : null;
}