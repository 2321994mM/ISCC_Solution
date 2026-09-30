using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmCommitteeCheckListConfirm
{
    public long Id { get; set; }

    public long FarmCommitteeCheckListId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual FarmCommitteeCheckList FarmCommitteeCheckList { get; set; } = null!;
}
