using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نوع الصنف نبات, منتج, بند حي...
/// </summary>
public partial class ItemType
{
    public byte Id { get; set; }

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public string? Coler { get; set; }

    public virtual ICollection<MainCalssification> MainCalssifications { get; set; } = new List<MainCalssification>();
}
