using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class CompanyAccreditationPayment
{
    public long Id { get; set; }

    public long CompanyCommitteeId { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal Amount { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// from web/system
    /// 1-&gt;online
    /// 0-&gt;offline
    /// </summary>
    public bool IsOnlineOffline { get; set; }

    public short UserCreationId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual CompanyAccreditationCommittee CompanyCommittee { get; set; } = null!;
}
