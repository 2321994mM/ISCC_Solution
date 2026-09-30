using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCommitteeResultInfection
{
    public long Id { get; set; }

    public long ExCommitteeResultId { get; set; }

    public long ItemId { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ExCommitteeResult ExCommitteeResult { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
