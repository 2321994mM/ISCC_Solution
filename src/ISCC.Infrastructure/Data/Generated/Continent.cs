using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class Continent
{
    public byte Id { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? DescreptionEn { get; set; }

    public string? DescreptionAr { get; set; }

    /// <summary>
    /// قارة
    /// </summary>
    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
