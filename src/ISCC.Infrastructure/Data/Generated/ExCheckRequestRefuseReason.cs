using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestRefuseReason
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    public short RefuseReasonId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long UserCreationId { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;

    public virtual RefuseReason RefuseReason { get; set; } = null!;
}
