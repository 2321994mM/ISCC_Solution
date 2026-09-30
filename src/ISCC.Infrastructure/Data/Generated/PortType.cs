using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// أنواع المواني
/// </summary>
public partial class PortType
{
    public byte Id { get; set; }

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

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionEn { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<PortInternational> PortInternationals { get; set; } = new List<PortInternational>();

    public virtual ICollection<PortNational> PortNationals { get; set; } = new List<PortNational>();
}
