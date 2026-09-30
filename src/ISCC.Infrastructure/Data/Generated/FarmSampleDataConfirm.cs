using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmSampleDataConfirm
{
    public long Id { get; set; }

    public long FarmSampleDataId { get; set; }

    public DateTime Date { get; set; }

    public short EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual FarmSampleDatum FarmSampleData { get; set; } = null!;
}
