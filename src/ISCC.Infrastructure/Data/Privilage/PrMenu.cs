namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// A menu leaf, from <c>dbPrivilage.PR_Menu</c>: the clickable entry at the bottom of the
/// navigation tree.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="MenuUrl"/> is the whole route stored as free text, area segment included —
/// for example <c>Im_CheckRequests/List_ImCheckRequest/Index</c>. It is emitted verbatim by
/// the legacy views via <c>href="~/@item.MenuURL"</c>, which is string concatenation with no
/// route validation. A stale value in the table therefore produces a 404 rather than a build
/// error. This port keeps the same values but validates them against the live route table
/// before rendering, so an unresolvable entry is visible as inert rather than as a dead link.
/// </para>
/// <para>
/// The table has no icon column, no sort column and no self-parent column that the menu uses
/// (<see cref="PrMenuId"/> and <see cref="GroupId"/> exist but are unreferenced by the menu
/// code). Icons and ordering therefore have to come from elsewhere; see
/// <c>ISCC.Application.Menu.Dtos.MenuNode</c>.
/// </para>
/// </remarks>
public class PrMenu
{
    /// <summary>Surrogate key.</summary>
    public int Id { get; set; }

    /// <summary>Menu title, Arabic.</summary>
    public string? MenuTitle { get; set; }

    /// <summary>Menu title, English.</summary>
    public string? MenuTitleEn { get; set; }

    /// <summary>
    /// Route to navigate to, without a leading slash, including the area segment.
    /// </summary>
    public string? MenuUrl { get; set; }

    /// <summary>Unused self-reference. Present in the legacy schema, never read by the menu.</summary>
    public int? PrMenuId { get; set; }

    /// <summary>Whether the menu entry is in use.</summary>
    public bool Active { get; set; }

    /// <summary>Owning module. Legacy denormalisation: the menu is already reached through it.</summary>
    public int? PrModuleId { get; set; }

    /// <summary>Owning application.</summary>
    public int? PrApplicationId { get; set; }

    /// <summary>Owning application category.</summary>
    public int? PrApplicationCategoryId { get; set; }

    /// <summary>Unused group reference. Present in the legacy schema, never read by the menu.</summary>
    public int? GroupId { get; set; }
}