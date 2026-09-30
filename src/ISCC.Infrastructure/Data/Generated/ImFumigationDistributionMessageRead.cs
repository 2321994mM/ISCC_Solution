using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationDistributionMessageRead
{
    public long DistributionId { get; set; }

    public int UserId { get; set; }

    public long LastReadMessageId { get; set; }

    public DateTime ReadAt { get; set; }

    public virtual ImFumigationDistribution Distribution { get; set; } = null!;
}
