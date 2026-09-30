using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
///  
/// </summary>
public partial class LiableItem
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// كائنات حية/غير حية
    /// </summary>
    public int IsAlive { get; set; }

    public short? LiableItemsStrainId { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// هل له اذن استيراد -خاص بالوارد
    /// </summary>
    public bool? IsPermissionRequest { get; set; }

    public virtual ASystemCode IsAliveNavigation { get; set; } = null!;

    public virtual ICollection<LiableItemsShortName> LiableItemsShortNames { get; set; } = new List<LiableItemsShortName>();

    public virtual ItemCategoriesType? LiableItemsStrain { get; set; }
}
