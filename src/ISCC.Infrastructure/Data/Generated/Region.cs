using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المناطق
/// </summary>
public partial class Region
{
    public long Id { get; set; }

    /// <summary>
    /// الدولة
    /// </summary>
    public short? CountryId { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? DescreptionEn { get; set; }

    public string? DescreptionAr { get; set; }

    /// <summary>
    /// قارة
    /// </summary>
    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<PortInternational> PortInternationals { get; set; } = new List<PortInternational>();
}
