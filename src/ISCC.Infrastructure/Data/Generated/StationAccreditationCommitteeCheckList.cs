using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نتائج لجنة اعتماد المحطات
/// 
/// </summary>
public partial class StationAccreditationCommitteeCheckList
{
    public long Id { get; set; }

    /// <summary>
    /// لجنة سحب العينة
    /// </summary>
    public long CommitteeId { get; set; }

    public long StationAccreditationCheckListId { get; set; }

    public long? EmployeeId { get; set; }

    /// <summary>
    /// 0 if rejected else 1 
    /// lab will set the result
    /// </summary>
    public bool? IsAccepted { get; set; }

    public string? NotesAr { get; set; }

    public string? NotesEn { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// Employee ID
    /// </summary>
    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    /// <summary>
    /// 0 if rejected else 1 
    /// lab will set the result
    /// موقف الحجر
    /// 
    /// </summary>
    public bool? IsAcceptedQuarantine { get; set; }

    /// <summary>
    /// ملاحظات الحجر
    /// </summary>
    public string? NotesQuarantine { get; set; }

    public virtual StationAccreditationCommittee Committee { get; set; } = null!;

    public virtual StationAccreditationCheckList StationAccreditationCheckList { get; set; } = null!;

    public virtual ICollection<StationAccreditationCommitteeCheckListConfirm> StationAccreditationCommitteeCheckListConfirms { get; set; } = new List<StationAccreditationCommitteeCheckListConfirm>();
}
