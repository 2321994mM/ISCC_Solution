using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الاتحاد 
/// </summary>
public partial class Union
{
    public short Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string ArName { get; set; } = null!;

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string EnName { get; set; } = null!;

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public virtual ICollection<UnionCountry> UnionCountries { get; set; } = new List<UnionCountry>();
}
