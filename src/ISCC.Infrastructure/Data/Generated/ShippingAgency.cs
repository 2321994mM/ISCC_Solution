using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ShippingAgency
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

    public virtual ICollection<ExCheckRequestCustomsMessage> ExCheckRequestCustomsMessages { get; set; } = new List<ExCheckRequestCustomsMessage>();

    public virtual ICollection<ImCheckRequestCustomsMessage> ImCheckRequestCustomsMessages { get; set; } = new List<ImCheckRequestCustomsMessage>();
}
