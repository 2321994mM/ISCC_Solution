using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// عينة سحب المزرعة
/// </summary>
public partial class FarmSampleDatum
{
    public long Id { get; set; }

    public int AnalysisLabTypeId { get; set; }

    /// <summary>
    /// لجنة المعالجة
    /// </summary>
    public long FarmCommitteeId { get; set; }

    public long FarmRequestItemCategoriesId { get; set; }

    /// <summary>
    /// تاريخ سحب العينة
    /// </summary>
    public DateOnly? WithdrawDate { get; set; }

    /// <summary>
    /// البار كود
    /// </summary>
    public string? SampleBarCode { get; set; }

    /// <summary>
    /// حجم العينة
    /// </summary>
    public double? SampleSize { get; set; }

    /// <summary>
    /// نسبة اخذ العينة
    /// </summary>
    public double? SampleRatio { get; set; }

    /// <summary>
    /// 0 if rejected else 1 
    /// موافقه المعمل
    /// </summary>
    public bool? IsAccepted { get; set; }

    /// <summary>
    /// ملاحظات الاندريد
    /// </summary>
    public string? NotesAr { get; set; }

    /// <summary>
    /// سبب الرفض للمعمل ar
    /// </summary>
    public string? RejectReasonAr { get; set; }

    /// <summary>
    /// سبب الرفض للمعمل en
    /// </summary>
    public string? RejectReasonEn { get; set; }

    public string? NotesEn { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

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

    public bool? IsPrint { get; set; }

    public virtual AnalysisLabType AnalysisLabType { get; set; } = null!;

    public virtual FarmCommittee FarmCommittee { get; set; } = null!;

    public virtual FarmRequestItemCategory FarmRequestItemCategories { get; set; } = null!;

    public virtual ICollection<FarmSampleDataConfirm> FarmSampleDataConfirms { get; set; } = new List<FarmSampleDataConfirm>();
}
