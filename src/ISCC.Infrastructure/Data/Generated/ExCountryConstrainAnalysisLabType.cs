using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تحاليل الاشتراطات
/// </summary>
public partial class ExCountryConstrainAnalysisLabType
{
    public long Id { get; set; }

    public long CountryConstrainId { get; set; }

    /// <summary>
    /// 1 لو مفعل انه يظهر في الشهادة الزراعية
    /// </summary>
    public bool IsAcive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ParentId { get; set; }

    public int AnalysisTypeId { get; set; }

    public virtual AnalysisType AnalysisType { get; set; } = null!;

    public virtual ExCountryConstrain CountryConstrain { get; set; } = null!;

    public virtual ICollection<ExChooseSampleDatum> ExChooseSampleData { get; set; } = new List<ExChooseSampleDatum>();
}
