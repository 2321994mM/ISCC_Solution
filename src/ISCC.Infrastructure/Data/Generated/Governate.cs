using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المحافظة
/// </summary>
public partial class Governate
{
    public short Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<Center> Centers { get; set; } = new List<Center>();

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaces { get; set; } = new List<ExCheckRequestPlace>();

    public virtual ICollection<FarmsDatum> FarmsData { get; set; } = new List<FarmsDatum>();

    public virtual ICollection<FreeZone> FreeZones { get; set; } = new List<FreeZone>();

    public virtual ICollection<PortNational> PortNationals { get; set; } = new List<PortNational>();
}
