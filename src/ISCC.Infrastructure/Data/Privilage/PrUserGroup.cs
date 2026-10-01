namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// A user's membership of a group, from <c>dbPrivilage.PR_UserGroup</c>.
/// </summary>
/// <remarks>
/// <para>
/// This is the interesting table in the RBAC model: the CRUD flags are
/// <b>per membership</b>, not per group. One user in two groups can hold
/// <c>CanEdit</c> through one and not the other, so the effective permission is the
/// union across a user's active memberships.
/// </para>
/// <para>
/// Columns <see cref="CanView"/> through <see cref="CanPrint"/> are all nullable, so a
/// null must be treated as "not granted" rather than coerced to <c>true</c>. 134 rows
/// exist across 998 users, so most users have no group at all and fall back to the
/// authenticate-only behaviour.
/// </para>
/// </remarks>
public class PrUserGroup
{
    /// <summary>Surrogate key.</summary>
    public int Id { get; set; }

    /// <summary>The user. See <see cref="PrUser"/>.</summary>
    public short? PrUserId { get; set; }

    /// <summary>The group. See <see cref="PrGroup"/>.</summary>
    public int? PrGroupId { get; set; }

    /// <summary>Whether this membership is in force.</summary>
    public bool Active { get; set; }

    /// <summary>May read records.</summary>
    public bool? CanView { get; set; }

    /// <summary>May create records.</summary>
    public bool? CanAdd { get; set; }

    /// <summary>May modify records.</summary>
    public bool? CanEdit { get; set; }

    /// <summary>May delete records.</summary>
    public bool? CanDelete { get; set; }

    /// <summary>May print reports.</summary>
    public bool? CanPrint { get; set; }

    /// <summary>The user half of the relationship.</summary>
    public PrUser? User { get; set; }

    /// <summary>The group half of the relationship.</summary>
    public PrGroup? Group { get; set; }
}
