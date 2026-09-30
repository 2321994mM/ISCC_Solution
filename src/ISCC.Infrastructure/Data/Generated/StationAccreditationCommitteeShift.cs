using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationAccreditationCommitteeShift
{
    public long Id { get; set; }

    public long StationAccreditationCommitteeId { get; set; }

    public byte ShiftTimingId { get; set; }

    public byte? Count { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public bool? IsPaid { get; set; }

    public virtual ShiftTiming ShiftTiming { get; set; } = null!;

    public virtual StationAccreditationCommittee StationAccreditationCommittee { get; set; } = null!;
}
