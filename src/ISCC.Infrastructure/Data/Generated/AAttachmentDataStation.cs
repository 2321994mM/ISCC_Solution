using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اسم الجدول
/// </summary>
public partial class AAttachmentDataStation
{
    public long Id { get; set; }

    /// <summary>
    /// نوع المرفق
    /// </summary>
    public short? AAttachmentTableTypeId { get; set; }

    /// <summary>
    /// اسم الجدول
    /// </summary>
    public short AAttachmentTableNameId { get; set; }

    /// <summary>
    /// الرقم داخل الجدول
    /// </summary>
    public long RowId { get; set; }

    /// <summary>
    /// رقم المرفق
    /// </summary>
    public string? AttachmentNumber { get; set; }

    /// <summary>
    /// اسم المرفق
    /// </summary>
    public string? AttachmentTypeName { get; set; }

    /// <summary>
    /// مسار المرفق
    /// </summary>
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
