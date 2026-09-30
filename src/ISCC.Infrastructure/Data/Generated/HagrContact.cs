using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class HagrContact
{
    public int Id { get; set; }

    public long ContactOwnerId { get; set; }

    /// <summary>
    /// from systemcode table 5
    /// </summary>
    public int OutlitAdmin { get; set; }

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

    public virtual ASystemCode OutlitAdminNavigation { get; set; } = null!;
}
