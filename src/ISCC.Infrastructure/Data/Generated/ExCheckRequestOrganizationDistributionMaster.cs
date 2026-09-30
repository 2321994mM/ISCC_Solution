using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestOrganizationDistributionMaster
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

    public long ItemId { get; set; }

    public long ItemShortNameId { get; set; }

    /// <summary>
    /// الكمية الصالحة للتصدير
    /// </summary>
    public double TotallQuantityTonExCheckRequest { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? UserUpdationId { get; set; }

    public double? RegisteredQuantityTonExCheckRequest { get; set; }

    public virtual ICollection<ExCheckRequestOrganizationDistributionDetial> ExCheckRequestOrganizationDistributionDetials { get; set; } = new List<ExCheckRequestOrganizationDistributionDetial>();

    public virtual ItemShortName ItemShortName { get; set; } = null!;
}
