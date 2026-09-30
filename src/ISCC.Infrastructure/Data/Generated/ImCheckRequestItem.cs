using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نباتات طلب الفحص الوارد
/// </summary>
public partial class ImCheckRequestItem
{
    public long Id { get; set; }

    public long? ImCheckRequsetShippingMethodId { get; set; }

    public long? ImInitiatorId { get; set; }

    public int? SubPartId { get; set; }

    public string? ItemPermissionNumber { get; set; }

    public short? PackageMaterialId { get; set; }

    public short? PackageTypeId { get; set; }

    public int? PackageCount { get; set; }

    public decimal? PackageWeight { get; set; }

    public int? UnitsNumber { get; set; }

    public bool? IsLotDivision { get; set; }

    public double? Size { get; set; }

    public string? OrderText { get; set; }

    public decimal? GrossWeight { get; set; }

    public bool IsAccepted { get; set; }

    public DateOnly? AcceptDate { get; set; }

    public DateTime? AcceptUserUpdationDate { get; set; }

    public short? AcceptUserCreationId { get; set; }

    public DateTime? AcceptUserCreationDate { get; set; }

    public short? AcceptUserUpdationId { get; set; }

    public short? CountryId { get; set; }

    /// <summary>
    /// الوزن الصافي
    /// </summary>
    public decimal? NetWeight { get; set; }

    public decimal? Fees { get; set; }

    public long? ItemShortNameId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public decimal? FeesActual { get; set; }

    public bool? IsPaid { get; set; }

    public short? QualitativeGroupId { get; set; }

    public virtual ICollection<ImCheckRequestItemsLotCategory> ImCheckRequestItemsLotCategories { get; set; } = new List<ImCheckRequestItemsLotCategory>();

    public virtual ImCheckRequsetShippingMethod? ImCheckRequsetShippingMethod { get; set; }

    public virtual ICollection<ImExecutionItem> ImExecutionItems { get; set; } = new List<ImExecutionItem>();

    public virtual ImInitiator? ImInitiator { get; set; }

    public virtual ICollection<ImPermissionItemDivisionCustody> ImPermissionItemDivisionCustodies { get; set; } = new List<ImPermissionItemDivisionCustody>();
}
