namespace ISCC.Application.Menu.Dtos;

/// <summary>
/// One node of the navigation tree. A node is a group, a module or a menu leaf, and the
/// whole tree is a recursive structure of these.
/// </summary>
/// <remarks>
/// <para>
/// <b>Deliberately one type rather than three.</b> The legacy system had a group model, a
/// module model and a leaf model, and rendered each from its own view. That forced the
/// nesting to be expressed through <c>@Html.Action</c> calls that re-entered MVC, which is
/// what made the menu cost 40–50 stored-procedure round trips per page view. A single
/// recursive type renders any depth with one loop and needs no per-level view.
/// </para>
/// <para>
/// Levels are distinguished by <see cref="NodeType"/> and by <see cref="Children"/> being
/// empty, not by the type.
/// </para>
/// </remarks>
public class MenuNode
{
    /// <summary>Depth in the tree: 1 group, 2 module, 3 leaf.</summary>
    public int Level { get; set; }

    /// <summary>Which kind of entry this is.</summary>
    public MenuNodeKind NodeType { get; set; }

    /// <summary>
    /// The underlying key. Overloaded: a group id, module id or <c>PR_Menu.Id</c> depending
    /// on <see cref="NodeType"/>. It is carried through so that per-feature authorization can
    /// later look up the permission row without re-reading the table.
    /// </summary>
    public int Id { get; set; }

    /// <summary>Label in the request culture, already resolved.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The label in the other language. Carried so a port can render a language toggle
    /// without a second query.
    /// </summary>
    public string? AlternateTitle { get; set; }

    /// <summary>
    /// Where the leaf navigates to, for leaves only. Null for groups and modules, which
    /// expand rather than navigate.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>Nested entries. Empty for a leaf.</summary>
    public List<MenuNode> Children { get; set; } = new();

    /// <summary>Leaf permission flags. Defaults are permissive because the table is.</summary>
    public bool CanView { get; set; } = true;

    /// <inheritdoc cref="CanView"/>
    public bool CanAdd { get; set; } = true;

    /// <inheritdoc cref="CanView"/>
    public bool CanEdit { get; set; } = true;

    /// <inheritdoc cref="CanView"/>
    public bool CanDelete { get; set; } = true;

    /// <inheritdoc cref="CanView"/>
    public bool CanPrint { get; set; } = true;
}