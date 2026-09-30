using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExRequestCommittee
{
    public long Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    public byte? CommitteeTypeId { get; set; }

    public byte? ExCommitteeCheckLocationId { get; set; }

    public DateOnly? DelegationDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool? IsFinishedAll { get; set; }

    public bool? IsApproved { get; set; }

    public bool? Status { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public bool? IsAgreeResult { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool? IsPaid { get; set; }

    /// <summary>
    /// تعزر عمل اللجنه
    /// </summary>
    public bool? IsStartAndroid { get; set; }

    /// <summary>
    /// لايقاف او حذف اللجنة مربوط مع  A_SystemCode رقم 31
    /// 
    /// </summary>
    public byte? IsCancel { get; set; }

    public virtual CommitteeType? CommitteeType { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ICollection<ExCheckRequestSampleDatum> ExCheckRequestSampleData { get; set; } = new List<ExCheckRequestSampleDatum>();

    public virtual ExCommitteeCheckLocation? ExCommitteeCheckLocation { get; set; }

    public virtual ICollection<ExCommitteeResult> ExCommitteeResults { get; set; } = new List<ExCommitteeResult>();

    public virtual ICollection<ExRequestCommitteeFeesEng> ExRequestCommitteeFeesEngs { get; set; } = new List<ExRequestCommitteeFeesEng>();

    public virtual ICollection<ExRequestCommitteeShift> ExRequestCommitteeShifts { get; set; } = new List<ExRequestCommitteeShift>();

    public virtual ICollection<ExRequestTreatmentDatum> ExRequestTreatmentData { get; set; } = new List<ExRequestTreatmentDatum>();
}
