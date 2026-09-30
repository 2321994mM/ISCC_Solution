using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شركة محلية
/// </summary>
public partial class CompanyNational
{
    public long Id { get; set; }

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
    public string? AddressAr { get; set; }

    /// <summary>
    /// العنوان بالانجليزية
    /// </summary>
    public string? AddressEn { get; set; }

    /// <summary>
    /// السجل الضريبي
    /// </summary>
    public string? TaxesRecord { get; set; }

    /// <summary>
    /// السجل التجاري
    /// </summary>
    public string? CommertialRecord { get; set; }

    /// <summary>
    /// it was deleted and i returned it again fz 8-9-2019
    /// </summary>
    public bool IsTreatment { get; set; }

    public bool? IsActive { get; set; }

    /// <summary>
    /// from web/system
    /// 1-&gt;online
    /// 0-&gt;offline
    /// </summary>
    public bool? IsOnlineOffline { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string OwnerAr { get; set; } = null!;

    /// <summary>
    /// null-&gt;Company request 
    /// 0-&gt;not accepted
    /// 1-&gt;Aceecpted
    ///  
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? OwnerEn { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    public short? UserActivationId { get; set; }

    public DateTime? UserActivationDate { get; set; }

    public virtual Center? Center { get; set; }

    public virtual ICollection<CompanyAccreditation> CompanyAccreditations { get; set; } = new List<CompanyAccreditation>();

    public virtual ICollection<CompanyActivity> CompanyActivities { get; set; } = new List<CompanyActivity>();

    public virtual ICollection<GasImportCompany> GasImportCompanies { get; set; } = new List<GasImportCompany>();

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

    public virtual ICollection<SteamingCompany> SteamingCompanies { get; set; } = new List<SteamingCompany>();

    public virtual Village? Village { get; set; }
}
