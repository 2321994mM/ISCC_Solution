using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المجموعة الصنفية
/// </summary>
public partial class ItemCategoriesGroup
{
    public long Id { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? DescreptionEn { get; set; }

    public string? DescreptionAr { get; set; }

    public long? ItemId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<ImPermissionItemsCategory> ImPermissionItemsCategories { get; set; } = new List<ImPermissionItemsCategory>();

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();
}
