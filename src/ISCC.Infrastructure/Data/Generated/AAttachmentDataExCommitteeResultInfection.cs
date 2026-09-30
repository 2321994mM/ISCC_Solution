using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AAttachmentDataExCommitteeResultInfection
{
    public long Id { get; set; }

    public long ExCommitteeResultId { get; set; }

    public string? InfectionComment { get; set; }

    public byte[]? AttachmentPathBinary { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public virtual ExCommitteeResult ExCommitteeResult { get; set; } = null!;
}
