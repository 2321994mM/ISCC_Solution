using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Renders a select that becomes a searchable, optionally AJAX-backed dropdown.
/// </summary>
/// <remarks>
/// <para>
/// This is the component the legacy code duplicated by hand. The old
/// <c>ImportingProcedure/Index.cshtml</c> and <c>ExportingProcedure/Index.cshtml</c> each
/// carried their own inline <c>$.ajax</c> cascade plus <c>.prop("disabled")</c> /
/// <c>.trigger("change.select2")</c> bookkeeping, roughly 60 lines of near-identical
/// script per page. Here the behaviour is declared as attributes and driven by one
/// script, so a cascading dropdown is two attributes rather than a script block.
/// </para>
/// <para>
/// Requires select2 on the page. Included via <c>&lt;iscc-scripts /&gt;</c>, which also
/// supplies the behaviour script.
/// </para>
/// <para>
/// Markup structure only; select2 supplies its own presentation.
/// </para>
/// <example>
/// A plain searchable dropdown:
/// <code>
/// &lt;iscc-select2 asp-for="Input.CountryId" asp-items="Model.Countries" label="Country" /&gt;
/// </code>
/// A cascading dropdown that loads its options from the server once a parent is chosen:
/// <code>
/// &lt;iscc-select2 asp-for="Input.ItemId" label="Item"
///                depends-on="ImInitiatorListId"
///                ajax-url="/ImportingProcedure/GetItemsByInitiator"
///                ajax-param="ImInitiatorID" /&gt;
/// </code>
/// </example>
/// </remarks>
[HtmlTargetElement("iscc-select2", TagStructure = TagStructure.WithoutEndTag)]
public class Select2TagHelper : TagHelper
{
    /// <summary>Model expression for the selected value. Also supplies name and id.</summary>
    [HtmlAttributeName("asp-for")]
    public ModelExpression? For { get; set; }

    /// <summary>Options to render up front. Omit when using <see cref="AjaxUrl"/>.</summary>
    [HtmlAttributeName("asp-items")]
    public IEnumerable<SelectListItem>? Items { get; set; }

    /// <summary>Label text.</summary>
    public string? Label { get; set; }

    /// <summary>Placeholder shown when nothing is selected.</summary>
    public string? Placeholder { get; set; }

    /// <summary>Enables the clear (x) affordance.</summary>
    public bool AllowClear { get; set; } = true;

    /// <summary>Number of keystrokes before an AJAX-backed search fires.</summary>
    public int MinimumSearchLength { get; set; } = 2;

    /// <summary>
    /// Id of the parent control this one depends on. When set, the options are reloaded
    /// from <see cref="AjaxUrl"/> whenever the parent's value changes, and the control is
    /// disabled while loading.
    /// </summary>
    public string? DependsOn { get; set; }

    /// <summary>Endpoint that returns options for an AJAX-backed or cascading select.</summary>
    public string? AjaxUrl { get; set; }

    /// <summary>
    /// Name of the query-string parameter carrying the parent value, for example
    /// <c>ImInitiatorID</c>.
    /// </summary>
    public string? AjaxParam { get; set; }

    /// <summary>Renders a disabled control.</summary>
    public bool Disabled { get; set; }

    /// <summary>Marks the control required.</summary>
    public bool Required { get; set; }

    /// <summary>Extra CSS classes for the underlying <c>&lt;select&gt;</c>.</summary>
    public string? CssClass { get; set; }

    /// <summary>Extra HTML attributes.</summary>
    [HtmlAttributeNotBound]
    public IDictionary<string, object?> AdditionalAttributes { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Reads an attribute that may not be present.
    /// </summary>
    /// <remarks>
    /// Indexing <see cref="TagHelperAttributeList"/> with a missing name throws, so the
    /// lookup has to be probed.
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
        select.Attributes["class"] = CssClass ?? "iscc-select iscc-select2";
        select.Attributes["data-iscc-select2"] = "true";

        if (id is not null)
        {
            select.Attributes["id"] = id;
            select.Attributes["data-iscc-select2-for"] = id;
        }
        if (name is not null) select.Attributes["name"] = name;
        if (Required) select.Attributes["required"] = "required";
        if (Disabled) select.Attributes["disabled"] = "disabled";

        if (!string.IsNullOrWhiteSpace(Placeholder))
        {
            select.Attributes["data-placeholder"] = Placeholder;
        }
        if (AllowClear) select.Attributes["data-allow-clear"] = "true";
        if (AjaxUrl is not null) select.Attributes["data-ajax-url"] = AjaxUrl;
        if (AjaxParam is not null) select.Attributes["data-ajax-param"] = AjaxParam;
        if (DependsOn is not null) select.Attributes["data-depends-on"] = DependsOn;
        if (MinimumSearchLength > 0) select.Attributes["data-minimum-search-length"] = MinimumSearchLength.ToString();

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
