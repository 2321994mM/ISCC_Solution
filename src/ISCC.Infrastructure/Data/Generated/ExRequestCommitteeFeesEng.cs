using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExRequestCommitteeFeesEng
{
    public long Id { get; set; }

    public long ExRequestCommitteeId { get; set; }

    public int ExFeesTypeId { get; set; }

    public decimal? Value { get; set; }

    public bool? IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool? IsPaid { get; set; }

    public int? NumEng { get; set; }

    public virtual ExFeesType ExFeesType { get; set; } = null!;

    public virtual ExRequestCommittee ExRequestCommittee { get; set; } = null!;
}
