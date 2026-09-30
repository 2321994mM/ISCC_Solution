using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// وسائل النقل
/// </summary>
public partial class TransportMean
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

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public virtual ICollection<ExCheckRequestDatum> ExCheckRequestData { get; set; } = new List<ExCheckRequestDatum>();

    public virtual ICollection<ImCheckRequestDatum> ImCheckRequestData { get; set; } = new List<ImCheckRequestDatum>();

    public virtual ICollection<ImPermissionItemDivisionCustody> ImPermissionItemDivisionCustodies { get; set; } = new List<ImPermissionItemDivisionCustody>();

    public virtual ICollection<ImRequestDatum> ImRequestData { get; set; } = new List<ImRequestDatum>();

    public virtual ICollection<ImScientificResearch> ImScientificResearches { get; set; } = new List<ImScientificResearch>();
}
