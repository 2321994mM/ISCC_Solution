using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestManafest
{
    public long Id { get; set; }

    public long ImCheckRequestId { get; set; }

    public long ImManafest { get; set; }

    public virtual ImCheckRequest ImCheckRequest { get; set; } = null!;

    public virtual ImManafest ImManafestNavigation { get; set; } = null!;
}
