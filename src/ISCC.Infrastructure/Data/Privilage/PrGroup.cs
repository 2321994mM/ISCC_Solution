namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// A security group, from <c>dbPrivilage.PR_Group</c>.
/// </summary>
/// <remarks>
/// Mapped for Phase 2 but not yet consulted: the decision is to authenticate first and
/// enforce granular privileges per feature area as its controllers are ported. See
/// <c>docs/PHASE2-AUTH-DESIGN.md</c> decision 3.
/// </remarks>
public class PrGroup
{
    /// <summary>Surrogate key.</summary>
    public int Id { get; set; }

    /// <summary>Group name, Arabic.</summary>
    public string? GroupName { get; set; }

    /// <summary>Group name, English.</summary>
    public string? GroupNameEn { get; set; }

    /// <summary>Whether the group is in use.</summary>
    public bool Active { get; set; }

    /// <summary>Date the group was created.</summary>
    public DateOnly? CreatedDate { get; set; }

    /// <summary>Date the group was last modified.</summary>
    public DateOnly? LastModifiedDate { get; set; }

    /// <summary>Free-text note.</summary>
    public string? Note { get; set; }

    /// <summary>Application this group belongs to.</summary>
    public int? PrApplicationId { get; set; }

    /// <summary>Application category this group belongs to.</summary>
    public int? PrApplicationCategoryId { get; set; }

    /// <summary>Whether the group is a ministry-wide (as opposed to directorate) group.</summary>
    public bool IsMinistry { get; set; }

    /// <summary>Memberships of this group.</summary>
    public ICollection<PrUserGroup> UserGroups { get; set; } = new List<PrUserGroup>();
}
