namespace ISCC.Application.Cms;

/// <summary>
/// How <c>dbo.WebsitetypeDetail.IsActive</c> is interpreted.
/// </summary>
/// <remarks>
/// The legacy controllers do NOT agree on this, and the divergence is reproduced
/// verbatim so that migration does not change which rows are visible on screen:
/// <list type="bullet">
///   <item><see cref="TrueOrNull"/> — Home and News (<c>IsActive == true || IsActive == null</c>)</item>
///   <item><see cref="TrueOnly"/>  — Offices (<c>IsActive == true</c>, excludes NULL)</item>
///   <item><see cref="NotFalse"/>   — AgricultureLaw (<c>IsActive != false</c>)</item>
/// </list>
/// This is almost certainly accidental. Once Phase 2 is verified against production
/// content, all three should collapse to <see cref="TrueOrNull"/>.
/// </remarks>
public enum CmsActiveFilter
{
    /// <summary><c>IsActive == true || IsActive == null</c> — the most common legacy form.</summary>
    TrueOrNull,

    /// <summary><c>IsActive == true</c> — rows where IsActive is NULL are hidden.</summary>
    TrueOnly,

    /// <summary><c>IsActive != false</c>.</summary>
    NotFalse
}