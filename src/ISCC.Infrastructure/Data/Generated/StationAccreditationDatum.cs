using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// مسمى الاعتماد
/// </summary>
public partial class StationAccreditationDatum
{
    public long Id { get; set; }

    /// <summary>
    /// نوع النشاط
    /// </summary>
    public byte? StationActivityTypeId { get; set; }

    /// <summary>
    /// A_SystemCode id =21
    /// </summary>
    public int? AccreditationTypeId { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    /// <summary>
    /// العنوان بالعربية
    /// </summary>
    public string? DescriptionAr { get; set; }

    /// <summary>
    /// العنوان بالانجليزية
    /// </summary>
    public string? DescriptionEn { get; set; }

    public string? DescriptionMoreAr { get; set; }

    public string? DescriptionMoreEn { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ASystemCode? AccreditationType { get; set; }

    public virtual ICollection<StationAccreditationCheckList> StationAccreditationCheckLists { get; set; } = new List<StationAccreditationCheckList>();

    public virtual ICollection<StationAccreditationDataCountry> StationAccreditationDataCountries { get; set; } = new List<StationAccreditationDataCountry>();

    public virtual ICollection<StationAccreditationDataItemShortName> StationAccreditationDataItemShortNames { get; set; } = new List<StationAccreditationDataItemShortName>();

    public virtual ICollection<StationAccreditationRequest> StationAccreditationRequests { get; set; } = new List<StationAccreditationRequest>();

    public virtual ICollection<StationAccreditation> StationAccreditations { get; set; } = new List<StationAccreditation>();

    public virtual StationActivityType? StationActivityType { get; set; }
}
