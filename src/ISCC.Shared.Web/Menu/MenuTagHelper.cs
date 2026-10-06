using System.Globalization;
using ISCC.Shared.Localization;
using ISCC.Shared.Web.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using DefaultTagHelperContent = Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent;

namespace ISCC.Shared.Web.Menu;

/// <summary>
/// Renders the navigation tree as nested markup, recursing into itself for each level.
/// </summary>
/// <remarks>
/// <para>
/// A tag helper rather than a set of partials. Partials are the obvious choice and they do
/// not work here: inside a view component result, <c>PartialAsync</c> resolves a bare name
/// against the <em>calling</em> controller's folder, not the component's own. Both of these
/// fail at runtime with "partial view not found":
/// </para>
/// <list type="bullet">
/// <item><c>&lt;partial name="_MenuList" /&gt;</c> — searched /Views/Home/ and /Views/Shared/</item>
/// <item><c>&lt;partial name="Views/Shared/Components/Menu/_MenuList" /&gt;</c> — the path was
/// appended to those same folders, giving /Views/Home/Views/Shared/...</item>
/// </list>
/// <para>
/// A tag helper has no path lookup at all: the tag is compiled in and resolved from DI, so
/// recursion is a method calling itself. It also removes two files whose entire content was a
/// loop and a partial call.
/// </para>
/// </remarks>
[HtmlTargetElement("iscc-menu", TagStructure = TagStructure.WithoutEndTag)]
public class MenuTagHelper : TagHelper
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    /// <summary>Creates the tag helper.</summary>
    /// <param name="localizer">Supplies the "not yet ported" and "expand" titles.</param>
    public MenuTagHelper(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    /// <summary>The nodes to render. Empty renders nothing at all.</summary>
    public IReadOnlyList<MenuItem> Items { get; set; } = Array.Empty<MenuItem>();

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;
        output.TagMode = TagMode.StartTagAndEndTag;

        RenderList(Items, output.Content);
    }

    /// <summary>
    /// Renders one <c>&lt;ul&gt;</c> and recurses into each child node.
    /// </summary>
    /// <param name="items">Nodes at this level.</param>
    /// <param name="target">Where the markup is appended.</param>
    private void RenderList(IReadOnlyList<MenuItem> items, TagHelperContent target)
    {
        if (items.Count == 0)
        {
            return;
        }

        // Each level's markup is built into its own buffer and appended as one unit, so
        // nested levels come out in document order regardless of how the recursion interleaves.
        var listContent = new DefaultTagHelperContent();

        foreach (var item in items)
        {
            RenderNode(item, listContent);
        }

        var list = new TagBuilder("ul");
        list.Attributes["class"] = "nav-tree";
        list.InnerHtml.AppendHtml(listContent);
        target.AppendHtml(list);
    }

    /// <summary>
    /// Renders one node: a leaf as a link or an inert span, a branch as a disclosure.
    /// </summary>
    /// <param name="item">The node.</param>
    /// <param name="target">Where the markup is appended.</param>
    private void RenderNode(MenuItem item, TagHelperContent target)
    {
        var node = new TagBuilder("li");
        node.Attributes["class"] = item.IsLeaf ? "nav-node nav-leaf" : "nav-node nav-branch";
        node.Attributes["data-level"] = item.Level.ToString(CultureInfo.InvariantCulture);
        node.Attributes["data-menu-id"] = item.MenuId.ToString(CultureInfo.InvariantCulture);

        // Lower-case, not .NET's "True"/"False": this value is read by stylesheet selectors
        // and by browser-side assertions, and "True" matches neither.
        node.Attributes["data-implemented"] = item.IsImplemented ? "true" : "false";

        if (item.IsLeaf)
        {
            RenderLeaf(item, node);
        }
        else if (item.Children.Count > 0)
        {
            RenderBranch(item, node);
        }
        else
        {
            RenderEmptyBranch(item, node);
        }

        target.AppendHtml(node);
    }

    /// <summary>
    /// Renders a leaf as a link.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Every leaf with a URL is a real link, whether or not its route exists yet.</b>
    /// This used to gate on <see cref="MenuItem.IsImplemented"/>, rendering unported areas
    /// as inert spans so clicking could not 404. That was the wrong trade: it made the menu
    /// unusable as a navigation surface for the sake of keeping the console clean, and the
    /// user asked to be able to reach every item.
    /// </para>
    /// <para>
    /// So an item whose area has not been ported now navigates and gets a 404 from the
    /// exception handler. That is a visible, recoverable failure and it tells you exactly
    /// what is missing — arguably more useful than a greyed-out label that says nothing
    /// beyond "not yet".
    /// </para>
    /// <para>
    /// <see cref="MenuItem.IsImplemented"/> is still emitted as <c>data-implemented</c> on
    /// the <c>&lt;li&gt;</c>, so the migration state is inspectable in the DOM and a test
    /// can assert against it. It just no longer decides whether the link exists.
    /// </para>
    /// </remarks>
    /// <param name="item">The leaf.</param>
    /// <param name="node">The enclosing list item.</param>
    private void RenderLeaf(MenuItem item, TagBuilder node)
    {
        // Blank URLs and bare anchors ("#foo" appears in PR_Menu for the older tab-style
        // screens) are not navigable targets, so those remain inert. Everything else links.
        if (!string.IsNullOrWhiteSpace(item.Href) && !item.Href.StartsWith('#'))
        {
            var link = new TagBuilder("a");
            link.Attributes["class"] = "nav-link";
            link.Attributes["href"] = item.Href;
            link.Attributes["data-menu-id"] = item.MenuId.ToString(CultureInfo.InvariantCulture);
            link.Attributes["data-implemented"] = item.IsImplemented ? "true" : "false";
            link.InnerHtml.AppendHtml(Text(item.Title));
            node.InnerHtml.AppendHtml(link);
            return;
        }

        var inert = new TagBuilder("span");
        inert.Attributes["class"] = "nav-link disabled";
        inert.Attributes["aria-disabled"] = "true";
        inert.Attributes["title"] = _localizer["Menu_NotPorted"];
        inert.InnerHtml.AppendHtml(Text(item.Title));
        node.InnerHtml.AppendHtml(inert);
    }

    /// <summary>
    /// Renders an implemented branch as a <c>&lt;details&gt;</c> disclosure.
    /// </summary>
    /// <remarks>
    /// <c>&lt;details&gt;</c>/<c>&lt;summary&gt;</c> is a real disclosure control: keyboard
    /// operable and announced as expanded or collapsed by a screen reader. The legacy markup
    /// was an <c>&lt;a href="#"&gt;</c> with a jQuery handler returning false — it looked like
    /// a link, took focus, and announced nothing when activated.
    /// </remarks>
    /// <param name="item">The branch.</param>
    /// <param name="node">The enclosing list item.</param>
    private void RenderBranch(MenuItem item, TagBuilder node)
    {
        var details = new TagBuilder("details");
        details.Attributes["class"] = "nav-group";

        // Top-level groups start open so the tree is usable immediately; deeper levels stay
        // closed so an account with a large menu does not get a sidebar several screens long.
        if (item.Level == 1)
        {
            details.Attributes["open"] = "open";
        }

        // data-implemented on the <li> reflects "does this subtree lead anywhere yet", which
        // the stylesheet can use to dim a branch whose leaves are all inert. It is kept even
        // though the branch still renders: it carries real information about migration state.

        var summary = new TagBuilder("summary");
        summary.Attributes["class"] = "nav-link nav-group-toggle";
        summary.Attributes["title"] = _localizer["Menu_Expand"];
        summary.InnerHtml.AppendHtml(Caret());
        summary.InnerHtml.AppendHtml(Text(item.Title));

        var children = new DefaultTagHelperContent();
        RenderList(item.Children, children);

        details.InnerHtml.AppendHtml(summary);
        details.InnerHtml.AppendHtml(children);
        node.InnerHtml.AppendHtml(details);
    }

    /// <summary>
    /// Renders a branch with nothing beneath it at all.
    /// </summary>
    /// <remarks>
    /// <b>A branch is never collapsed because its leaves are unported.</b> An earlier version
    /// of this renderer treated a branch as "implemented" only when some descendant resolved,
    /// and hid the rest behind a flat label. That made the whole tree collapse to three inert
    /// group names on day one, because no area is ported yet — which defeats the purpose.
    /// Rendering the full tree with inert leaves is what makes the menu useful during a
    /// migration: a user can see everything they have access to, and see which parts work.
    /// </remarks>
    /// <param name="item">The branch.</param>
    /// <param name="node">The enclosing list item.</param>
    private void RenderEmptyBranch(MenuItem item, TagBuilder node)
    {
        var inert = new TagBuilder("span");
        inert.Attributes["class"] = "nav-link disabled nav-group-empty";
        inert.Attributes["aria-disabled"] = "true";
        inert.InnerHtml.AppendHtml(Caret());
        inert.InnerHtml.AppendHtml(Text(item.Title));
        node.InnerHtml.AppendHtml(inert);
    }

    /// <summary>
    /// Wraps a label in its <c>nav-text</c> span, HTML-encoded.
    /// </summary>
    /// <remarks>
    /// Set through <c>TagBuilder.InnerHtml.Append</c>, which encodes, never
    /// <c>AppendHtml</c> on raw text. Titles come from the <c>PR_Menu</c>,
    /// <c>PR_Module</c> and <c>PR_Group</c> tables, which the application's own
    /// administrators can edit, and this code path must not be what turns one of those values
    /// into script.
    /// </remarks>
    /// <param name="title">The label.</param>
    /// <returns>The span.</returns>
    private static TagBuilder Text(string title)
    {
        var span = new TagBuilder("span");
        span.Attributes["class"] = "nav-text";
        span.InnerHtml.Append(title);
        return span;
    }

    /// <summary>
    /// Builds the disclosure caret.
    /// </summary>
    /// <remarks>
    /// Written as the HTML entity for a down-pointing small triangle rather than the literal
    /// character, so this file stays pure ASCII and cannot be corrupted by an editor that
    /// guesses the wrong encoding. A literal Arabic string in a source file has already caused
    /// one bug in this solution.
    /// </remarks>
    /// <returns>The caret span.</returns>
    private static TagBuilder Caret()
    {
        var caret = new TagBuilder("span");
        caret.Attributes["class"] = "nav-caret";
        caret.Attributes["aria-hidden"] = "true";

        // AppendHtml, not Append. Append HTML-encodes its argument, so writing the entity
        // "&#9662;" through it emits the literal text "&amp;#9662;" and the browser shows
        // those characters instead of a triangle. AppendHtml passes the entity through
        // untouched. Safe here because the value is a compile-time constant, never data.
        caret.InnerHtml.AppendHtml("&#9662;");
        return caret;
    }
}
