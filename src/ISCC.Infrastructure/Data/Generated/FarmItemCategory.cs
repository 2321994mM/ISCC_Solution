using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اصناف المزرعة
/// </summary>
public partial class FarmItemCategory
{
    public long Id { get; set; }

    public long? FarmId { get; set; }

    public long? ItemCategoriesId { get; set; }

    /// <summary>
    /// مساحة العميل
    /// </summary>
    public double? AreaAcres { get; set; }

    public double? QuantityTon { get; set; }

    public DateOnly? Date { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// المساحة النهائية للحجر
    /// </summary>
    public double? AreaAcresQuarant { get; set; }

    /// <summary>
    /// الكمية للفدان بالطن للحجر
    /// </summary>
    public double? QuantityTonQuarant { get; set; }

    /// <summary>
    /// الكمية الاجمالية الصالحة للتصدير
    /// </summary>
    public double? QuantityTonExport { get; set; }

    public bool? IsAcceppted { get; set; }

    public virtual FarmsDatum? Farm { get; set; }

    public virtual ICollection<FarmRequestItemCategory> FarmRequestItemCategories { get; set; } = new List<FarmRequestItemCategory>();

    public virtual ICollection<FarmsOrganizationDistributionMaster> FarmsOrganizationDistributionMasters { get; set; } = new List<FarmsOrganizationDistributionMaster>();

    public virtual ItemCategory? ItemCategories { get; set; }
}
