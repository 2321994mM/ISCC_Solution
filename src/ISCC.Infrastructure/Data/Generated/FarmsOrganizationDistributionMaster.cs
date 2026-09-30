using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmsOrganizationDistributionMaster
{
    public long Id { get; set; }

    /// <summary>
    /// رقم الجهة
    /// </summary>
    public long OrganizationId { get; set; }

    /// <summary>
    /// نوع الجهة
    /// </summary>
    public int OrganizationTypeId { get; set; }

    public long FarmsDataId { get; set; }

    public long FarmItemCategoriesId { get; set; }

    public long ItemId { get; set; }

    public long ItemCategoriesId { get; set; }

    /// <summary>
    /// الكمية الصالحة للتصدير
    /// </summary>
    public double QuantityTonFarm { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? UserUpdationId { get; set; }

    public double? QuantityTonExCheckRequest { get; set; }

    public virtual FarmItemCategory FarmItemCategories { get; set; } = null!;

    public virtual ICollection<FarmsOrganizationDistributionDetial> FarmsOrganizationDistributionDetials { get; set; } = new List<FarmsOrganizationDistributionDetial>();
}
