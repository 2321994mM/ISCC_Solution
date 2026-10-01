namespace ISCC.Application.Menu.Dtos;

/// <summary>
/// What kind of entry a <see cref="MenuNode"/> represents.
/// </summary>
/// <remarks>
/// The level is stored on the node itself as well, but the kind is what callers branch on.
/// Keeping them separate means a consumer that only needs to know "is this clickable" does
/// not have to compare against a depth number, and a fourth level added to the RBAC tables
/// later would not silently change the meaning of the existing values.
/// </remarks>
public enum MenuNodeKind
{
    /// <summary>Top level, from <c>PR_Group</c>.</summary>
    Group,

    /// <summary>Middle level, from <c>PR_Module</c>.</summary>
    Module,

    /// <summary>Leaf, from <c>PR_Menu</c>.</summary>
    Leaf
}