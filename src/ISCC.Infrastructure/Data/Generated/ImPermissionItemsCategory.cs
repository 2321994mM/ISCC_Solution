using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImPermissionItemsCategory
{
    public long Id { get; set; }

    public long? ImPermissionItemsId { get; set; }

    public long? ItemCategoryId { get; set; }

    public long? ItemCategoryGroupId { get; set; }

    /// <summary>
    /// مادة العبوة
    /// </summary>
    public short? PackageMaterialId { get; set; }

    /// <summary>
    /// نوع العبوة
    /// </summary>
    public short? PackageTypeId { get; set; }

    /// <summary>
    /// عدد العبوات
    /// </summary>
    public int? PackageCount { get; set; }

    /// <summary>
    /// وزن العبوة
    /// </summary>
    public decimal? PackageWeight { get; set; }

    /// <summary>
    /// عدد الوحدات
    /// </summary>
    public int? UnitsNumber { get; set; }

    /// <summary>
    /// حجم الرسالة
    /// </summary>
    public double? Size { get; set; }

    /// <summary>
    /// الرتبة
    /// </summary>
    public string? OrderText { get; set; }

    /// <summary>
    /// الوزن الاجمالى
    /// </summary>
    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// سبب الدخول
    /// </summary>
    public string? ReasonEntry { get; set; }

    public virtual ImPermissionItem? ImPermissionItems { get; set; }

    public virtual ItemCategory? ItemCategory { get; set; }

    public virtual ItemCategoriesGroup? ItemCategoryGroup { get; set; }
}
