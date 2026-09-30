using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اساسيات اللجان
/// </summary>
public partial class ImRequestCommittee
{
    public long Id { get; set; }

    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// كود الغرض من اللجنه
    /// </summary>
    public byte? CommitteeTypeId { get; set; }

    /// <summary>
    /// كود اماكن الفحص
    /// </summary>
    public byte? ImCommitteeCheckLocationId { get; set; }

    /// <summary>
    /// تاريخ الانتداب
    /// </summary>
    public DateOnly? DelegationDate { get; set; }

    /// <summary>
    ///  بداية ساعة الفحص 
    /// </summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// انتهاء ساعة الفحص
    /// </summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1 خاص ب شغل موظف الحجر في فحص الشحنه
    /// </summary>
    public bool? IsFinishedAll { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1 خاص ب نتيجه الفحص
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// 0 if not done, 1 if investigation is done تم نزول اللجنه 1 ,0 وافق علي معاد اللجنه , null خاص ب العميل عدم الرد عل معاد اللجنه , 
    /// </summary>
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

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ICollection<ImCheckRequestSampleDatum> ImCheckRequestSampleData { get; set; } = new List<ImCheckRequestSampleDatum>();

    public virtual ImCommitteeCheckLocation? ImCommitteeCheckLocation { get; set; }

    public virtual ICollection<ImCommitteeResult> ImCommitteeResults { get; set; } = new List<ImCommitteeResult>();

    public virtual ICollection<ImExecution> ImExecutions { get; set; } = new List<ImExecution>();

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ICollection<ImPermissionItemDivisionCustodyDismissCommittee> ImPermissionItemDivisionCustodyDismissCommittees { get; set; } = new List<ImPermissionItemDivisionCustodyDismissCommittee>();

    public virtual ICollection<ImPermissionItemDivisionCustodyReceiveCommittee> ImPermissionItemDivisionCustodyReceiveCommittees { get; set; } = new List<ImPermissionItemDivisionCustodyReceiveCommittee>();

    public virtual ICollection<ImRequestCommitteeProcedure> ImRequestCommitteeProcedures { get; set; } = new List<ImRequestCommitteeProcedure>();

    public virtual ICollection<ImRequestCommitteeShift> ImRequestCommitteeShifts { get; set; } = new List<ImRequestCommitteeShift>();

    public virtual ICollection<ImRequestTreatmentDatum> ImRequestTreatmentData { get; set; } = new List<ImRequestTreatmentDatum>();
}
