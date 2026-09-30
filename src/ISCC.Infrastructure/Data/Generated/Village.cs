using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// القرية
/// </summary>
public partial class Village
{
    public short Id { get; set; }

    /// <summary>
    /// المركز
    /// </summary>
    public short? CenterId { get; set; }

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

    public virtual Center? Center { get; set; }

    public virtual ICollection<CompanyNational> CompanyNationals { get; set; } = new List<CompanyNational>();

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<FarmsDatum> FarmsData { get; set; } = new List<FarmsDatum>();
}
