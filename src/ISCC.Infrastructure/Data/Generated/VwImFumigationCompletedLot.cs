using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class VwImFumigationCompletedLot
{
    public int FumigationId { get; set; }

    public long RequestId { get; set; }

    public long LotId { get; set; }

    public string? LotNumber { get; set; }

    public long? FinalLotResultId { get; set; }

    public int? SavedStatus { get; set; }

    public string? SavedNotes { get; set; }
}
