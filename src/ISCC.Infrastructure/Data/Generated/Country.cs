using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الدول
/// </summary>
public partial class Country
{
    public short Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    public bool IsIppc { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte? ContinentsId { get; set; }

    public byte? RegionalAreaId { get; set; }

    public virtual ICollection<CompanyAccreditation> CompanyAccreditations { get; set; } = new List<CompanyAccreditation>();

    public virtual Continent? Continents { get; set; }

    public virtual ICollection<ExCheckRequestDatum> ExCheckRequestData { get; set; } = new List<ExCheckRequestDatum>();

    public virtual ICollection<FarmConstrain> FarmConstrains { get; set; } = new List<FarmConstrain>();

    public virtual ICollection<FarmCountry> FarmCountries { get; set; } = new List<FarmCountry>();

    public virtual ICollection<FarmCountryCheckList> FarmCountryCheckLists { get; set; } = new List<FarmCountryCheckList>();

    public virtual ICollection<ImCheckRequestDatum> ImCheckRequestData { get; set; } = new List<ImCheckRequestDatum>();

    public virtual ICollection<ImInitiator> ImInitiators { get; set; } = new List<ImInitiator>();

    public virtual ICollection<ImRequestDatum> ImRequestData { get; set; } = new List<ImRequestDatum>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<PortInternational> PortInternationals { get; set; } = new List<PortInternational>();

    public virtual RegionalArea? RegionalArea { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    public virtual ICollection<StationAccreditationDataCountry> StationAccreditationDataCountries { get; set; } = new List<StationAccreditationDataCountry>();

    public virtual ICollection<UnionCountry> UnionCountries { get; set; } = new List<UnionCountry>();
}
