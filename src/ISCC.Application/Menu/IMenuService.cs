using ISCC.Application.Menu.Dtos;

namespace ISCC.Application.Menu;

/// <summary>
/// Builds the navigation tree for a signed-in user from the <c>dbPrivilage</c> RBAC tables.
/// </summary>
public interface IMenuService
{
    /// <summary>
    /// Returns the groups, modules and menu leaves this user may reach.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Replaces three legacy stored procedures (<c>GetGroupsNameByUserAndApplication</c>,
    /// <c>GetModulNameByUserAndApplicationandGroup</c>, <c>GetMenuUser</c>), which were called
    /// per level and per parent through <c>@Html.Action</c> and so issued roughly 40–50
    /// round trips for a single page view. This is one query against
    /// <c>PR_GroupModuleMenuPrivilage</c>, which is the only table on the live path from a
    /// user to a menu.
    /// </para>
    /// <para>
    /// Visibility comes from the <em>existence</em> of a permission row, not from the flags on
    /// it. On the live data 8,415 of 8,418 rows grant everything, and the three that deny
    /// anything all belong to menu id 100 for one of two accounts — treating them as filters
    /// would silently remove a working export screen for those users.
    /// </para>
    /// </remarks>
    /// <param name="userId">The <c>PR_User.Id</c> of the signed-in account.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// The tree, ordered and localized. Empty when the account has no rows, which is a
    /// legitimate state and not an error.
    /// </returns>
    Task<IReadOnlyList<MenuNode>> GetMenuTreeAsync(
        short userId, CancellationToken cancellationToken = default);
}