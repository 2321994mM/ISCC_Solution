using System.Text;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Builds pagination markup. Shared by the table component and the standalone pager tag
/// helper so both render the same control.
/// </summary>
public static class PagerHtml
{
    /// <summary>How many numbered links to show around the current page.</summary>
    private const int Window = 2;

    /// <summary>Renders a pager, or nothing when a single page covers all rows.</summary>
    /// <param name="page">Current 1-based page.</param>
    /// <param name="totalPages">Total pages.</param>
    /// <param name="totalCount">Total rows, shown as a count.</param>
    /// <param name="isArabic">Whether to render Arabic labels.</param>
    public static string Render(int page, int totalPages, int totalCount, bool isArabic)
    {
        // One page needs no pager. Emitting a lone "1" would be noise.
        if (totalPages <= 1)
        {
            return string.Empty;
        }

        var previous = isArabic ? "السابق" : "Previous";
        var next = isArabic ? "التالي" : "Next";
        var of = isArabic ? "من" : "of";

        var sb = new StringBuilder();
        sb.Append("<nav class=\"iscc-pager\" role=\"navigation\" aria-label=\"pager\">");

        if (page > 1)
        {
            sb.Append($"<a class=\"iscc-pager__link\" href=\"?page={page - 1}\">&laquo; {previous}</a>");
        }

        for (var i = Math.Max(1, page - Window); i <= Math.Min(totalPages, page + Window); i++)
        {
            var current = i == page ? " iscc-pager__link--current" : string.Empty;
            sb.Append($"<a class=\"iscc-pager__link{current}\" href=\"?page={i}\">{i}</a>");
        }

        if (page < totalPages)
        {
            sb.Append($"<a class=\"iscc-pager__link\" href=\"?page={page + 1}\">{next} &raquo;</a>");
        }

        sb.Append($"<span class=\"iscc-pager__count\">{totalCount}</span>");
        sb.Append("</nav>");
        return sb.ToString();
    }
}
