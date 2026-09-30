using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationRequst
{
    public long StationAccreditationDataId { get; set; }

    public byte StationAccreditationRequestTypeId { get; set; }

    public bool? StationAccreditationRequestIsactive { get; set; }

    public bool? StationAccreditationRequestIspaid { get; set; }

    public bool? StationAccreditationRequestIsAccepted { get; set; }

    public bool? IsFinalRequst { get; set; }

    public string? StationAccreditationDataName { get; set; }

    public bool? StationAccreditationDataIsActive { get; set; }

    public string? StationAccreditationRequestTypeName { get; set; }

    public bool? StationAccreditationRequestTypeIsActive { get; set; }

    public long StationId { get; set; }

    public long StationAccreditationRequestId { get; set; }

    public int? AccreditationTypeId { get; set; }

    public byte? StationActivityTypeId { get; set; }

    public short? RequestUserDeletionId { get; set; }
}
