using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تفاصيل اللوط
/// </summary>
public partial class ImItemsLotDivision
{
    public long Id { get; set; }

    public long ImPermissionItemsId { get; set; }

    /// <summary>
    /// الوزن الصافي
    /// </summary>
    public decimal? NetWeight { get; set; }

    /// <summary>
    /// رقم اللوط
    /// </summary>
    public string? LotNumber { get; set; }

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

    public long? FarmId { get; set; }

    /// <summary>
    /// وزن العبوة
    /// </summary>
    public decimal? PackageWeight { get; set; }

    /// <summary>
    /// الوزن القائم
    /// </summary>
    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// رقم الحاوية
    /// </summary>
    public string? ContainerNumber { get; set; }

    /// <summary>
    /// رقم السيل الملاحي
    /// </summary>
    public string? NavigationalFluidNumber { get; set; }

    /// <summary>
    /// رقم بوليصة الشحن
    /// </summary>
    public string? ShipmentPolicyNumber { get; set; }

    /// <summary>
    /// مقبول = 1 / مرفوض =0
    /// </summary>
    public bool? IsAccepted { get; set; }

    public string? RejectReason { get; set; }

    public virtual ImPermissionItem ImPermissionItems { get; set; } = null!;
}
