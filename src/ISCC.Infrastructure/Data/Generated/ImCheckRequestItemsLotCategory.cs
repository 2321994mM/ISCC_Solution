using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تقسيم لوط وااصناف
/// </summary>
public partial class ImCheckRequestItemsLotCategory
{
    public long Id { get; set; }

    public long? ImCheckRequestItemsId { get; set; }

    public long? ItemCategoryId { get; set; }

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
    /// اجمالى الوزن القائم لللوطات
    /// </summary>
    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// الوزن الصافي لللوطات
    /// </summary>
    public decimal? NetWeight { get; set; }

    /// <summary>
    /// مش مستخدم
    /// </summary>
    public decimal? BasedWeight { get; set; }

    /// <summary>
    /// الوزن العبوه الصافي
    /// </summary>
    public decimal? PackageWeight { get; set; }

    /// <summary>
    /// وزن العبوة القائم
    /// </summary>
    public decimal? PackageBasedWeight { get; set; }

    /// <summary>
    /// وزن العبوة الفارغ
    /// </summary>
    public decimal? PackageNetWeight { get; set; }

    /// <summary>
    /// عدد الوحدات
    /// </summary>
    public int? UnitsNumber { get; set; }

    public double? Size { get; set; }

    public string? OrderText { get; set; }

    /// <summary>
    /// سبب الدخول
    /// </summary>
    public string? ReasonEntry { get; set; }

    /// <summary>
    /// رقم اللوط
    /// </summary>
    public string? LotNumber { get; set; }

    /// <summary>
    /// مقبول = 1 / مرفوض =0
    /// </summary>
    public bool? IsAccepted { get; set; }

    /// <summary>
    /// اسباب الرفض
    /// </summary>
    public string? RejectReason { get; set; }

    /// <summary>
    /// رقم المزرعه من الصادر ,وبعض الحالات من الوارد
    /// </summary>
    public string? GrowerNumber { get; set; }

    /// <summary>
    /// رقم بوليصه الشحن
    /// </summary>
    public string? Waybill { get; set; }

    /// <summary>
    /// عدد وحدات التعبئه الخشبيه 
    /// </summary>
    public string? NumberWoodenPackage { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// علامة مميزة
    /// </summary>
    public string? DistinctiveMark { get; set; }

    /// <summary>
    /// عدد الطرود
    /// </summary>
    public string? PackagesCount { get; set; }

    /// <summary>
    /// علامة مميزة
    /// </summary>
    public string? ShipName { get; set; }

    /// <summary>
    /// عبوات او بدون
    /// </summary>
    public int? ContainersTypeId { get; set; }

    /// <summary>
    /// تاريخ الرحلة
    /// </summary>
    public DateOnly? TripDate { get; set; }

    public virtual ImCheckRequestItem? ImCheckRequestItems { get; set; }

    public virtual ICollection<ImExecutionItem> ImExecutionItems { get; set; } = new List<ImExecutionItem>();

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ItemCategory? ItemCategory { get; set; }
}
