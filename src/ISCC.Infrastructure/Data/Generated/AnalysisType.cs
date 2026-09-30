using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// التحاليل التي تتم على العينة
/// </summary>
public partial class AnalysisType
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    /// <summary>
    /// هل يرفض الطلب كله في حالة وجود إصابة
    /// </summary>
    public bool IsRejectedAll { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<AnalysisLabType> AnalysisLabTypes { get; set; } = new List<AnalysisLabType>();

    public virtual ICollection<ExCountryConstrainAnalysisLabType> ExCountryConstrainAnalysisLabTypes { get; set; } = new List<ExCountryConstrainAnalysisLabType>();

    public virtual ICollection<FarmConstrain> FarmConstrains { get; set; } = new List<FarmConstrain>();
}
