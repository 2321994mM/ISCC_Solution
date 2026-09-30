using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmCountryCheckList
{
    public long Id { get; set; }

    public long FarmCheckListId { get; set; }

    public long? ItemId { get; set; }

    public short? CountryId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual FarmCheckList FarmCheckList { get; set; } = null!;

    public virtual ICollection<FarmCommitteeCheckList> FarmCommitteeCheckLists { get; set; } = new List<FarmCommitteeCheckList>();

    public virtual Item? Item { get; set; }
}
