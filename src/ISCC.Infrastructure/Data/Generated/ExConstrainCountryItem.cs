using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// انواع الاشتراطات
/// </summary>
public partial class ExConstrainCountryItem
{
    public byte Id { get; set; }

    public byte ExConstrainTypeId { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// مفعل
    /// </summary>
    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ExConstrainText> ExConstrainTexts { get; set; } = new List<ExConstrainText>();

    public virtual ExConstrainType ExConstrainType { get; set; } = null!;
}
