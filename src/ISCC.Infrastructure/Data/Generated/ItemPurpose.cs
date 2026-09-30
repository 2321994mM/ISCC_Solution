using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الغرض
/// </summary>
public partial class ItemPurpose
{
    public int Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionAr { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionEn { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte? ItemTypeId { get; set; }

    public virtual ICollection<ItemShortName> ItemShortNames { get; set; } = new List<ItemShortName>();

    public virtual ICollection<LiableItemsShortName> LiableItemsShortNames { get; set; } = new List<LiableItemsShortName>();
}
