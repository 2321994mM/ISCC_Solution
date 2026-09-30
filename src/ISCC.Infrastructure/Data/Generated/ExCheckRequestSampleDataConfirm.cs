using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestSampleDataConfirm
{
    public long Id { get; set; }

    public long ExCheckRequestSampleDataId { get; set; }

    public DateTime Date { get; set; }

    public short EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ExCheckRequestSampleDatum ExCheckRequestSampleData { get; set; } = null!;
}
