using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// وسائل اتصال المحطة
/// </summary>
public partial class StationContact
{
    public int Id { get; set; }

    public long StationId { get; set; }

    /// <summary>
    /// نوع وسيلة الاتصال
    /// </summary>
    public byte ContactTypeId { get; set; }

    /// <summary>
    /// الرقم
    /// </summary>
    public string Value { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual Station Station { get; set; } = null!;
}
