using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// النبات و المنتجات
/// </summary>
public partial class Item
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

    public string? ScientificName { get; set; }

    public int? FamilyId { get; set; }

    public int? GroupId { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionAr { get; set; }

    /// <summary>
    /// وصف أو تنويه
    /// </summary>
    public string? DescreptionEn { get; set; }

    public string? Picture { get; set; }

    /// <summary>
    /// 0 مسموح به
    /// 1 ممنوع 
    /// 
    /// </summary>
    public bool IsForbidden { get; set; }

    public string? ForbiddenReason { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// هل له اذن استيراد -خاص بالوارد
    /// </summary>
    public bool? IsPermissionRequest { get; set; }

    public byte? ItemTypeId { get; set; }

    /// <summary>
    /// معروف وغير معروف
    /// </summary>
    public bool? IsKnownItem { get; set; }

    public bool? IsPlantInEgypt { get; set; }

    public string? ItemCode { get; set; }

    public bool? Agriculture17 { get; set; }

    public string? Hscode { get; set; }

    public virtual ICollection<ExCommitteeResultInfection> ExCommitteeResultInfections { get; set; } = new List<ExCommitteeResultInfection>();

    public virtual Family? Family { get; set; }

    public virtual ICollection<FarmConstrain> FarmConstrains { get; set; } = new List<FarmConstrain>();

    public virtual ICollection<FarmCountryCheckList> FarmCountryCheckLists { get; set; } = new List<FarmCountryCheckList>();

    public virtual ICollection<FarmsDatum> FarmsData { get; set; } = new List<FarmsDatum>();

    public virtual Group? Group { get; set; }

    public virtual ICollection<ImCommitteeResultInfection> ImCommitteeResultInfections { get; set; } = new List<ImCommitteeResultInfection>();

    public virtual ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

    public virtual ICollection<ItemPart> ItemParts { get; set; } = new List<ItemPart>();

    public virtual ICollection<ItemShortName> ItemShortNames { get; set; } = new List<ItemShortName>();

    public virtual ICollection<TreatmentMaterial> TreatmentMaterials { get; set; } = new List<TreatmentMaterial>();
}
