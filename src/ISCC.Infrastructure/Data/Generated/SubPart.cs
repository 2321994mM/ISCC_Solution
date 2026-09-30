using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الجزء النباتي والطور الحيوى
/// </summary>
public partial class SubPart
{
    public int Id { get; set; }

    public byte? ItemTypeId { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionAr { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionEn { get; set; }

    /// <summary>
    /// مسموح/غير مسموح
    /// </summary>
    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public int? SubPartTypeId { get; set; }

    public virtual ICollection<ItemPart> ItemParts { get; set; } = new List<ItemPart>();

    public virtual ICollection<ItemShortName> ItemShortNames { get; set; } = new List<ItemShortName>();

    public virtual SubPartType? SubPartType { get; set; }
}
