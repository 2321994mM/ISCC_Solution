using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// بلد نشاط المحطة
/// </summary>
public partial class StationAccreditationDataCountry
{
    public long Id { get; set; }

    public long StationAccreditationDataId { get; set; }

    public short CountryId { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual StationAccreditationDatum StationAccreditationData { get; set; } = null!;
}
