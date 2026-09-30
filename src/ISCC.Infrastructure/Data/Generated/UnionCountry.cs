using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الاتحادات الدولية
/// </summary>
public partial class UnionCountry
{
    public short Id { get; set; }

    /// <summary>
    /// الدولة
    /// </summary>
    public short CountryId { get; set; }

    /// <summary>
    /// الاتحاد
    /// </summary>
    public short UnionId { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Union Union { get; set; } = null!;
}
