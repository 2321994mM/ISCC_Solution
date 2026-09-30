using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationAccreditationRequestType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<StationAccreditationRequest> StationAccreditationRequests { get; set; } = new List<StationAccreditationRequest>();
}
