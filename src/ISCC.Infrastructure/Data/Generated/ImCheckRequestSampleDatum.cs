using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نتيجه سحب عينه للوارد (admin)
/// </summary>
public partial class ImCheckRequestSampleDatum
{
    public long Id { get; set; }

    public int AnalysisLabTypeId { get; set; }

    /// <summary>
    /// كود اساسيات اللجنه
    /// </summary>
    public long ImRequestCommitteeId { get; set; }

    public long ImRequestItemId { get; set; }

    /// <summary>
    /// null for the whole request  /  كود بيانات الدفعه
    /// </summary>
    public long? LotDataId { get; set; }

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
    /// 
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

    /// <summary>
    /// (0) in the case of all,(1) in the case of the part   في حاله الجزئي او الكلي
    /// </summary>
    public bool? IsTotal { get; set; }

    /// <summary>
    /// الاسم المختصر 
    /// </summary>
    public long? ItemShortNameId { get; set; }

    /// <summary>
    /// في حاله الفحص لو كلي واتحول الي جزئي
    /// </summary>
    public bool? IsTotalAndroid { get; set; }

    /// <summary>
    /// مين رمي row (system or android)
    /// </summary>
    public bool? IsFromAndroid { get; set; }

    /// <summary>
    /// رقم الختامه والسيل الملاحي
    /// </summary>
    public string? SylAlkhatimaNumber { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public decimal? FeesActual { get; set; }

    public bool? IsPaid { get; set; }

    public string? SampleQuantityUnit { get; set; }

    public virtual AnalysisLabType AnalysisLabType { get; set; } = null!;

    public virtual ICollection<ImCheckRequestSampleDataConfirm> ImCheckRequestSampleDataConfirms { get; set; } = new List<ImCheckRequestSampleDataConfirm>();

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;
}
