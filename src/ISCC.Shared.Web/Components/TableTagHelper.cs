using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Describes one column of an <see cref="TableTagHelper"/>.
/// </summary>
/// <param name="Property">Name of the property read off each row.</param>
/// <param name="Header">Column heading text.</param>
/// <param name="Format">
/// Optional .NET custom format string, for example <c>N0</c> or <c>0.00</c>. The
/// composite spelling <c>{0:N0}</c> is also accepted and unwrapped for you.
/// </param>
/// <remarks>
/// <see cref="Format"/> is applied with the invariant culture, so a value never renders
/// as <c>[1,234]</c> inside markup regardless of the request culture.
/// </remarks>
public record TableColumn(string Property, string Header, string? Format = null);

/// <summary>
/// Renders a consistent data table: header, body, empty state and optional paging.
/// </summary>
/// <remarks>
/// <para>
/// The legacy views had 11 hand-written tables with no shared empty-state or paging
/// behaviour. This component makes all of them identical and makes the bilingual heading
/// text and RTL layout the default rather than something each page remembers.
/// </para>
/// <para>
/// Rows are read by property name via reflection. That is appropriate here because these
/// are read-only display tables, not editable grids.
/// </para>
/// <example>
/// <code>
/// &lt;iscc-table items="Model.Rows"
///              columns="@(new[] { new TableColumn("Name", "Name"), new TableColumn("Total", "Total", "N2") })"
///              empty-message="No records" show-pager="true" /&gt;
/// </code>
/// </example>
/// </remarks>
[HtmlTargetElement("iscc-table", TagStructure = TagStructure.WithoutEndTag)]
public class TableTagHelper : TagHelper
{
    /// <summary>
    /// The rows to render. A <see cref="IPagedResult"/> such as
    /// <c>PagedResult&lt;T&gt;</c> is also accepted, and its page metadata drives the
    /// pager.
    /// </summary>
    /// <remarks>
    /// Typed as the non-generic <see cref="IEnumerable"/> on purpose. A tag helper
    /// property cannot be generic, so this is the widest type a caller can pass and it
    /// still accepts a <c>List&lt;T&gt;</c>, an array, or any paged result.
    /// </remarks>
    public System.Collections.IEnumerable? Items { get; set; }

    /// <summary>Column definitions.</summary>
    public TableColumn[]? Columns { get; set; }

    /// <summary>Shown when there are no rows. Bilingual: pick by request culture.</summary>
    public string? EmptyMessage { get; set; }

    /// <summary>Arabic empty-state text, used when the request culture is Arabic.</summary>
    public string? EmptyMessageAr { get; set; }

    /// <summary>Whether to render the pager beneath the table.</summary>
    public bool ShowPager { get; set; }

    /// <summary>Extra CSS class on the wrapping element.</summary>
    public string? CssClass { get; set; }

    /// <summary>
    /// Unwraps a composite format string down to the plain custom format that
    /// <see cref="IFormattable.ToString(string, IFormatProvider)"/> actually wants.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>IFormattable.ToString</c> takes a <b>custom</b> format (<c>N0</c>, <c>N2</c>,
    /// <c>0.00</c>), not a <b>composite</b> one (<c>{0:N0}</c>). Passing the composite form
    /// does not throw, which is the problem: <c>36504m.ToString("{0:N0}")</c> silently
    /// returns the literal string <c>{3650:N4}</c>, because <c>{</c>, <c>:</c> and
    /// <c>}</c> are all valid literal characters in a custom numeric format and the
    /// digits get read as placeholders.
    /// </para>
    /// <para>
    /// So <c>{0:N0}</c> is the spelling most people reach for, and it fails in a way that
    /// looks like a data bug rather than a format bug. Accept both rather than make every
    /// caller learn the distinction.
    /// </para>
    /// </remarks>
    private static string NormalizeFormat(string format)
    {
        var trimmed = format.Trim();

        if (trimmed.Length < 4 || trimmed[0] != '{' || trimmed[^1] != '}')
        {
            return trimmed;
        }

        // Take the text after the first colon, which is the format item inside "{0:...}".
        var colon = trimmed.IndexOf(':');

        return colon >= 0 && colon < trimmed.Length - 1
            ? trimmed[(colon + 1)..^1]
            : trimmed;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var isArabic = string.Equals(
            System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
            "ar",
            StringComparison.OrdinalIgnoreCase);

        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("class", CssClass ?? "iscc-table-wrapper");

        // A paged result supplies both the rows and the page metadata, so the pager can
        // render without the caller restating them.
        var page = Items as IPagedResult;

        var rows = page is not null
            ? page.Items.Cast<object>().ToList()
            : Items?.Cast<object>().ToList() ?? new List<object>();

        var table = new TagBuilder("table");
        table.Attributes["class"] = "iscc-table";

        if (Columns is { Length: > 0 })
        {
            var thead = new TagBuilder("thead");
            var headerRow = new TagBuilder("tr");
            foreach (var column in Columns)
            {
                var th = new TagBuilder("th");
                th.InnerHtml.Append(System.Net.WebUtility.HtmlEncode(column.Header));
                headerRow.InnerHtml.AppendHtml(th);
            }
            thead.InnerHtml.AppendHtml(headerRow);
            table.InnerHtml.AppendHtml(thead);
        }

        var tbody = new TagBuilder("tbody");

        if (rows.Count == 0)
        {
            var message = isArabic ? (EmptyMessageAr ?? EmptyMessage) : EmptyMessage;
            message ??= isArabic ? "لا توجد سجلات" : "No records";
            var span = Columns is { Length: > 0 } ? Columns.Length : 1;
            tbody.InnerHtml.AppendHtml(
                $"<tr class=\"iscc-table__empty\"><td colspan=\"{span}\">{System.Net.WebUtility.HtmlEncode(message)}</td></tr>");
        }
        else if (Columns is { Length: > 0 })
        {
            foreach (var row in rows)
            {
                var tr = new TagBuilder("tr");
                foreach (var column in Columns)
                {
                    var property = row.GetType().GetProperty(column.Property);
                    var raw = property?.GetValue(row);

                    string text;
                    if (raw is null)
                    {
                        text = string.Empty;
                    }
                    else if (!string.IsNullOrEmpty(column.Format) && raw is IFormattable formattable)
                    {
                        // Invariant, so a comma decimal separator never produces
                        // "[1,234]" inside markup.
                        text = formattable.ToString(
                            NormalizeFormat(column.Format),
                            System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        text = raw.ToString() ?? string.Empty;
                    }

                    var td = new TagBuilder("td");
                    td.InnerHtml.Append(System.Net.WebUtility.HtmlEncode(text));
                    tr.InnerHtml.AppendHtml(td);
                }
                tbody.InnerHtml.AppendHtml(tr);
            }
        }

        table.InnerHtml.AppendHtml(tbody);
        output.PreContent.AppendHtml(table);

        if (ShowPager)
        {
            if (page is not null)
            {
                output.PreContent.AppendHtml(
                    PagerHtml.Render(page.Page, page.TotalPages, page.TotalCount, isArabic));
            }
            else if (rows.Count > 0)
            {
                // A plain list was supplied, so it is all one page. PagerHtml renders
                // nothing for a single page, so no control appears here.
                output.PreContent.AppendHtml(PagerHtml.Render(1, 1, rows.Count, isArabic));
            }
        }
    }
}
