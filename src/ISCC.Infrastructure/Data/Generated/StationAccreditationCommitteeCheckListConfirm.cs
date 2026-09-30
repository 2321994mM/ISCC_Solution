using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الموافقة على نتيجة الفحص
/// </summary>
public partial class StationAccreditationCommitteeCheckListConfirm
{
    public long Id { get; set; }

    public long StationAccreditationCommitteeResultId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual StationAccreditationCommitteeCheckList StationAccreditationCommitteeResult { get; set; } = null!;
}
