using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImRequestTreatmentDataConfirm
{
    public long Id { get; set; }

    public long ImRequestTreatmentDataId { get; set; }

    public DateTime Date { get; set; }

    public long EmployeeId { get; set; }

    public string? Notes { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ImRequestTreatmentDatum ImRequestTreatmentData { get; set; } = null!;
}
