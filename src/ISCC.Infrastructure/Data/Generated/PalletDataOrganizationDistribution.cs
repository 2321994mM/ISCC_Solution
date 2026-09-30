using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class PalletDataOrganizationDistribution
{
    public long Id { get; set; }

    /// <summary>
    /// رقم الجهة المشتري
    /// </summary>
    public long OrganizationId { get; set; }

    /// <summary>
    /// نوع الجهة المشتري
    /// </summary>
    public int OrganizationTypeId { get; set; }

    /// <summary>
    /// كمية البالتات
    /// </summary>
    public int? Quantity { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly Date { get; set; }

    public bool IsActive { get; set; }

    public bool? IsAcceppted { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? UserUpdationId { get; set; }

    public long ExCheckRequestId { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;

    public virtual ICollection<PalletDataExCheckRequestDistribution> PalletDataExCheckRequestDistributions { get; set; } = new List<PalletDataExCheckRequestDistribution>();
}
