using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الإدارة العامة
/// </summary>
public partial class GeneralAdmin
{
    public byte Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// العنوان بالعربية
    /// </summary>
    public string? AddressAr { get; set; }

    /// <summary>
    /// العنوان بالانجليزية
    /// </summary>
    public string? AddressEn { get; set; }

    /// <summary>
    /// رئيس/مدير الإدارة
    /// from HR employee table
    /// </summary>
    public int? AdminId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? IdOrcael { get; set; }

    public long? HrSectorNo { get; set; }

    public virtual ICollection<Outlet> Outlets { get; set; } = new List<Outlet>();
}
