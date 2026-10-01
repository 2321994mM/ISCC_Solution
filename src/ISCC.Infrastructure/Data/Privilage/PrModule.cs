namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// A functional module, from <c>dbPrivilage.PR_Module</c>. The middle level of the
/// navigation tree: a group contains modules, a module contains menu leaves.
/// </summary>
/// <remarks>
/// <para>
/// The 55 rows carry no explicit ordering column of their own. The legacy stored
/// procedures fetched modules with no <c>ORDER BY</c> at all, so the order a user saw was
/// whatever SQL Server happened to return — it could change between requests or after a
/// statistics update. This port orders by localized name instead, which is stable and
/// predictable.
/// </para>
/// </remarks>
public class PrModule
{
    /// <summary>Surrogate key.</summary>
    public int Id { get; set; }

    /// <summary>Module name, Arabic.</summary>
    public string? ModuleName { get; set; }

    /// <summary>Module name, English.</summary>
    /// <remarks>
    /// <c>varchar</c> in the database, unlike the Arabic column which is <c>nvarchar</c>.
    /// That asymmetry is in the legacy schema and is preserved rather than corrected,
    /// because the column type is what the live table has.
    /// </remarks>
    public string? ModuleNameEn { get; set; }

    /// <summary>Free-text description.</summary>
    public string? ModuleDescription { get; set; }

    /// <summary>Application this module belongs to.</summary>
    public int? PrApplicationId { get; set; }

    /// <summary>Application category this module belongs to.</summary>
    public int? PrApplicationCategoryId { get; set; }

    /// <summary>Whether the module is in use.</summary>
    public bool Active { get; set; }
}