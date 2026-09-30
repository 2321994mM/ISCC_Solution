using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationAccreditationCommitteeFinalResult
{
    public long Id { get; set; }

    /// <summary>
    /// لجنة المعالجة
    /// </summary>
    public long StationAccreditationCommitteeId { get; set; }

    public long EmployeeId { get; set; }

    /// <summary>
    /// is admin for the current committee
    /// </summary>
    public bool Isadmin { get; set; }

    public string? NotesCheckList { get; set; }

    public string? NotesFinal { get; set; }

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
    /// is admin for the current committee
    /// </summary>
    public bool? IsAccepted { get; set; }

    public virtual StationAccreditationCommittee StationAccreditationCommittee { get; set; } = null!;
}
