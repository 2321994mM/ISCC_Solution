namespace ISCC.Shared.Contracts;

/// <summary>
/// The non-generic face of <see cref="PagedResult{T}"/>.
/// </summary>
/// <remarks>
/// <para>
/// Tag helper and view component properties cannot be generic, so a component that
/// accepts paged data needs something it can accept at any row type. This is that
/// something.
/// </para>
/// <para>
/// <c>Items</c> is deliberately the non-generic <c>IEnumerable</c>, not
/// <c>IReadOnlyList&lt;object&gt;</c>. Covariance would not help: <c>IReadOnlyList&lt;out T&gt;</c>
/// only converts for reference types, so a page of a struct row could not satisfy an
/// object-typed member. <c>PagedResult&lt;T&gt;</c> therefore implements it explicitly.
/// </para>
/// </remarks>
public interface IPagedResult
{
    /// <summary>The rows for this page.</summary>
    /// <remarks>
    /// Fully qualified because bare <c>IEnumerable</c> binds to the generic
    /// <c>IEnumerable&lt;T&gt;</c> here: implicit usings bring in
    /// <c>System.Collections.Generic</c> but not <c>System.Collections</c>.
    /// </remarks>
    System.Collections.IEnumerable Items { get; }

    /// <summary>1-based page index, already clamped into range.</summary>
    int Page { get; }

    /// <summary>Rows per page.</summary>
    int PageSize { get; }

    /// <summary>Total rows matching the query, across all pages.</summary>
    int TotalCount { get; }

    /// <summary>Total number of pages. Zero when <see cref="TotalCount"/> is zero.</summary>
    int TotalPages { get; }
}

/// <summary>
/// A page of results plus the metadata a UI component needs to render pagination.
/// </summary>
/// <remarks>
/// Used by the shared table + pager components so paging is expressed once and rendered
/// identically in every portal.
/// </remarks>
/// <typeparam name="T">The row type.</typeparam>
public class PagedResult<T> : IPagedResult, System.Collections.IEnumerable, IEnumerable<T>
{
    /// <summary>The rows for this page.</summary>
    public IReadOnlyList<T> Items { get; set; } = Array.Empty<T>();

    /// <summary>
    /// The rows as a non-generic sequence, for consumers that cannot be generic.
    /// </summary>
    /// <remarks>
    /// Explicit rather than implicit because a property only satisfies an interface
    /// member when the return types match exactly, and <c>IReadOnlyList&lt;T&gt;</c> is not
    /// <c>IEnumerable</c> as far as the compiler is concerned.
    /// </remarks>
    System.Collections.IEnumerable IPagedResult.Items => Items;

    /// <summary>
    /// Enumerates the rows on this page, so a paged result can be used directly in a
    /// <c>foreach</c> or LINQ query without unwrapping it first.
    /// </summary>
    /// <remarks>
    /// Enumerates the current page only, never the whole result set. That is deliberate:
    /// a caller who wants every row should say so explicitly rather than get a silent
    /// full-table scan from something that looks like a small collection.
    /// </remarks>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc cref="System.Collections.IEnumerable.GetEnumerator" />
    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    /// <summary>1-based page index.</summary>
    public int Page { get; set; } = 1;

    /// <summary>Rows per page.</summary>
    public int PageSize { get; set; } = 25;

    /// <summary>Total rows matching the query, across all pages.</summary>
    public int TotalCount { get; set; }

    /// <summary>Total number of pages. Zero when <see cref="TotalCount"/> is zero.</summary>
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>Whether a previous page exists.</summary>
    public bool HasPrevious => Page > 1;

    /// <summary>Whether a next page exists.</summary>
    public bool HasNext => Page < TotalPages;

    /// <summary>Builds a page, clamping the page index into range.</summary>
    public static PagedResult<T> Create(IReadOnlyList<T> items, int page, int pageSize, int totalCount)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize must be greater than zero.");

        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var clamped = totalPages == 0 ? 1 : Math.Clamp(page, 1, totalPages);

        return new PagedResult<T>
        {
            Items = items,
            Page = clamped,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}
