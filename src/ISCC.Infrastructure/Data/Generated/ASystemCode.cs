using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ASystemCode
{
    public int Id { get; set; }

    public string? ValueName { get; set; }

    public string? ValueNameEn { get; set; }

    public int? SystemCodeTypeId { get; set; }

    public byte? Value { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CommitteeEmployee> CommitteeEmployees { get; set; } = new List<CommitteeEmployee>();

    public virtual ICollection<CommitteeType> CommitteeTypes { get; set; } = new List<CommitteeType>();

    public virtual ICollection<CompanyActivity> CompanyActivities { get; set; } = new List<CompanyActivity>();

    public virtual ICollection<ExContactDatum> ExContactData { get; set; } = new List<ExContactDatum>();

    public virtual ICollection<FeesAltahsil> FeesAltahsilAccountTypeNavigations { get; set; } = new List<FeesAltahsil>();

    public virtual ICollection<FeesAltahsil> FeesAltahsilPaymentTypes { get; set; } = new List<FeesAltahsil>();

    public virtual ICollection<HagrContact> HagrContacts { get; set; } = new List<HagrContact>();

    public virtual ICollection<ImRequestPort> ImRequestPortIsNationalNavigations { get; set; } = new List<ImRequestPort>();

    public virtual ICollection<ImRequestPort> ImRequestPortReqPortTypes { get; set; } = new List<ImRequestPort>();

    public virtual ICollection<ImScientificResearchItemPlantInseketLieble> ImScientificResearchItemPlantInseketLiebles { get; set; } = new List<ImScientificResearchItemPlantInseketLieble>();

    public virtual ICollection<ImScientificResearchItemPlantProduct> ImScientificResearchItemPlantProducts { get; set; } = new List<ImScientificResearchItemPlantProduct>();

    public virtual ICollection<ImWarehouse> ImWarehouses { get; set; } = new List<ImWarehouse>();

    public virtual ICollection<LiableItem> LiableItems { get; set; } = new List<LiableItem>();

    public virtual ICollection<Outlet> Outlets { get; set; } = new List<Outlet>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<StationAccreditationDatum> StationAccreditationData { get; set; } = new List<StationAccreditationDatum>();

    public virtual ASystemCodeType? SystemCodeType { get; set; }
}
