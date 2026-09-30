using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmCountry
{
    public long Id { get; set; }

    public long FarmRequestId { get; set; }

    /// <summary>
    /// ConstrainOwner(UnionId/CountryId/ or 0 if Local-Egypt)
    /// </summary>
    public short? CountryId { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// الحجر واقف على الدولة ولا لا
    /// </summary>
    public bool? IsAcceppted { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? StartDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Country? Country { get; set; }

    public virtual FarmRequest FarmRequest { get; set; } = null!;
}
