using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المسمى المختصر
/// </summary>
public partial class ItemShortName
{
    public long Id { get; set; }

    /// <summary>
    /// الصنف
    /// </summary>
    public long? ItemId { get; set; }

    /// <summary>
    /// الجزء النباتى او الطور الحيوى
    /// </summary>
    public int? SubPartId { get; set; }

    /// <summary>
    /// الحالة
    /// </summary>
    public int? ItemStatusId { get; set; }

    /// <summary>
    /// الغرض
    /// </summary>
    public int? ItemPurposeId { get; set; }

    /// <summary>
    /// الاسم العربى
    /// </summary>
    public string? ShortNameAr { get; set; }

    /// <summary>
    /// الاسم الاجنبى
    /// </summary>
    public string? ShortNameEn { get; set; }

    /// <summary>
    /// الموقف من التصدير
    /// </summary>
    public bool ExportStatus { get; set; }

    /// <summary>
    /// الموقف من الاستيراد
    /// </summary>
    public bool ImportStatus { get; set; }

    /// <summary>
    /// سبب الايقاف
    /// </summary>
    public string? Reason { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// له اسم مختصر ام لا
    /// </summary>
    public bool? IsShortName { get; set; }

    /// <summary>
    /// مجموعة نوعية
    /// </summary>
    public short? QualitativeGroupId { get; set; }

    public byte? ItemTypeId { get; set; }

    /// <summary>
    /// معفي من اذن الاستيراد
    /// </summary>
    public bool? IsImportTaxFree { get; set; }

    /// <summary>
    /// المنتج
    /// </summary>
    public long? ProductId { get; set; }

    public long? ItemCategoriesGroupId { get; set; }

    public string? Hscode { get; set; }

    public virtual ICollection<CompanyAccreditation> CompanyAccreditations { get; set; } = new List<CompanyAccreditation>();

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<ExCheckRequestOrganizationDistributionMaster> ExCheckRequestOrganizationDistributionMasters { get; set; } = new List<ExCheckRequestOrganizationDistributionMaster>();

    public virtual ICollection<ExChooseSampleDatum> ExChooseSampleData { get; set; } = new List<ExChooseSampleDatum>();

    public virtual ICollection<ExCommitteeResult> ExCommitteeResults { get; set; } = new List<ExCommitteeResult>();

    public virtual ICollection<ExCountryConstrain> ExCountryConstrains { get; set; } = new List<ExCountryConstrain>();

    public virtual ICollection<ImCommitteeResult> ImCommitteeResults { get; set; } = new List<ImCommitteeResult>();

    public virtual ICollection<ImCountryConstrainArrivalPort> ImCountryConstrainArrivalPorts { get; set; } = new List<ImCountryConstrainArrivalPort>();

    public virtual ICollection<ImInitiator> ImInitiators { get; set; } = new List<ImInitiator>();

    public virtual Item? Item { get; set; }

    public virtual ItemPurpose? ItemPurpose { get; set; }

    public virtual ItemStatus? ItemStatus { get; set; }

    public virtual QualitativeGroup? QualitativeGroup { get; set; }

    public virtual ICollection<StationAccreditationDataItemShortName> StationAccreditationDataItemShortNames { get; set; } = new List<StationAccreditationDataItemShortName>();

    public virtual SubPart? SubPart { get; set; }
}
