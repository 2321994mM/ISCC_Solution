using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// موانى تحديد ميناء وصول معين
/// </summary>
public partial class ImCountryConstrainArrivalPort
{
    public long Id { get; set; }

    public int? PortNationalId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public bool IsActive { get; set; }

    public long? ItemShortNameId { get; set; }

    public byte PortTypeId { get; set; }

    public short? IdQualitativeGroup { get; set; }

    public virtual QualitativeGroup? IdQualitativeGroupNavigation { get; set; }

    public virtual ItemShortName? ItemShortName { get; set; }

    public virtual PortNational? PortNational { get; set; }
}
