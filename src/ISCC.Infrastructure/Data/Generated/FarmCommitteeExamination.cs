using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// معاينة المزرعة
/// </summary>
public partial class FarmCommitteeExamination
{
    public long Id { get; set; }

    /// <summary>
    /// لجنة المعالجة
    /// </summary>
    public long FarmCommitteeId { get; set; }

    public long? FarmRequestItemCategoriesId { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// تاريخ نهاية معاينة الصنف
    /// </summary>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// تاريخ بداية معاينة الصنف
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// الانتاجية
    /// </summary>
    public double? QuantityTon { get; set; }

    /// <summary>
    /// 0 if rejected else 1
    /// </summary>
    public bool? IsAccepted { get; set; }

    public short UserCreationId { get; set; }

    /// <summary>
    /// null-&gt;exporter not take action 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool? IsAdminFinalResult { get; set; }

    /// <summary>
    /// Admin Note
    /// </summary>
    public string? AdminFinalResultNote { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// موقف الحجر
    /// </summary>
    public bool? AdminConfirmation { get; set; }

    /// <summary>
    /// ادمن الحجر
    /// </summary>
    public short? AdminUser { get; set; }

    public DateTime? AdminDate { get; set; }

    public double? AreaAcres { get; set; }

    public virtual FarmCommittee FarmCommittee { get; set; } = null!;

    public virtual ICollection<FarmCommitteeExaminationConfirm> FarmCommitteeExaminationConfirms { get; set; } = new List<FarmCommitteeExaminationConfirm>();

    public virtual FarmRequestItemCategory? FarmRequestItemCategories { get; set; }
}
