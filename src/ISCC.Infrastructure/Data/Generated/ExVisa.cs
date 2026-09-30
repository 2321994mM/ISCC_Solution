using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// التاشيره
/// </summary>
public partial class ExVisa
{
    public long Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsActive { get; set; }

    public string? DescriptionAr { get; set; }

    public string? DescriptionEn { get; set; }

    public virtual ICollection<ExCheckRequestVisa> ExCheckRequestVisas { get; set; } = new List<ExCheckRequestVisa>();
}
