using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنه المزرعه
/// </summary>
public partial class FarmCommitteeConstrain
{
    public long Id { get; set; }

    public long? FarmConstrainId { get; set; }

    public long? FarmCommitteeId { get; set; }

    public virtual FarmCommittee? FarmCommittee { get; set; }

    public virtual FarmConstrain? FarmConstrain { get; set; }
}
