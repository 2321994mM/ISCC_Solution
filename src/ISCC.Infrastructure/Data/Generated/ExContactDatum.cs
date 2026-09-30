using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// وسائل اتصال المصدر
/// </summary>
public partial class ExContactDatum
{
    public long Id { get; set; }

    /// <summary>
    /// المصدر(شركة أو هيئه عامة)
    /// </summary>
    public long ExporterId { get; set; }

    /// <summary>
    /// نوع وسيلة الاتصال
    /// </summary>
    public byte ContactTypeId { get; set; }

    /// <summary>
    /// 0 if National company/ 1 if Public Organization
    /// </summary>
    public int ExporterTypeId { get; set; }

    /// <summary>
    /// الرقم
    /// </summary>
    public string Value { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual ASystemCode ExporterType { get; set; } = null!;
}
