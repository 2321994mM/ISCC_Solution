using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تشكيل لجنة مزرعة
/// </summary>
public partial class FarmCommittee
{
    public long Id { get; set; }

    /// <summary>
    /// طلب الفحص
    /// </summary>
    public long FarmRequestId { get; set; }

    public byte? CommitteeTypeId { get; set; }

    /// <summary>
    /// عدد السحبات
    /// </summary>
    public byte? AnalysisCount { get; set; }

    /// <summary>
    /// تاريخ الفحص-تاريخ الانتداب
    /// </summary>
    public DateOnly? DelegationDate { get; set; }

    /// <summary>
    ///  بداية ساعة الفحص 
    /// </summary>
    public TimeOnly? StartTime { get; set; }

    /// <summary>
    /// انتهاء ساعة الفحص
    /// </summary>
    public TimeOnly? EndTime { get; set; }

    /// <summary>
    /// null-&gt;exporter not take action 
    /// 0 if exporter doesn&apos;t accept else 1
    /// 
    /// null تم طلب لجنة
    /// 0 تم رفض الطلب من العميل
    /// 1 تم قبول الطلب من العميل
    /// 
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// null-&gt;No committe ,0 if not done, 1 if investigation is done
    /// 
    /// null لم يتم تشكيل اللجنة
    /// 0 تم التشكيل ولم يتم خروج اللجنة
    /// 1 انتهاء عمل اللجنة
    /// 
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1  خاص ب شغل موظف الحجر في فحص الشحنه
    /// </summary>
    public bool? IsFinishedAll { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal AmountTotal { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool? IsPaid { get; set; }

    public byte? ShiftTimingId { get; set; }

    /// <summary>
    /// تعزر عمل اللجنه
    /// </summary>
    public bool? IsCancel { get; set; }

    /// <summary>
    /// اسباب الرفض
    /// </summary>
    public string? RefuseReasonNots { get; set; }

    /// <summary>
    /// تعزر عمل اللجنه
    /// </summary>
    public bool? IsStartAndroid { get; set; }

    public virtual CommitteeType? CommitteeType { get; set; }

    public virtual ICollection<FarmCommitteeCheckList> FarmCommitteeCheckLists { get; set; } = new List<FarmCommitteeCheckList>();

    public virtual ICollection<FarmCommitteeConstrain> FarmCommitteeConstrains { get; set; } = new List<FarmCommitteeConstrain>();

    public virtual ICollection<FarmCommitteeExamination> FarmCommitteeExaminations { get; set; } = new List<FarmCommitteeExamination>();

    public virtual ICollection<FarmCommitteeFinalResult> FarmCommitteeFinalResults { get; set; } = new List<FarmCommitteeFinalResult>();

    public virtual ICollection<FarmCommitteeShift> FarmCommitteeShifts { get; set; } = new List<FarmCommitteeShift>();

    public virtual FarmRequest FarmRequest { get; set; } = null!;

    public virtual ICollection<FarmSampleDatum> FarmSampleData { get; set; } = new List<FarmSampleDatum>();

    public virtual ICollection<FarmSampleDataItem> FarmSampleDataItems { get; set; } = new List<FarmSampleDataItem>();
}
