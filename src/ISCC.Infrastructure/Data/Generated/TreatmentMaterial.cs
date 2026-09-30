using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// مادة المعالجة
/// </summary>
public partial class TreatmentMaterial
{
    public byte Id { get; set; }

    public long? ItemId { get; set; }

    public byte? TreatmentMethodsId { get; set; }

    public bool IsActive { get; set; }

    public string? ChemicalComposition { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ICollection<ExRequestTreatmentDatum> ExRequestTreatmentData { get; set; } = new List<ExRequestTreatmentDatum>();

    public virtual ICollection<ImRequestTreatmentDatum> ImRequestTreatmentData { get; set; } = new List<ImRequestTreatmentDatum>();

    public virtual Item? Item { get; set; }

    public virtual TreatmentMethod? TreatmentMethods { get; set; }
}
