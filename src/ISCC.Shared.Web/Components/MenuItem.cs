namespace ISCC.Shared.Web.Components;

/// <summary>
/// One rendered entry in the navigation.
/// </summary>
/// <remarks>
/// Flat and self-contained rather than a tree of <c>MenuNode</c>: the renderer
/// (<see cref="Menu.MenuTagHelper"/>) recurses over <see cref="Children"/> and needs nothing
/// from an ancestor, so no back-references are required.
/// </remarks>
public class MenuItem
{
    /// <summary>Label, already localized for the request culture.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The <c>PR_Group</c>, <c>PR_Module</c> or <c>PR_Menu</c> key, depending on depth.
    /// </summary>
    public int MenuId { get; set; }

    /// <summary>Depth in the tree, 1 for a top-level group.</summary>
    /// <remarks>
    /// Set by <c>MenuViewComponent</c> as it walks down. Carried on the model rather than
    /// passed alongside it, so each recursive render call takes exactly one argument.
    /// </remarks>
    public int Level { get; set; } = 1;

    /// <summary>Whether this is a clickable leaf rather than an expandable branch.</summary>
    public bool IsLeaf { get; set; }

    /// <summary>
    /// The href for a leaf. Null for a branch, which expands rather than navigates.
    /// </summary>
    /// <remarks>
    /// Null rather than <c>"#"</c>. <c>"#"</c> is a real navigation to the top of the
    /// document, which is what the legacy layout used for group headers, and it breaks any
    /// in-page fragment a browser extension or a bookmark depends on.
    /// </remarks>
    public string? Href { get; set; }

    /// <summary>
    /// Whether this entry leads somewhere in this solution yet.
    /// </summary>
    /// <remarks>
    /// False for a leaf means its area has not been ported, so it renders inert. For a
    /// branch it means no descendant resolves — which no longer causes the branch to be
    /// hidden, only to be reported as leading nowhere.
    /// </remarks>
    public bool IsImplemented { get; set; }

    /// <summary>The view permission flag from the privilege row.</summary>
    /// <remarks>
    /// Carried but not yet acted on. The live data gives this no discriminating power —
    /// 8,415 of 8,418 privilege rows have every flag set, so filtering on it would hide
    /// nothing today. It is plumbed through now so that per-feature authorization has the
    /// data when it is built, rather than needing the menu to be re-plumbed then.
    /// </remarks>
    public bool CanView { get; set; } = true;

    /// <summary>Nested entries. Empty for a leaf.</summary>
    public List<MenuItem> Children { get; set; } = new();
}