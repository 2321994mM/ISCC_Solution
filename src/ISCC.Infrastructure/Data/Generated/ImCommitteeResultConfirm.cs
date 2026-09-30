using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// راي المساعد
/// </summary>
public partial class ImCommitteeResultConfirm
{
    public long Id { get; set; }

    public long ImCommitteeResultId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ImCommitteeResult ImCommitteeResult { get; set; } = null!;
}
