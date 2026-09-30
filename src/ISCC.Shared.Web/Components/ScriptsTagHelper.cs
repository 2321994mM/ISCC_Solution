using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Emits the script tags every portal needs: the shared component behaviour, and
/// optionally jQuery plus select2 when the page uses a searchable dropdown.
/// </summary>
/// <remarks>
/// <para>
/// Centralising this is what stops each portal from loading a different jQuery version.
/// The legacy tree carried jquery 3.4.1 and jquery 3.7.1 side by side in
/// <c>wwwroot/js</c>, plus a 1.2 MB <c>all.js</c> that was never loaded by a view.
/// </para>
/// <para>
/// Versions come from configuration so they can be pinned in one place. jQuery and
/// select2 are referenced from a CDN; for an intranet deployment that cannot reach the
/// internet, vendor them into <c>wwwroot/lib/</c> and point the settings at the local
/// paths instead.
/// </para>
/// <example>
/// <code>
/// &lt;iscc-scripts /&gt;
/// &lt;iscc-scripts jquery="false" /&gt;
/// </code>
/// </example>
/// </remarks>
[HtmlTargetElement("iscc-scripts", TagStructure = TagStructure.WithoutEndTag)]
public class ScriptsTagHelper : TagHelper
{
    /// <summary>Inject jQuery before select2. Required when any select2 is present.</summary>
    public bool Jquery { get; set; } = true;

    /// <summary>Inject select2 for searchable dropdowns.</summary>
    public bool Select2 { get; set; } = true;

    /// <summary>Inject the shared component behaviour script.</summary>
    public bool Components { get; set; } = true;

    /// <summary>jQuery version.</summary>
    public string JqueryVersion { get; set; } = "3.7.1";

    /// <summary>select2 version.</summary>
    public string Select2Version { get; set; } = "4.0.13";

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;
        output.TagMode = TagMode.StartTagAndEndTag;

        if (Jquery)
        {
            output.PreContent.AppendHtml(
                $"<script src=\"https://cdn.jsdelivr.net/npm/jquery@{JqueryVersion}/dist/jquery.min.js\"></script>");
        }

        if (Select2)
        {
            output.PreContent.AppendHtml(
                $"<script src=\"https://cdn.jsdelivr.net/npm/select2@{Select2Version}/dist/js/select2.min.js\"></script>");
        }

        if (Components)
        {
            output.PreContent.AppendHtml(
                "<script src=\"/_shared/iscc-components.js\"></script>");
        }
    }
}

/// <summary>
/// Emits the stylesheet link for the shared components.
/// </summary>
/// <remarks>
/// Structural CSS only: layout, spacing and the states a screen reader or keyboard user
/// depends on. Visual design stays with the portal theme, which is why these are
/// deliberately plain and easy to override.
/// </remarks>
[HtmlTargetElement("iscc-styles", TagStructure = TagStructure.WithoutEndTag)]
public class StylesTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.PreContent.AppendHtml(
            "<link rel=\"stylesheet\" href=\"/_shared/iscc-components.css\" />");
    }
}
