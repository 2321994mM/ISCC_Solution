using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// طرق المعالجة
/// </summary>
public partial class TreatmentMethod
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

    public byte? TreatmentTypeId { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public string? DescAr { get; set; }

    public string? DescEn { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ExChooseTreatment> ExChooseTreatments { get; set; } = new List<ExChooseTreatment>();

    public virtual ICollection<ExCountryConstrainTreatment> ExCountryConstrainTreatments { get; set; } = new List<ExCountryConstrainTreatment>();

    public virtual ICollection<StationActivityType> StationActivityTypes { get; set; } = new List<StationActivityType>();

    public virtual ICollection<TreatmentMaterial> TreatmentMaterials { get; set; } = new List<TreatmentMaterial>();

    public virtual TreatmentType? TreatmentType { get; set; }
}
