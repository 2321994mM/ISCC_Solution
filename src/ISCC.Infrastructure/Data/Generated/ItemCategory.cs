using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الأصناف الزراعية
/// </summary>
public partial class ItemCategory
{
    public long Id { get; set; }

    public long? ItemId { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// الجهة الطالبة للتسجيل
    /// </summary>
    public long? CompanyId { get; set; }

    /// <summary>
    /// هل مسجل ام لا
    /// </summary>
    public bool? IsRegister { get; set; }

    public string? RegisterNumDate { get; set; }

    public DateOnly? RegisterEndDate { get; set; }

    /// <summary>
    /// نهاية المهلة
    /// </summary>
    public DateOnly? TimeOut { get; set; }

    /// <summary>
    ///  0 لو ممنوع 1 لو شغال
    /// </summary>
    public bool IsForbidden { get; set; }

    /// <summary>
    /// if under protection 1 / 0 if not (تحت الحماية أو لا)
    /// </summary>
    public bool CurrentStatus { get; set; }

    /// <summary>
    /// قرار حماية الماكية ملف Pdf
    /// </summary>
    public string? ProtectProperty { get; set; }

    public string? Notes { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public int? ResolutionNumber { get; set; }

    public short? ItemCategoriesType { get; set; }

    public bool? IsPlantEgypt { get; set; }

    public long? ItemCategoriesGroupId { get; set; }

    public int? ResolutionDate { get; set; }

    public virtual CompanyNational? Company { get; set; }

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<FarmItemCategory> FarmItemCategories { get; set; } = new List<FarmItemCategory>();

    public virtual ICollection<ImCheckRequestItemsLotCategory> ImCheckRequestItemsLotCategories { get; set; } = new List<ImCheckRequestItemsLotCategory>();

    public virtual ICollection<ImPermissionItemsCategory> ImPermissionItemsCategories { get; set; } = new List<ImPermissionItemsCategory>();

    public virtual Item? Item { get; set; }

    public virtual ItemCategoriesGroup? ItemCategoriesGroup { get; set; }

    public virtual ItemCategoriesType? ItemCategoriesTypeNavigation { get; set; }
}
