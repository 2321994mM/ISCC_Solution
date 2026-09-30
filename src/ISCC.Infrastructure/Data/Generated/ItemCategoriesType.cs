using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// سلالة البند الخاضع
/// </summary>
public partial class ItemCategoriesType
{
    public short Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ImScientificResearchItemPlantInseketLieble> ImScientificResearchItemPlantInseketLiebles { get; set; } = new List<ImScientificResearchItemPlantInseketLieble>();

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

    public virtual ICollection<LiableItem> LiableItems { get; set; } = new List<LiableItem>();
}
