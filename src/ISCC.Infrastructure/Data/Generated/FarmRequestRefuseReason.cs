using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmRequestRefuseReason
{
    public long Id { get; set; }

    public long FarmRequestId { get; set; }

    public short? RefuseReasonId { get; set; }

    public string? Nots { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual FarmRequest FarmRequest { get; set; } = null!;

    public virtual RefuseReason? RefuseReason { get; set; }
}
