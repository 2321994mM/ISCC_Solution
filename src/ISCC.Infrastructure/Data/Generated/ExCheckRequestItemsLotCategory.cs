using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestItemsLotCategory
{
    public long Id { get; set; }

    public long? ExCheckRequestItemsId { get; set; }

    public short? PackageMaterialId { get; set; }

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
    /// الوزن العبوه الفارغ
    /// </summary>
    public decimal? PackageWeight { get; set; }

    /// <summary>
    /// وزن العبوة القائم
    /// </summary>
    public decimal? PackageBasedWeight { get; set; }

    /// <summary>
    /// وزن العبوة الصافي
    /// </summary>
    public decimal? PackageNetWeight { get; set; }

    public int? UnitsNumber { get; set; }

    public double? Size { get; set; }

    public string? OrderText { get; set; }

    public string? ReasonEntry { get; set; }

    public string? LotNumber { get; set; }

    public bool? IsAccepted { get; set; }

    public string? RejectReason { get; set; }

    public string? GrowerNumber { get; set; }

    public string? Waybill { get; set; }

    public string? NumberWoodenPackage { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ExCheckRequsetShippingMethodId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public decimal? GrossWeightOld { get; set; }

    public long? FarmsDataId { get; set; }

    public string? FarmsCode { get; set; }

    public virtual ExCheckRequestItem? ExCheckRequestItems { get; set; }

    public virtual ICollection<ExCheckRequestItemsLotResult> ExCheckRequestItemsLotResults { get; set; } = new List<ExCheckRequestItemsLotResult>();

    public virtual ExCheckRequsetShippingMethod? ExCheckRequsetShippingMethod { get; set; }
}
