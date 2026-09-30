using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نشاط الشركة
/// </summary>
public partial class CompanyActivity
{
    public long Id { get; set; }

    /// <summary>
    /// الشركة
    /// </summary>
    public long? CompanyId { get; set; }

    /// <summary>
    /// نوع النشاط
    /// </summary>
    public byte? CompActivityTypeId { get; set; }

    /// <summary>
    /// نوع نشاط الرئيسى from systemcode 17
    /// </summary>
    public int MainActivityType { get; set; }

    public string? EnrollmentName { get; set; }

    public decimal? EnrollmentNumber { get; set; }

    /// <summary>
    /// تاريخ بداية
    /// </summary>
    public DateOnly? EnrollmentStart { get; set; }

    /// <summary>
    /// تاريخ نهاية
    /// </summary>
    public DateOnly? EnrollmentEnd { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte? EnrollmentTypeId { get; set; }

    public virtual CompanyActivityType? CompActivityType { get; set; }

    public virtual CompanyNational? Company { get; set; }

    public virtual EnrollmentType? EnrollmentType { get; set; }

    public virtual ASystemCode MainActivityTypeNavigation { get; set; } = null!;
}
