using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationCommittee
{
    public long StationAccreditationCommitteeId { get; set; }

    public long StationAccreditationRequestId { get; set; }

    public DateOnly? DelegationDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsPaid { get; set; }

    public bool? Status { get; set; }

    public bool? IsAccepted { get; set; }

    public bool? IsStartAndroid { get; set; }

    public bool? IsCancel { get; set; }

    public short? CommitteeUserDeletionId { get; set; }
}
