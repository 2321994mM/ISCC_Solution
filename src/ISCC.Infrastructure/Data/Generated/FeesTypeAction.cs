using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// انواع الاجراءات
/// </summary>
public partial class FeesTypeAction
{
    public byte Id { get; set; }

    public byte? FeesProcessId { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? TableName { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<FeesAction> FeesActions { get; set; } = new List<FeesAction>();

    public virtual FeesProcess? FeesProcess { get; set; }
}
