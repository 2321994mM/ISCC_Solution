using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نبطشيات اللجنه
/// </summary>
public partial class ImRequestCommitteeShift
{
    public long Id { get; set; }

    public long ImRequestCommitteeId { get; set; }

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

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;

    public virtual ShiftTiming ShiftTiming { get; set; } = null!;
}
