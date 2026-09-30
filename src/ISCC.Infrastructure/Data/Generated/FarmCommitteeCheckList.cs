using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmCommitteeCheckList
{
    public long Id { get; set; }

    /// <summary>
    /// لجنة المعالجة
    /// </summary>
    public long FarmCommitteeId { get; set; }

    public long FarmCountryCheckListId { get; set; }

    public long? EmployeeId { get; set; }

    public string? NotesAr { get; set; }

    public string? NotesEn { get; set; }

    /// <summary>
    /// 0 if rejected else 1 
    /// lab will set the result
    /// </summary>
    public bool? IsAccepted { get; set; }

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
    /// </summary>
    public bool? IsAcceptedQuarantine { get; set; }

    public long? EmployeeIdQuarantine { get; set; }

    public virtual FarmCommittee FarmCommittee { get; set; } = null!;

    public virtual ICollection<FarmCommitteeCheckListConfirm> FarmCommitteeCheckListConfirms { get; set; } = new List<FarmCommitteeCheckListConfirm>();

    public virtual FarmCountryCheckList FarmCountryCheckList { get; set; } = null!;
}
