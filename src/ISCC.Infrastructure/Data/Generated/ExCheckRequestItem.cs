using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestItem
{
    public long Id { get; set; }

    public int? SubPartId { get; set; }

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

    public decimal? NetWeight { get; set; }

    public decimal? Fees { get; set; }

    public long? ItemShortNameId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ItemCategoryId { get; set; }

    public long? ExCheckRequestId { get; set; }

    public long? FarmsDataId { get; set; }

    public short? GovernateId { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    /// <summary>
    /// ناحية الزراعة
    /// </summary>
    public string? AgricultureHand { get; set; }

    public string? ItemPermissionNumber { get; set; }

    public long? ItemCategoriesGroupId { get; set; }

    public decimal? NetWeightOld { get; set; }

    public virtual Center? Center { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ICollection<ExCheckRequestItemsLotCategory> ExCheckRequestItemsLotCategories { get; set; } = new List<ExCheckRequestItemsLotCategory>();

    public virtual FarmsDatum? FarmsData { get; set; }

    public virtual Governate? Governate { get; set; }

    public virtual ItemCategoriesGroup? ItemCategoriesGroup { get; set; }

    public virtual ItemCategory? ItemCategory { get; set; }

    public virtual ItemShortName? ItemShortName { get; set; }

    public virtual Village? Village { get; set; }
}
