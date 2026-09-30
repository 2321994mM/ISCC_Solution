using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExRequestTreatmentDataConfirm
{
    public long Id { get; set; }

    public long ExRequestTreatmentDataId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ExRequestTreatmentDatum ExRequestTreatmentData { get; set; } = null!;
}
