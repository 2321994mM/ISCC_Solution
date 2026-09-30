using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شركات الشحن الدولية
/// </summary>
public partial class ShippingCompany
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

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ExCheckRequestDatum> ExCheckRequestData { get; set; } = new List<ExCheckRequestDatum>();

    public virtual ICollection<ImCheckRequestDatum> ImCheckRequestData { get; set; } = new List<ImCheckRequestDatum>();
}
