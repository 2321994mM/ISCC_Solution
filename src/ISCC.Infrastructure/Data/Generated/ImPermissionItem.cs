using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// النباتات والمنتجات للوارد
/// </summary>
public partial class ImPermissionItem
{
    public long Id { get; set; }

    public long? ImPermissionRequestId { get; set; }

    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// دوله المنشا
    /// </summary>
    public long? ImInitiatorId { get; set; }

    /// <summary>
    /// جزء نباتى
    /// </summary>
    public int? SubPartId { get; set; }

    /// <summary>
    /// رقم اذن الاستيراد يأخذ رقم عند الموافقة
    /// </summary>
    public string? ItemPermissionNumber { get; set; }

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
    /// 1 if divided lots /0 if Sub
    /// </summary>
    public bool? IsLotDivision { get; set; }

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
    /// هل تم الموافقة على الصنف
    /// </summary>
    public bool IsAccepted { get; set; }

    public DateOnly? AcceptDate { get; set; }

    public DateTime? AcceptUserUpdationDate { get; set; }

    /// <summary>
    /// الموظف الذى وافق على الصنف وهذا ليس له علاقة بمن ادخل الصنف( يقرا من الاذن نفسه)
    /// </summary>
    public short? AcceptUserCreationId { get; set; }

    public DateTime? AcceptUserCreationDate { get; set; }

    public short? AcceptUserUpdationId { get; set; }

    /// <summary>
    /// ConstrainOwner(UnionId/CountryId/ or 0 if Local-Egypt)
    /// </summary>
    public short? CountryId { get; set; }

    public long? ItemShortNameId { get; set; }

    public short? QualitativeGroupId { get; set; }

    public virtual ImInitiator? ImInitiator { get; set; }

    public virtual ICollection<ImItemsLotDivision> ImItemsLotDivisions { get; set; } = new List<ImItemsLotDivision>();

    public virtual ICollection<ImPermissionItemsCategory> ImPermissionItemsCategories { get; set; } = new List<ImPermissionItemsCategory>();

    public virtual ICollection<ImSubDivission> ImSubDivissions { get; set; } = new List<ImSubDivission>();
}
