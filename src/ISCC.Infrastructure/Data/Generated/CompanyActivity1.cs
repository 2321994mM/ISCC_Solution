using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class CompanyActivity1
{
    public long Id { get; set; }

    public long? CompanyId { get; set; }

    public byte? CompActivityTypeId { get; set; }

    public int MainActivityType { get; set; }

    public string? EnrollmentName { get; set; }

    public decimal? EnrollmentNumber { get; set; }

    public DateOnly? EnrollmentStart { get; set; }

    public DateOnly? EnrollmentEnd { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte? EnrollmentTypeId { get; set; }

    public virtual CompanyNational1? Company { get; set; }
}
