namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// Which menu leaves belong to which module within which group, and in what order.
/// From <c>dbPrivilage.PR_GroupModuleMenu</c>.
/// </summary>
/// <remarks>
/// <para>
/// This is the only table in the menu schema with an ordering column,
/// <see cref="OrderBy"/>, and the only one the legacy code consulted it through — the leaf
/// query ordered by it. Groups and modules had no order column at all.
/// </para>
/// <para>
/// <b>The ordering it provides is not unique.</b> Measured on the live data, group 8 /
/// module 40 has seven distinct leaves all carrying <c>Order_BY = 88</c>. Ordering by that
/// column alone leaves those seven in whatever order the engine returns, which is exactly
/// why the legacy menu's third level could reshuffle between page loads. This port therefore
/// breaks ties on the localized title.
/// </para>
/// </remarks>
public class PrGroupModuleMenu
{
    /// <summary>Group part of the composite primary key.</summary>
    public int PrGroupId { get; set; }

    /// <summary>Module part of the composite primary key.</summary>
    public int PrModuleId { get; set; }

    /// <summary>Menu part of the composite primary key.</summary>
    public int PrMenuId { get; set; }

    /// <summary>
    /// Whether this mapping is in effect. Nullable, and 3 of 194 rows are inactive.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>Position within the module. Not unique — see the type remarks.</summary>
    public int? OrderBy { get; set; }
}