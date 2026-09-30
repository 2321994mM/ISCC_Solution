using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الشركة او الهيئة او الفرد
/// </summary>
public partial class FarmCompany
{
    public long Id { get; set; }

    public long? CompanyId { get; set; }

    /// <summary>
    /// from systemcode table 3
    /// </summary>
    public int? ExporterTypeId { get; set; }

    public long? FarmId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsAcive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual FarmsDatum? Farm { get; set; }
}
