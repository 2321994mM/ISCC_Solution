using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الاعتمادات وقوائم الاندريد
/// </summary>
public partial class StationAccreditationCheckList
{
    public long Id { get; set; }

    public long StationAccreditationDataId { get; set; }

    public long StationCheckListId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ICollection<StationAccreditationCommitteeCheckList> StationAccreditationCommitteeCheckLists { get; set; } = new List<StationAccreditationCommitteeCheckList>();

    public virtual StationAccreditationDatum StationAccreditationData { get; set; } = null!;

    public virtual StationCheckList StationCheckList { get; set; } = null!;
}
