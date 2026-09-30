using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الموافقة على نتيجة الفحص
/// </summary>
public partial class FarmCommitteeExaminationConfirm
{
    public long Id { get; set; }

    public long FarmCommitteeExminationId { get; set; }

    public DateTime Date { get; set; }

    public short EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual FarmCommitteeExamination FarmCommitteeExmination { get; set; } = null!;
}
