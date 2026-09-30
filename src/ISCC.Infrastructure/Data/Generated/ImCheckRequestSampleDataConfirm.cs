using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نتيجه سحب عينه للمساعد
/// </summary>
public partial class ImCheckRequestSampleDataConfirm
{
    public long Id { get; set; }

    public long ImCheckRequestSampleDataId { get; set; }

    public DateTime Date { get; set; }

    public short EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ImCheckRequestSampleDatum ImCheckRequestSampleData { get; set; } = null!;
}
