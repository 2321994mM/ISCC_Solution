using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنة اعتماد المحطات
/// </summary>
public partial class StationAccreditationCommittee
{
    public long Id { get; set; }

    /// <summary>
    /// طلب الفحص
    /// </summary>
    public long StationAccreditationRequestId { get; set; }

    public byte CommitteeTypeId { get; set; }

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
    /// null-&gt;ask for accredation
    /// 0-&gt;not accepted
    /// 1-&gt;Accepted
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool? IsPaid { get; set; }

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

    public string? NotesRefuseEn { get; set; }

    public string? NotesRefuseAr { get; set; }

    /// <summary>
    /// 0 if rejected else 1 
    /// lab will set the result
    /// </summary>
    public bool? IsAccepted { get; set; }

    /// <summary>
    /// تعزر عمل اللجنه
    /// </summary>
    public bool? IsStartAndroid { get; set; }

    /// <summary>
    /// تعزر عمل اللجنه
    /// </summary>
    public bool? IsCancel { get; set; }

    public virtual CommitteeType CommitteeType { get; set; } = null!;

    public virtual ICollection<StationAccreditationCommitteeCheckList> StationAccreditationCommitteeCheckLists { get; set; } = new List<StationAccreditationCommitteeCheckList>();

    public virtual ICollection<StationAccreditationCommitteeFinalResult> StationAccreditationCommitteeFinalResults { get; set; } = new List<StationAccreditationCommitteeFinalResult>();

    public virtual ICollection<StationAccreditationCommitteeImge> StationAccreditationCommitteeImges { get; set; } = new List<StationAccreditationCommitteeImge>();

    public virtual ICollection<StationAccreditationCommitteeShift> StationAccreditationCommitteeShifts { get; set; } = new List<StationAccreditationCommitteeShift>();

    public virtual StationAccreditationRequest StationAccreditationRequest { get; set; } = null!;

    public virtual ICollection<StationAccreditationRequestFeesEng> StationAccreditationRequestFeesEngs { get; set; } = new List<StationAccreditationRequestFeesEng>();
}
