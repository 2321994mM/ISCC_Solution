using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// صور فحص الاصابه
/// </summary>
public partial class AAttachmentDataImCommitteeResultInfection
{
    public long Id { get; set; }

    public long ImCommitteeResultId { get; set; }

    /// <summary>
    /// نوع المرفق
    /// </summary>
    public string? InfectionComment { get; set; }

    public byte[]? AttachmentPathBinary { get; set; }

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public short? UserCreationId { get; set; }

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public DateTime? UserCreationDate { get; set; }

    public virtual ImCommitteeResult ImCommitteeResult { get; set; } = null!;
}
