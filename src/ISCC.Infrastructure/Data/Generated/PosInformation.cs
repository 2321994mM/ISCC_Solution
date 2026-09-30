using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// ماكينات الدفع
/// </summary>
public partial class PosInformation
{
    public long Id { get; set; }

    public string? PosNumber { get; set; }

    public long? UserId { get; set; }

    public string? Place { get; set; }

    public long? OutletId { get; set; }

    public int? InstitutionalCode { get; set; }

    public string? BankAccount { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<FeesTransactionsPaymentDetile> FeesTransactionsPaymentDetiles { get; set; } = new List<FeesTransactionsPaymentDetile>();

    public virtual Outlet? Outlet { get; set; }
}
