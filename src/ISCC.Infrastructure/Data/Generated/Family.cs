using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// العائله
/// </summary>
public partial class Family
{
    public int Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    public int? OrderId { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Order? Order { get; set; }
}
