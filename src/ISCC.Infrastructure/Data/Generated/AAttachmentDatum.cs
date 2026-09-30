using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// باص الملفات
/// </summary>
public partial class AAttachmentDatum
{
    public long Id { get; set; }

    public short? AAttachmentTableTypeId { get; set; }

    public short AAttachmentTableNameId { get; set; }

    public long RowId { get; set; }

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

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual AAttachmentTableName AAttachmentTableName { get; set; } = null!;

    public virtual AAttachmentTableType? AAttachmentTableType { get; set; }
}
