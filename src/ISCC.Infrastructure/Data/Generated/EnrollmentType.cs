using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class EnrollmentType
{
    public byte Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// مفعل
    /// </summary>
    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<CompanyActivity> CompanyActivities { get; set; } = new List<CompanyActivity>();
}
