using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestOrganizationDistribution
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    /// <summary>
    /// رقم الجهة
    /// </summary>
    public long OrganizationId { get; set; }

    /// <summary>
    /// نوع الجهة
    /// </summary>
    public int OrganizationTypeId { get; set; }

    /// <summary>
    /// الكمية الصالحة للتصدير
    /// </summary>
    public double? QuantityTon { get; set; }

    public bool? IsActive { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? UserUpdationId { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;
}
