using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmRequestItemCategory
{
    public long Id { get; set; }

    public long? FarmRequestId { get; set; }

    public long? FarmItemCategoriesId { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public DateTime? AdminDate { get; set; }

    /// <summary>
    /// ادمن الحجر
    /// </summary>
    public short? AdminUser { get; set; }

    /// <summary>
    /// المساحة النهائية للحجر
    /// </summary>
    public double? AreaAcresQuarant { get; set; }

    /// <summary>
    /// الكمية للفدان بالطن للحجر
    /// </summary>
    public double? QuantityTonQuarant { get; set; }

    /// <summary>
    /// الكمية الاجمالية الصالحة للتصدير
    /// </summary>
    public double? QuantityTonExport { get; set; }

    /// <summary>
    /// مساحة العميل
    /// </summary>
    public double? AreaAcres { get; set; }

    /// <summary>
    /// الكمية للطن
    /// </summary>
    public double? QuantityTon { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<FarmCommitteeExamination> FarmCommitteeExaminations { get; set; } = new List<FarmCommitteeExamination>();

    public virtual FarmItemCategory? FarmItemCategories { get; set; }

    public virtual FarmRequest? FarmRequest { get; set; }

    public virtual ICollection<FarmSampleDatum> FarmSampleData { get; set; } = new List<FarmSampleDatum>();

    public virtual ICollection<FarmSampleDataItem> FarmSampleDataItems { get; set; } = new List<FarmSampleDataItem>();
}
