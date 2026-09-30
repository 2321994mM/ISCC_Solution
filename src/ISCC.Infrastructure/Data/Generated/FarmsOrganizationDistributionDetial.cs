using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmsOrganizationDistributionDetial
{
    public long Id { get; set; }

    public long FarmsOrganizationDistributionMasterId { get; set; }

    public DateOnly? Date { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// الكمية الصالحة للتصدير
    /// </summary>
    public double QuantityTon { get; set; }

    public virtual FarmsOrganizationDistributionMaster FarmsOrganizationDistributionMaster { get; set; } = null!;
}
