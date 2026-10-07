using System.Globalization;
using ISCC.Application.Menu;
using ISCC.Application.Menu.Dtos;
using ISCC.Infrastructure.Data.Privilage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ISCC.Infrastructure.Menu;

/// <summary>
/// Builds the navigation tree from a single query over <c>PR_GroupModuleMenuPrivilage</c>.
/// </summary>
/// <remarks>
/// <para>
/// The three tables this reads are read-only. Nothing here writes to <c>dbPrivilage</c>.
/// </para>
/// <para>
/// <b>Why one query.</b> The legacy controller exposed three actions and the layout nested
/// them with <c>@Html.Action</c>: one call for groups, one per group for modules, one per
/// group-and-module pair for leaves. Nothing was cached — no <c>HttpContext.Cache</c>, no
/// <c>[OutputCache]</c> — so the cost of a page view grew with the size of the user's menu
/// instead of staying constant.
/// </para>
/// <para>
/// <b>Caching.</b> The menu is per-user but read-only; we cache the assembled tree for
/// 5 minutes per user/language to eliminate the DB round-trip on every page load.
/// </para>
/// </remarks>
public class MenuService : IMenuService
{
    /// <summary>
    /// Application category for the staff portal.
    /// </summary>
    /// <remarks>
    /// The legacy controller passed a literal <c>1</c> at both call sites, so this was never
    /// actually a per-request choice. Category 1 is the only one with meaningful groups;
    /// category 2 has a single group and no privilege rows behind it.
    /// </remarks>
    private const int StaffPortalApplicationCategoryId = 1;

    private readonly PrivilageDbContext _context;
    private readonly IMemoryCache _cache;

