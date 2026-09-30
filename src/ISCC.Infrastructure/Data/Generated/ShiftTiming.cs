using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ShiftTiming
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public TimeOnly? ShiftTimingFrom { get; set; }

    public TimeOnly? ShiftTimingTo { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// 0 ايام عطلات
    /// 1 ايام عادية
    /// 
    /// </summary>
    public byte? DayType { get; set; }

    public double? Count { get; set; }

    public virtual ICollection<ExRequestCommitteeShift> ExRequestCommitteeShifts { get; set; } = new List<ExRequestCommitteeShift>();

    public virtual ICollection<FarmCommitteeShift> FarmCommitteeShifts { get; set; } = new List<FarmCommitteeShift>();

    public virtual ICollection<ImRequestCommitteeShift> ImRequestCommitteeShifts { get; set; } = new List<ImRequestCommitteeShift>();

    public virtual ICollection<StationAccreditationCommitteeShift> StationAccreditationCommitteeShifts { get; set; } = new List<StationAccreditationCommitteeShift>();
}
