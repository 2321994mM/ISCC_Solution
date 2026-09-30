using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Renders pagination on its own, for pages that do not use
/// <see cref="TableTagHelper"/>.
/// </summary>
/// <remarks>
/// The legacy views had 12 ad-hoc pager occurrences and 4 hand-rolled pagination blocks,
/// none of which agreed with each other. This is the single implementation.
/// </remarks>
/// <example>
/// <code>
/// &lt;iscc-pager page="Model.Page" total-pages="Model.TotalPages" total-count="Model.TotalCount" /&gt;
/// </code>
/// </example>
/// </remarks>
[HtmlTargetElement("iscc-pager", TagStructure = TagStructure.WithoutEndTag)]
public class PagerTagHelper : TagHelper
{
    /// <summary>Current 1-based page.</summary>
    public int Page { get; set; } = 1;

    /// <summary>Total pages.</summary>
    public int TotalPages { get; set; }

    /// <summary>Total row count.</summary>
    public int TotalCount { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var isArabic = string.Equals(
            System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
            "ar",
            StringComparison.OrdinalIgnoreCase);

        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("class", "iscc-pager-wrapper");

        var html = PagerHtml.Render(Page, TotalPages, TotalCount, isArabic);
        if (html.Length > 0)
        {
            output.PreContent.AppendHtml(html);
        }
    }
}
