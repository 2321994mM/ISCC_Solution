using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المواني الدوليه
/// </summary>
public partial class PortInternational
{
    public int Id { get; set; }

    /// <summary>
    /// الدولة
    /// </summary>
    public short? CountryId { get; set; }

    /// <summary>
    /// نوع الميناء
    /// </summary>
    public byte? PortTypeId { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? RegionsId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<ExCountryConstrainArrivalPort> ExCountryConstrainArrivalPorts { get; set; } = new List<ExCountryConstrainArrivalPort>();

    public virtual PortType? PortType { get; set; }

    public virtual Region? Regions { get; set; }
}
