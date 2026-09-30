using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class PalletDataExCheckRequestDistribution
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    public long? PalletDataOrganizationDistributionId { get; set; }

    /// <summary>
    /// الكمية الصالحة للتصدير
    /// </summary>
    public int Quantity { get; set; }

    public DateOnly? Date { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;

    public virtual PalletDataOrganizationDistribution? PalletDataOrganizationDistribution { get; set; }
}
