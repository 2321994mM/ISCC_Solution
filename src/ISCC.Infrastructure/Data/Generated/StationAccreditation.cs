using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationAccreditation
{
    public long Id { get; set; }

    /// <summary>
    /// المحطة
    /// </summary>
    public long StationId { get; set; }

    /// <summary>
    /// المحطة
    /// </summary>
    public long StationAccreditationDataId { get; set; }

    public long? StationAccreditationRequestId { get; set; }

    public string? NotesQuarantine { get; set; }

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual Station Station { get; set; } = null!;

    public virtual StationAccreditationDatum StationAccreditationData { get; set; } = null!;

    public virtual ICollection<StationCompany> StationCompanies { get; set; } = new List<StationCompany>();
}
