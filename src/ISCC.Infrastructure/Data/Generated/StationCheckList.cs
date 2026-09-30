using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شروط الاندريد
/// </summary>
public partial class StationCheckList
{
    public long Id { get; set; }

    public string? ConstrainTextAr { get; set; }

    public string? ConstrainTextEn { get; set; }

    public string? DescriptionAr { get; set; }

    public string? DescriptionEn { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public string? NumberCheck { get; set; }

    /// <summary>
    /// شهادة الصحة النباتية
    /// </summary>
    public bool IsAndroud { get; set; }

    public byte? StationConstrainCountryItemId { get; set; }

    public virtual ICollection<StationAccreditationCheckList> StationAccreditationCheckLists { get; set; } = new List<StationAccreditationCheckList>();

    public virtual StationConstrainCountryItem? StationConstrainCountryItem { get; set; }
}
