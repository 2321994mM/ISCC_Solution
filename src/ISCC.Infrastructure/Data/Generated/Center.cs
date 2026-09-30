using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المراكز
/// </summary>
public partial class Center
{
    public short Id { get; set; }

    /// <summary>
    /// المحافظة
    /// </summary>
    public short? GovernId { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// مفعل
    /// </summary>
    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// المنافذ
    /// </summary>
    public long? OutletId { get; set; }

    public virtual ICollection<CompanyNational> CompanyNationals { get; set; } = new List<CompanyNational>();

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaces { get; set; } = new List<ExCheckRequestPlace>();

    public virtual ICollection<FarmsDatum> FarmsData { get; set; } = new List<FarmsDatum>();

    public virtual Governate? Govern { get; set; }

    public virtual Outlet? Outlet { get; set; }

    public virtual ICollection<Village> Villages { get; set; } = new List<Village>();
}
