using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCommitteeCheckLocation
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public virtual ICollection<ExRequestCommittee> ExRequestCommittees { get; set; } = new List<ExRequestCommittee>();
}
