using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المسمى المختصر للاعتماد
/// </summary>
public partial class StationAccreditationDataItemShortName
{
    public long Id { get; set; }

    public long StationAccreditationDataId { get; set; }

    public long ItemShortNameId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ItemShortName ItemShortName { get; set; } = null!;

    public virtual StationAccreditationDatum StationAccreditationData { get; set; } = null!;
}
