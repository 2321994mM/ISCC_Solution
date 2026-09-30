using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImPermissionRequestRefuseReason
{
    public long Id { get; set; }

    public long ImPermissionRequestId { get; set; }

    public short RefuseReasonId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long UserCreationId { get; set; }

    public string? Nots { get; set; }

    public bool? Isactive { get; set; }

    public virtual ImPermissionRequest ImPermissionRequest { get; set; } = null!;

    public virtual RefuseReason RefuseReason { get; set; } = null!;
}
