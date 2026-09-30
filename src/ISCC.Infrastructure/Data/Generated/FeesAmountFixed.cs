using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesAmountFixed
{
    public int Id { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public byte FeesTypeId { get; set; }

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

    public bool IsExport { get; set; }

    public bool IsActive { get; set; }

    public bool IsMandatory { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual FeesType FeesType { get; set; } = null!;
}
