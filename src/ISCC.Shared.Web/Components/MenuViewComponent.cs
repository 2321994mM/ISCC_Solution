using System.Security.Claims;
using ISCC.Application.Menu;
using ISCC.Application.Menu.Dtos;
using ISCC.Shared.Web.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// Renders the navigation tree for the signed-in user.
/// </summary>
/// <remarks>
/// <para>
/// A view component rather than an <c>Html.Action</c> call, which is what the legacy layout
/// used. That difference is the substance of the port: <c>Html.Action</c> re-enters MVC once
/// per node, so the layout issued one request per group, per module and per leaf, with no
/// cache at any level. Here the tree is fetched once and rendered in a single pass.
/// </para>
/// <para>
/// Returns empty content for an anonymous visitor, so the layout can call it
/// unconditionally rather than having to re-check the authentication cookie in two places.
/// </para>
/// </remarks>
public class MenuViewComponent : ViewComponent
{
    private readonly IMenuService _menuService;
    private readonly MenuRouteResolver _routeResolver;

    /// <summary>Creates the component.</summary>
    /// <param name="menuService">Builds the tree from <c>dbPrivilage</c>.</param>
    /// <param name="routeResolver">Classifies links against the live route table.</param>
    public MenuViewComponent(IMenuService menuService, MenuRouteResolver routeResolver)
    {
        _menuService = menuService;
        _routeResolver = routeResolver;
    }

    /// <summary>
    /// Builds the menu view model.
    /// </summary>
    /// <remarks>
    /// Returns a <c>ViewComponentResult</c> whose view is a single tag helper invocation.
    /// Rendering the tree with <c>MenuTagHelper</c> rather than from nested Razor partials is
    /// deliberate — partial lookup inside a view component result resolves against the calling
    /// controller's folder, not the component's, so the obvious partial-based version throws
    /// "partial view not found" at runtime. See <c>ISCC.Shared.Web.Menu.MenuTagHelper</c>.
    /// </remarks>
    /// <remarks>
    /// The user id comes from the <c>PR_User_Id</c> claim in the principal that the cookie
    /// handler already validated against <c>dbPrivilage</c> at sign-in. It is never taken
    /// from a form field or query string, so a caller cannot ask for another account's menu.
    /// </remarks>
    /// <returns>A view model, or empty content when nobody is signed in.</returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = ResolveUserId();

        if (userId is null)
        {
            return Content(string.Empty);
        }

        var nodes = await _menuService.GetMenuTreeAsync(userId.Value).ConfigureAwait(false);
        var items = nodes.Select(node => ToItem(node)).ToList();

        if (items.Count == 0)
        {
            // No rows for this account. That is a legitimate state — an account can hold
            // privilege rows for a category this portal does not serve — so it is not an
            // error, but the sidebar should not then show an empty labelled region.
            return Content(string.Empty);
        }

        return View(new MenuViewModel { Items = items });
    }

    /// <summary>
    /// Reads the signed-in <c>PR_User.Id</c> from the validated principal.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Read from <see cref="ClaimTypes.NameIdentifier"/>, which is where
    /// <c>AccountController</c> puts it — the same claim the rest of the portal uses for the
    /// user. A claim name invented here would resolve to nothing and the menu would silently
    /// render empty on every page, which is precisely the failure this port has to not have.
    /// </para>
    /// <para>
    /// The claim value is a string, so it is parsed rather than cast. A value that will not
    /// parse yields no menu rather than an exception: it can only happen if the cookie was
    /// issued outside this application's own sign-in, and failing quietly on navigation is
    /// the safer reading of that than a 500 on every page view.
    /// </para>
    /// </remarks>
    /// <returns>The user id, or <see langword="null"/> when absent or unusable.</returns>
    private short? ResolveUserId()
    {
        var raw = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return short.TryParse(raw, out var id) ? id : null;
    }

    /// <summary>
    /// Converts one application node to one view-model item, recursing into its children.
    /// </summary>
    /// <remarks>
    /// <see cref="MenuItem.IsImplemented"/> is computed once per node: a branch counts as
    /// implemented when any descendant is, which is what lets the view collapse a branch that
    /// leads only to areas not yet ported.
    /// </remarks>
    /// <param name="node">The node to convert.</param>
    /// <param name="level">Depth in the tree, 1-based.</param>
    /// <returns>The view-model item.</returns>
    private MenuItem ToItem(MenuNode node, int level = 1)
    {
        var item = new MenuItem
        {
            Title = node.Title,
            MenuId = node.Id,
            Level = level,
            CanView = node.CanView,
            IsLeaf = node.NodeType == MenuNodeKind.Leaf,
        };

        if (item.IsLeaf)
        {
            _routeResolver.Resolve(node.Url, out var url, out var isImplemented);
            item.Href = url;
            item.IsImplemented = isImplemented;
            return item;
        }

        item.Children = node.Children.Select(child => ToItem(child, level + 1)).ToList();
        item.IsImplemented = item.Children.Any(child => child.IsImplemented);
        return item;
    }
}