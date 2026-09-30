using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AAttachmentDataExCheckRequest
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    public short AAttachmentTableNameId { get; set; }

    public string? AttachmentNumber { get; set; }

    /// <summary>
    /// نوع المرفق
    /// </summary>
    public string? AttachmentTypeName { get; set; }

    public string? AttachmentPath { get; set; }

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateTime? EndDate { get; set; }

    public byte[]? AttachmentPathBinary { get; set; }

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? AAttachmentTableTypeId { get; set; }

    public virtual AAttachmentTableName AAttachmentTableName { get; set; } = null!;

    public virtual AAttachmentTableType? AAttachmentTableType { get; set; }
}
