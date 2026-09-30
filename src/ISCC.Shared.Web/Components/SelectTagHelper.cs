using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Renders a consistent labelled <c>&lt;select&gt;</c> across all portals.
/// </summary>
/// <remarks>
/// <para>
/// Use this instead of a hand-rolled select so the label, name, id, validation attributes
/// and placeholder are always generated identically. For the searchable, AJAX-backed
/// variant use <see cref="Select2TagHelper"/>.
/// </para>
/// <para>
/// Emits markup structure only, no styling, so existing portal CSS keeps working and a
/// future design change does not touch this file.
/// </para>
/// <example>
/// <code>
/// &lt;iscc-select asp-for="Input.CountryId" asp-items="Model.Countries"
///                label="Country" placeholder="-- select --" required="true" /&gt;
/// </code>
/// </example>
/// </remarks>
[HtmlTargetElement("iscc-select", TagStructure = TagStructure.WithoutEndTag)]
public class SelectTagHelper : TagHelper
{
    /// <summary>Model expression for the selected value. Also supplies name and id.</summary>
    [HtmlAttributeName("asp-for")]
    public ModelExpression? For { get; set; }

    /// <summary>The options to render.</summary>
    [HtmlAttributeName("asp-items")]
    public IEnumerable<SelectListItem>? Items { get; set; }

    /// <summary>Label text. Rendered above the control.</summary>
    public string? Label { get; set; }

    /// <summary>Placeholder option text. Rendered as an empty-valued first option.</summary>
    public string? Placeholder { get; set; }

    /// <summary>Marks the control required and adds the validation attribute.</summary>
    public bool Required { get; set; }

    /// <summary>Renders a disabled control.</summary>
    public bool Disabled { get; set; }

    /// <summary>Extra CSS classes for the <c>&lt;select&gt;</c> itself.</summary>
    public string? CssClass { get; set; }

    /// <summary>Extra HTML attributes for the <c>&lt;select&gt;</c>.</summary>
    [HtmlAttributeNotBound]
    public IDictionary<string, object?> AdditionalAttributes { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Reads an attribute that may not be present.
    /// </summary>
    /// <remarks>
    /// Indexing <see cref="TagHelperAttributeList"/> with a missing name throws, so the
    /// lookup has to be probed. Getting this wrong makes any <c>&lt;iscc-select&gt;</c>
    /// without a <c>name</c> attribute fail with a 500 at render time.
    /// </remarks>
    private static string? ReadAttribute(TagHelperContext context, string attributeName) =>
        context.AllAttributes.TryGetAttribute(attributeName, out var attribute)
            ? attribute.Value?.ToString()
            : null;

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var id = For?.Name ?? ReadAttribute(context, "id");
        var name = For?.Name ?? ReadAttribute(context, "name");

        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("class", "iscc-field");

        if (!string.IsNullOrWhiteSpace(Label))
        {
            output.PreContent.AppendHtml("<label class=\"iscc-field__label\"");
            if (id is not null) output.PreContent.AppendHtml($" for=\"{id}\"");
            output.PreContent.Append(">");
            output.PreContent.Append(Label);
            output.PreContent.Append("</label>");
        }

        var select = new TagBuilder("select");
        select.Attributes["class"] = CssClass ?? "iscc-select";
        if (name is not null) select.Attributes["name"] = name;
        if (id is not null) select.Attributes["id"] = id;
        if (Required) select.Attributes["required"] = "required";
        if (Disabled) select.Attributes["disabled"] = "disabled";

        foreach (var kv in AdditionalAttributes)
        {
            // TagBuilder attribute values are objects, but string is the only type that
            // renders usefully, so an int or bool would emit its type name otherwise.
            if (kv.Value is not null)
            {
                select.Attributes[kv.Key] = Convert.ToString(kv.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        var selectedValue = For?.Model?.ToString();

        if (!string.IsNullOrWhiteSpace(Placeholder))
        {
            var isSelected = string.IsNullOrEmpty(selectedValue) ? " selected=\"selected\"" : string.Empty;
            select.InnerHtml.AppendHtml(
                $"<option value=\"\"{isSelected}>{System.Net.WebUtility.HtmlEncode(Placeholder)}</option>");
        }

        if (Items is not null)
        {
            foreach (var item in Items)
            {
                var selected = string.Equals(item.Value, selectedValue, StringComparison.Ordinal)
                    ? " selected=\"selected\""
                    : string.Empty;
                var disabled = item.Disabled ? " disabled=\"disabled\"" : string.Empty;
                select.InnerHtml.AppendHtml(
                    $"<option value=\"{System.Net.WebUtility.HtmlEncode(item.Value)}\"{selected}{disabled}>" +
                    $"{System.Net.WebUtility.HtmlEncode(item.Text)}</option>");
            }
        }

        output.PreContent.AppendHtml(select);
    }
}
