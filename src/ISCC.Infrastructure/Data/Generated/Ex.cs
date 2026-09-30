using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class Ex
{
    public string CheckRequestNumber { get; set; } = null!;

    public long ExCheckRequestId { get; set; }

    public long? ExCheckRequestItemsId { get; set; }

    public byte? CommitteeTypeId { get; set; }

    public long CommitteeId { get; set; }

    public long? LotDataId { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsAdminResult { get; set; }

    public double? QuantitySize { get; set; }

    public double? Weight { get; set; }

    public string? Notes { get; set; }

    public bool? IsTotal { get; set; }

    public long? ItemShortNameId { get; set; }

    public DateOnly? DelegationDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool? IsFinishedAll { get; set; }

    public bool? Status { get; set; }

    public string? ShortNameAr { get; set; }

    public string? ShortNameEn { get; set; }

    public long? Expr1 { get; set; }

    public long ExCommitteeResultId { get; set; }

    public DateTime Expr2 { get; set; }

    public long EmployeeId { get; set; }

    public string? Expr3 { get; set; }

    public bool IsAccepted { get; set; }
}
