namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// Per-user, per-group, per-module, per-menu permission flags.
/// From <c>dbPrivilage.PR_GroupModuleMenuPrivilage</c>.
/// </summary>
/// <remarks>
/// <para>
/// <b>This table, not <c>PR_UserGroup</c>, is what filters the menu.</b> All six of the
/// legacy query usages of <c>PR_UserGroup</c> are commented out, including the ones in the
/// group query itself, and the <c>PR_User_id</c> foreign key here is the only live path from
/// a user to a menu. The legacy menus therefore came from direct user-to-menu rows.
/// </para>
/// <para>
/// The flags are read-only decoration in practice. Measured on the live table: of 8,418
/// rows, exactly <b>3</b> deny anything, all three for <c>PR_MenuId = 100</c> (List of Export
/// Request) and all three belonging to one of two accounts. One further row has every key
/// NULL and every flag 0. So the de-facto rule is "a row existing means you get it", which
/// is why this port treats presence as visibility and carries the flags alongside for the
/// per-feature authorization work rather than filtering on them here.
/// </para>
/// <para>
/// <see cref="CanPrint"/> is the only nullable flag, which is why the legacy callers had to
/// write <c>CanPrint == null || CanView == true</c> to avoid a null comparison.
/// </para>
/// </remarks>
public class PrGroupModuleMenuPrivilage
{
    /// <summary>Surrogate key. Not an identity column in the database.</summary>
    public int Id { get; set; }

    /// <summary>Group the permission applies within. Nullable, and NULL in 1 orphan row.</summary>
    public int? PrGroupId { get; set; }

    /// <summary>Module the permission applies within. Nullable, and NULL in 1 orphan row.</summary>
    public int? PrModuleId { get; set; }

    /// <summary>Menu the permission applies to. Nullable, and NULL in 1 orphan row.</summary>
    public int? PrMenuId { get; set; }

    /// <summary>Whether the entry may be viewed.</summary>
    public bool CanView { get; set; }

    /// <summary>Whether the entry may be added to.</summary>
    public bool CanAdd { get; set; }

    /// <summary>Whether the entry may be edited.</summary>
    public bool CanEdit { get; set; }

    /// <summary>Whether the entry may be deleted.</summary>
    public bool CanDelete { get; set; }

    /// <summary>Whether the entry may be printed. The one nullable flag.</summary>
    public bool? CanPrint { get; set; }

    /// <summary>
    /// Owning account. <c>smallint</c>, matching <c>PR_User.Id</c>.
    /// </summary>
    public short? PrUserId { get; set; }

    /// <summary>Whether the row is in effect. One row of 8,418 is inactive.</summary>
    public bool? IsActive { get; set; }
}