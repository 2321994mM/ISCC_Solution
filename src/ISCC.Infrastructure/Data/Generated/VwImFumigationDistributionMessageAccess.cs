using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class VwImFumigationDistributionMessageAccess
{
    public long DistributionId { get; set; }

    public int FumigationId { get; set; }

    public long? RequestOutletId { get; set; }

    public int? RequestCreatorId { get; set; }

    public int? SupervisorUserId { get; set; }

    public string CheckRequestNumber { get; set; } = null!;

    public bool? CanSend { get; set; }
}
