using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCommitteeResultConfirm
{
    public long Id { get; set; }

    public long ExCommitteeResultId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ExCommitteeResult ExCommitteeResult { get; set; } = null!;
}
