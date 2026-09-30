using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// ميناء محلى
/// </summary>
public partial class PortNational
{
    /// <summary>
    /// الميناء
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    /// <summary>
    /// المحافظة
    /// </summary>
    public short GovernId { get; set; }

    /// <summary>
    /// هيئات المواني
    /// </summary>
    public int PortOrgainzationId { get; set; }

    /// <summary>
    /// نوع الميناء
    /// </summary>
    public byte PortTypeId { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaces { get; set; } = new List<ExCheckRequestPlace>();

    public virtual Governate Govern { get; set; } = null!;

    public virtual ICollection<ImCountryConstrainArrivalPort> ImCountryConstrainArrivalPorts { get; set; } = new List<ImCountryConstrainArrivalPort>();

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ICollection<ImScientificResearch> ImScientificResearches { get; set; } = new List<ImScientificResearch>();

    public virtual PortOrganization PortOrgainzation { get; set; } = null!;

    public virtual PortType PortType { get; set; } = null!;
}
