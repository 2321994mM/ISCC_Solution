using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationDistributionMessage
{
    public long Id { get; set; }

    public long DistributionId { get; set; }

    public string MessageText { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ImFumigationDistribution Distribution { get; set; } = null!;
}
