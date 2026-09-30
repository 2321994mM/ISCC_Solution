using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class PublicOrganizationType
{
    public int Id { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// معفى من طلب إذن استيراد
    /// </summary>
    public bool IsExempt { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public virtual ICollection<PublicOrganization> PublicOrganizations { get; set; } = new List<PublicOrganization>();
}
