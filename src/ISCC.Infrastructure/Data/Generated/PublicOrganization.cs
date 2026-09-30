using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الهيئات العامة
/// </summary>
public partial class PublicOrganization
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

    public int? PublicOrgTypeId { get; set; }

    public bool IsNational { get; set; }

    public bool? IsActive { get; set; }

    /// <summary>
    /// from web/system
    /// 1-&gt;online
    /// 0-&gt;offline
    /// </summary>
    public bool? IsOnlineOffline { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    public short? PersonResponsibleCountryId { get; set; }

    public string? PersonResponsibleName { get; set; }

    public string? PersonResponsibleJob { get; set; }

    public string? PersonResponsibleAddress { get; set; }

    public int? PersonIdtype { get; set; }

    public string? PersonResponsibleIdnumber { get; set; }

    public short? UserActivationId { get; set; }

    public DateTime? UserActivationDate { get; set; }

    public virtual PublicOrganizationType? PublicOrgType { get; set; }
}
