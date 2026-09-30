using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// موانى تحديد ميناء وصول معين
/// </summary>
public partial class ExCountryConstrainArrivalPort
{
    public long Id { get; set; }

    public long ExCountryConstrainId { get; set; }

    public int PortInternationalId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public long? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ExCountryConstrain ExCountryConstrain { get; set; } = null!;

    public virtual PortInternational PortInternational { get; set; } = null!;
}
