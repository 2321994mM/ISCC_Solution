using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الاشترطات الدوليه
/// </summary>
public partial class ExCountryConstrain
{
    public long Id { get; set; }

    /// <summary>
    /// الدولة المستوردة
    /// </summary>
    public short? ImportCountryId { get; set; }

    /// <summary>
    /// دولة عبور
    /// </summary>
    public short? TransportCountryId { get; set; }

    /// <summary>
    /// product or plant ID manual no relation
    /// </summary>
    public long ItemShortNameId { get; set; }

    public long? ItemCategoriesId { get; set; }

    /// <summary>
    /// هل محطة معتمدة
    /// </summary>
    public bool? IsStationAccreditation { get; set; }

    /// <summary>
    /// هل مزرعة معتمدة
    /// </summary>
    public bool? IsFarmAccreditation { get; set; }

    /// <summary>
    /// هل شركة معتمدة
    /// </summary>
    public bool? IsCompanyAccreditation { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ExCountryConstrainAnalysisLabType> ExCountryConstrainAnalysisLabTypes { get; set; } = new List<ExCountryConstrainAnalysisLabType>();

    public virtual ICollection<ExCountryConstrainArrivalPort> ExCountryConstrainArrivalPorts { get; set; } = new List<ExCountryConstrainArrivalPort>();

    public virtual ICollection<ExCountryConstrainText> ExCountryConstrainTexts { get; set; } = new List<ExCountryConstrainText>();

    public virtual ICollection<ExCountryConstrainTreatment> ExCountryConstrainTreatments { get; set; } = new List<ExCountryConstrainTreatment>();

    public virtual ItemShortName ItemShortName { get; set; } = null!;
}
