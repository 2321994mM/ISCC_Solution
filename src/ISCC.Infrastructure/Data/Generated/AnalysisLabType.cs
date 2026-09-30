using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// جدول ربط التحاليل بالمعامل
/// </summary>
public partial class AnalysisLabType
{
    public int Id { get; set; }

    public int AnalysisLabId { get; set; }

    public int AnalysisTypeId { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual AnalysisLab AnalysisLab { get; set; } = null!;

    public virtual AnalysisType AnalysisType { get; set; } = null!;

    public virtual ICollection<ExCheckRequestSampleDatum> ExCheckRequestSampleData { get; set; } = new List<ExCheckRequestSampleDatum>();

    public virtual ICollection<ExChooseSampleDatum> ExChooseSampleData { get; set; } = new List<ExChooseSampleDatum>();

    public virtual ICollection<FarmSampleDatum> FarmSampleData { get; set; } = new List<FarmSampleDatum>();

    public virtual ICollection<FarmSampleDataItem> FarmSampleDataItems { get; set; } = new List<FarmSampleDataItem>();

    public virtual ICollection<ImCheckRequestSampleDatum> ImCheckRequestSampleData { get; set; } = new List<ImCheckRequestSampleDatum>();
}
