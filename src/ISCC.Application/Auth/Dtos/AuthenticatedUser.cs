namespace ISCC.Application.Auth.Dtos;

/// <summary>
/// A staff account that has successfully authenticated, with the outlet it belongs to.
/// </summary>
/// <remarks>
/// <para>
/// Deliberately has <b>no password property</b>. The credential is used to match the row
/// and then discarded; keeping it on this object would put a plaintext staff password into
/// a session, a view model and potentially a log. <c>PR_User.PlaintextPassword</c> is
/// named to make the same point from the other side.
/// </para>
/// <para>
/// The outlet fields are populated from a second database. They are nullable and default
/// to empty because 64 of the 998 live accounts have no <c>Outlet_ID</c> — a central
/// administrator with no outlet is legitimate, and the login must not fail for one.
/// </para>
/// </remarks>
public class AuthenticatedUser
{
    /// <summary><c>PR_User.Id</c>. Also the <c>NameIdentifier</c> claim.</summary>
    public short UserId { get; set; }

    /// <summary>The login name as typed, trimmed.</summary>
    public string LoginName { get; set; } = string.Empty;

    /// <summary>Display name in Arabic, from <c>PR_User.FullName</c>.</summary>
    public string FullNameAr { get; set; } = string.Empty;

    /// <summary>Display name in English, from <c>PR_User.FullNameEn</c>.</summary>
    public string FullNameEn { get; set; } = string.Empty;

    /// <summary>
    /// <c>PR_User.EmpId</c>, the link to the employee record in the main database.
    /// </summary>
    public long EmpId { get; set; }

    /// <summary>
    /// <c>PR_User.Outlet_ID</c>, which is an HR outlet id, not the <c>Outlet.ID</c> primary
    /// key. Null for central staff.
    /// </summary>
    /// <remarks>
    /// Two different ids for one concept, and the naming hides it. <c>Outlet_ID_HR</c> is
    /// what <c>PR_User</c> stores; <c>Outlet.ID</c> is what the business tables reference.
    /// The translation happens in the outlet lookup. Confusing the two silently returns the
    /// wrong outlet rather than failing.
    /// </remarks>
    public long? OutletHrId { get; set; }

    /// <summary><c>Outlet.ID</c>, resolved from <see cref="OutletHrId"/>. Null when unresolved.</summary>
    public long? OutletId { get; set; }

    /// <summary>Outlet name in Arabic.</summary>
    public string OutletNameAr { get; set; } = string.Empty;

    /// <summary>Outlet name in English.</summary>
    public string OutletNameEn { get; set; } = string.Empty;

    /// <summary>Outlet type name in Arabic, from <c>A_SystemCode.ValueName</c>.</summary>
    public string OutletTypeAr { get; set; } = string.Empty;

    /// <summary>Outlet type name in English, from <c>A_SystemCode.ValueNameEn</c>.</summary>
    public string OutletTypeEn { get; set; } = string.Empty;

    /// <summary>
    /// <c>Outlet.IsExport</c>, which is an <c>A_SystemCode</c> id: 1 = Local, 81 = Import,
    /// 82 = All. Null when the outlet did not resolve.
    /// </summary>
    public int? OutletTypeId { get; set; }

    /// <summary>
    /// <c>PR_User.IS_Change_Password</c>: whether this account has completed its first
    /// password change.
    /// </summary>
    /// <remarks>
    /// <b>True for only 458 of 998 live accounts</b> — 492 are NULL and 48 are 0. Read and
    /// carried, but not enforced by default; see <c>AuthOptions.RequirePasswordChange</c>
    /// for why.
    /// </remarks>
    public bool IsPasswordChanged { get; set; }
}
