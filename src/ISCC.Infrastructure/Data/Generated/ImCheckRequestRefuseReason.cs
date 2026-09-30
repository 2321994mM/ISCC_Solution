using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اسباب رفض الطلب وارد
/// </summary>
public partial class ImCheckRequestRefuseReason
{
    public long Id { get; set; }

    public long ImCheckRequestId { get; set; }

    public short RefuseReasonId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long UserCreationId { get; set; }

    public virtual ImCheckRequest ImCheckRequest { get; set; } = null!;

    public virtual RefuseReason RefuseReason { get; set; } = null!;
}
