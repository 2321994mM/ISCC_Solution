using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تفاصيل الاجراءات
/// </summary>
public partial class FeesAction
{
    public long Id { get; set; }

    public byte? FeesTypeId { get; set; }

    public byte? FeerTypeActionId { get; set; }

    public long? ItemShiftTreatmentId { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// الحد الادنى
    /// </summary>
    public decimal? MinAmount { get; set; }

    public double? WeightFrom { get; set; }

    /// <summary>
    /// الوزن
    /// </summary>
    public double? WeightTo { get; set; }

    /// <summary>
    /// هل تدفع عند الطلب ام بعده
    /// </summary>
    public bool? IsPaidBefore { get; set; }

    public bool IsActive { get; set; }

    public bool IsMandatory { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public byte? CalculatorType { get; set; }

    /// <summary>
    /// نوع الحساب من  system code رقم 33
    /// </summary>
    public int? AccountType { get; set; }

    public virtual FeesTypeAction? FeerTypeAction { get; set; }

    public virtual ICollection<FeesTransactionsDetile> FeesTransactionsDetiles { get; set; } = new List<FeesTransactionsDetile>();

    public virtual FeesType? FeesType { get; set; }
}
