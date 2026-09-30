using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationAccreditationRequestFeesEng
{
    public long Id { get; set; }

    public long StationAccreditationCommitteeId { get; set; }

    public int StationFeesTypeId { get; set; }

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

    public virtual StationAccreditationCommittee StationAccreditationCommittee { get; set; } = null!;

    public virtual StationFeesType StationFeesType { get; set; } = null!;
}
