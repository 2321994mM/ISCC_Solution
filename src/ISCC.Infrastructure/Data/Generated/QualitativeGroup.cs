using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// مجموعة النوعية
/// </summary>
public partial class QualitativeGroup
{
    public short Id { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionEn { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionAr { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsPallet { get; set; }

    public virtual ICollection<ImCountryConstrainArrivalPort> ImCountryConstrainArrivalPorts { get; set; } = new List<ImCountryConstrainArrivalPort>();

    public virtual ICollection<ItemShortName> ItemShortNames { get; set; } = new List<ItemShortName>();
}
