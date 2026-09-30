using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class CompanyAccreditationCommittee
{
    public long Id { get; set; }

    /// <summary>
    /// طلب الفحص
    /// </summary>
    public long CompanyAccreditationId { get; set; }

    public byte CommitteeTypeId { get; set; }

    /// <summary>
    /// تاريخ الفحص
    /// </summary>
    public DateOnly? DelegationDate { get; set; }

    /// <summary>
    /// تاريخ الانتداب
    /// </summary>
    public DateOnly? CheckDate { get; set; }

    /// <summary>
    ///  بداية ساعة الفحص 
    /// </summary>
    public TimeOnly? StartTime { get; set; }

    /// <summary>
    /// انتهاء ساعة الفحص
    /// </summary>
    public TimeOnly? EndTime { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal AmountTotal { get; set; }

    /// <summary>
    /// null-&gt;No committe ,0 if not done, 1 if investigation is done
    /// </summary>
    public bool? Status { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual CommitteeType CommitteeType { get; set; } = null!;

    public virtual CompanyAccreditation CompanyAccreditation { get; set; } = null!;

    public virtual ICollection<CompanyAccreditationPayment> CompanyAccreditationPayments { get; set; } = new List<CompanyAccreditationPayment>();
}
