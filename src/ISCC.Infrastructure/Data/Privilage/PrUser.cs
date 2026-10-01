namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// A staff account, from <c>dbPrivilage.PR_User</c>.
/// </summary>
/// <remarks>
/// <para>
/// Hand-written rather than scaffolded. The legacy repository used an EF6 EDMX
/// (<c>Privilages.DAL/Model1.edmx</c>, 101 KB) against this database, and
/// <c>PlantQuarantineDbContext</c> deliberately does not cover it: this is a
/// <b>separate database</b>, reached through its own connection string.
/// </para>
/// <para>
/// Only the columns auth actually reads are mapped. Scaffolding the whole database
/// would pull in <c>PR_Menu</c> (221 rows), <c>PR_Module</c> (55),
/// <c>PR_GroupModuleMenu</c> (194) and <c>PR_GroupModuleMenuPrivilage</c> (8,418),
/// none of which are consulted yet. They get mapped when per-area privilege
/// enforcement lands, in the area that needs them.
/// </para>
/// <para>
/// <b>Password is plaintext and stays that way.</b> See
/// <c>docs/PHASE2-AUTH-DESIGN.md</c> decision 1. The property is named
/// <see cref="PlaintextPassword"/> rather than <c>Password</c> specifically so that a
/// future hashing migration has to do a deliberate rename across every call site
/// instead of silently continuing to compare plaintext.
/// </para>
/// </remarks>
public class PrUser
{
    /// <summary>Surrogate key. <c>smallint</c>, no identity.</summary>
    public short Id { get; set; }

    /// <summary>Login name. Unique in practice, not enforced by a constraint.</summary>
    public string? LoginName { get; set; }

    /// <summary>
    /// Stored password, plaintext. Never log this value, never put it in an
    /// <c>Exception</c> message, and never return it from a controller.
    /// </summary>
    public string? PlaintextPassword { get; set; }

    /// <summary>Display name, Arabic.</summary>
    public string? FullName { get; set; }

    /// <summary>Display name, English.</summary>
    public string? FullNameEn { get; set; }

    /// <summary>Email address.</summary>
    public string? Email { get; set; }

    /// <summary>Job title, free text.</summary>
    public string? JobTitleName { get; set; }

    /// <summary>Date the account was registered.</summary>
    public DateOnly? RegisterationDate { get; set; }

    /// <summary>Date of the last successful login.</summary>
    public DateOnly? LastLoginDate { get; set; }

    /// <summary>
    /// Whether the account may sign in. All 998 rows are currently <c>1</c>.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>Directorate this account belongs to.</summary>
    public short? DomainLKDirectorateId { get; set; }

    /// <summary>HR employee number.</summary>
    public long EmpId { get; set; }

    /// <summary>
    /// Link to <c>PlantQuarantine_New.Outlet.ID_HR</c>, the HR identifier of the outlet
    /// this account works at. Used to enrich the signed-in principal with outlet details.
    /// </summary>
    public long? OutletId { get; set; }

    /// <summary>
    /// Whether the user has completed a forced password change. The legacy login
    /// rejects the account outright when this is false.
    /// </summary>
    public bool? IsChangePassword { get; set; }

    /// <summary>Address, Arabic.</summary>
    public string? AdressAr { get; set; }

    /// <summary>Address, English.</summary>
    public string? AdressEn { get; set; }

    /// <summary>Home telephone.</summary>
    public string? TelHome { get; set; }

    /// <summary>Mobile telephone.</summary>
    public string? TelMobil { get; set; }

    /// <summary>Group memberships carrying this user's CRUD flags.</summary>
    public ICollection<PrUserGroup> UserGroups { get; set; } = new List<PrUserGroup>();
}