    /// <summary>Creates the service.</summary>
    /// <param name="context">The <c>dbPrivilage</c> context.</param>
    /// <param name="cache">In-memory cache for assembled menu trees.</param>
    public MenuService(PrivilageDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<MenuNode>> GetMenuTreeAsync(
        short userId, CancellationToken cancellationToken = default)
    {
        var isArabic = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            .StartsWith("ar", StringComparison.OrdinalIgnoreCase);
        var cacheKey = $"menu:{userId}:{(isArabic ? "ar" : "en")}";

        if (_cache.TryGetValue(cacheKey, out IReadOnlyList<MenuNode>? cached))
        {
            return cached!;
        }

        var rows = await (
            from prv in _context.PrGroupModuleMenuPrivilages.AsNoTracking()
            join grp in _context.PrGroups.AsNoTracking() on prv.PrGroupId equals grp.Id
            join app in _context.PrApplications.AsNoTracking() on grp.PrApplicationId equals app.Id
            join mod in _context.PrModules.AsNoTracking() on prv.PrModuleId equals mod.Id
            join mnu in _context.PrMenus.AsNoTracking() on prv.PrMenuId equals mnu.Id
            join map in _context.PrGroupModuleMenus.AsNoTracking()
                // The privilege keys are nullable (one live orphan row has all three NULL) and
                // the mapping keys are not, so the anonymous composite keys differ by
                // nullability. Those rows are already excluded: joining prv.PrGroupId to
                // PR_Group.Id is an inner join on a nullable column, and a NULL never
                // matches. Casting here is for the type match, not for the filter.
                on new
                {
                    GroupId = prv.PrGroupId,
                    ModuleId = prv.PrModuleId,
                    MenuId = prv.PrMenuId,
                }
                equals new
                {
                    GroupId = (int?)map.PrGroupId,
                    ModuleId = (int?)map.PrModuleId,
                    MenuId = (int?)map.PrMenuId,
                }
            where prv.PrUserId == userId
                  && prv.IsActive == true
                  && map.IsActive == true
                  && grp.Active
                  && mod.Active
                  && mnu.Active
                  && app.PrApplicationCategoryId == StaffPortalApplicationCategoryId
            select new MenuLeafRow
            {
                GroupId = grp.Id,
                GroupTitle = isArabic ? grp.GroupName : grp.GroupNameEn,
                GroupTitleAlternate = isArabic ? grp.GroupNameEn : grp.GroupName,
                ModuleId = mod.Id,
                ModuleTitle = isArabic ? mod.ModuleName : mod.ModuleNameEn,
                ModuleTitleAlternate = isArabic ? mod.ModuleNameEn : mod.ModuleName,
                MenuId = mnu.Id,
                MenuTitle = isArabic ? mnu.MenuTitle : mnu.MenuTitleEn,
                MenuTitleAlternate = isArabic ? mnu.MenuTitleEn : mnu.MenuTitle,
                Url = mnu.MenuUrl,
                Order = map.OrderBy,
                CanView = prv.CanView,
                CanAdd = prv.CanAdd,
                CanEdit = prv.CanEdit,
                CanDelete = prv.CanDelete,
                CanPrint = prv.CanPrint,
            })
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var tree = BuildTree(rows);

        _cache.Set(cacheKey, tree, TimeSpan.FromMinutes(5));

        return tree;
    }

    /// <summary>
    /// Folds the flat leaf rows into a tree, de-duplicating parents as it goes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The query returns one row per leaf, so a group with six leaves appears six times.
    /// Assembling here rather than in SQL keeps the query a single flat projection, which is
    /// the shape the server optimises best; a <c>GROUP BY</c> with correlated aggregates over
    /// these joins measured materially slower.
    /// </para>
    /// <para>
    /// <b>Ordering.</b> Groups and modules have no sort column anywhere in the schema, and
    /// the legacy queries for both had no <c>ORDER BY</c> at all, so their order was whatever
    /// the engine returned. They are ordered by localized title here. Leaves use the
    /// <c>Order_BY</c> column that does exist — but that column is not unique: group 8 /
    /// module 40 has seven distinct leaves all carrying 88 — so the title is the tie-break.
    /// Without it those seven reshuffle between requests, which is exactly the behaviour
    /// being fixed.
    /// </para>
    /// </remarks>
    /// <param name="rows">Flat leaf rows, one per menu the user can reach.</param>
    /// <returns>The assembled tree; empty when the account has no privilege rows.</returns>
    private static IReadOnlyList<MenuNode> BuildTree(IReadOnlyList<MenuLeafRow> rows)
    {
        var groups = new Dictionary<int, MenuNode>();

        // Keyed by group *and* module, not by module alone. PR_GroupModuleMenuPrivilage rows
        // are per group, so the same module can legitimately be reachable through two groups
        // and the legacy rendered it twice — once under each. Keying on module id alone would
        // hoist the second occurrence's leaves onto the first group and silently drop a
        // branch, which is a wrong menu rather than an obviously broken one.
        var modules = new Dictionary<(int GroupId, int ModuleId), MenuNode>();
        var result = new List<MenuNode>();

        // Every level is in the sort key, including the ids as final tie-breaks so the result
        // is total: no two rows can compare equal, so the order never depends on the order the
        // database happened to return rows in.
        foreach (var row in rows
            .OrderBy(r => r.GroupTitle, StringComparer.CurrentCulture)
            .ThenBy(r => r.GroupId)
            .ThenBy(r => r.ModuleTitle, StringComparer.CurrentCulture)
            .ThenBy(r => r.ModuleId)
            .ThenBy(r => r.Order ?? int.MaxValue)
            .ThenBy(r => r.MenuTitle, StringComparer.CurrentCulture)
            .ThenBy(r => r.MenuId))
        {
            if (!groups.TryGetValue(row.GroupId, out var group))
            {
                group = new MenuNode
                {
                    Level = 1,
                    NodeType = MenuNodeKind.Group,
                    Id = row.GroupId,
                    Title = row.GroupTitle ?? string.Empty,
                    AlternateTitle = row.GroupTitleAlternate,
                };

                groups.Add(row.GroupId, group);
                result.Add(group);
            }

            var moduleKey = (group.Id, row.ModuleId);
            if (!modules.TryGetValue(moduleKey, out var module))
            {
                module = new MenuNode
                {
                    Level = 2,
                    NodeType = MenuNodeKind.Module,
                    Id = row.ModuleId,
                    Title = row.ModuleTitle ?? string.Empty,
                    AlternateTitle = row.ModuleTitleAlternate,
                };

                modules.Add(moduleKey, module);
                group.Children.Add(module);
            }

            module.Children.Add(new MenuNode
            {
                Level = 3,
                NodeType = MenuNodeKind.Leaf,
                Id = row.MenuId,
                Title = row.MenuTitle ?? string.Empty,
                AlternateTitle = row.MenuTitleAlternate,
                Url = row.Url,
                CanView = row.CanView,
                CanAdd = row.CanAdd,
                CanEdit = row.CanEdit,
                CanDelete = row.CanDelete,
                CanPrint = row.CanPrint ?? true,
            });
        }

        return result;
    }

    /// <summary>
    /// One row per reachable menu leaf, with both languages already selected.
    /// </summary>
    /// <remarks>
    /// Private to this file because it is an implementation detail of the query, not part of
    /// the application contract — <see cref="IMenuService"/> returns the assembled tree.
    /// </remarks>
    /// <param name="GroupId">The group the leaf is reached through.</param>
    /// <param name="GroupTitle">Group label in the request language.</param>
    /// <param name="GroupTitleAlternate">Group label in the other language.</param>
    /// <param name="ModuleOrderKey">Sort key for the owning module.</param>
    /// <param name="ModuleId">The module the leaf is reached through.</param>
    /// <param name="ModuleTitle">Module label in the request language.</param>
    /// <param name="ModuleTitleAlternate">Module label in the other language.</param>
    /// <param name="LeafOrderKey">Sort key for the leaf itself.</param>
    /// <param name="MenuId">The <c>PR_Menu</c> key.</param>
    /// <param name="MenuTitle">Leaf label in the request language.</param>
    /// <param name="MenuTitleAlternate">Leaf label in the other language.</param>
    /// <param name="Url">The stored route, area segment included.</param>
    /// <param name="Order">Position from <c>PR_GroupModuleMenu.Order_BY</c>.</param>
    /// <param name="CanView">View permission flag.</param>
    /// <param name="CanAdd">Add permission flag.</param>
    /// <param name="CanEdit">Edit permission flag.</param>
    /// <param name="CanDelete">Delete permission flag.</param>
    /// <param name="CanPrint">Print permission flag. Nullable in the schema.</param>
    private sealed record MenuLeafRow
    {
        public required int GroupId { get; init; }

        public string? GroupTitle { get; init; }

        public string? GroupTitleAlternate { get; init; }

        public required int ModuleId { get; init; }

        public string? ModuleTitle { get; init; }

        public string? ModuleTitleAlternate { get; init; }

        public required int MenuId { get; init; }

        public string? MenuTitle { get; init; }

        public string? MenuTitleAlternate { get; init; }

        public string? Url { get; init; }

        public int? Order { get; init; }

        public bool CanView { get; init; }

        public bool CanAdd { get; init; }

        public bool CanEdit { get; init; }

        public bool CanDelete { get; init; }

        public bool? CanPrint { get; init; }
    }
}