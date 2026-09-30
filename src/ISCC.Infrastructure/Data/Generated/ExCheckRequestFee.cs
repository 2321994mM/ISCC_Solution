using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestFee
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    /// <summary>
    /// الوزن الاجمالى للطلب
    /// </summary>
    public decimal? TotalGrossWeight { get; set; }

    /// <summary>
    /// قيمة الرسوم
    /// </summary>
    public decimal? FeeValue { get; set; }

    /// <summary>
    /// اجمالى الرسوم
    /// </summary>
    public decimal? TotalAmount { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserCreationId { get; set; }

    /// <summary>
    /// تقريب الرسوم
    /// </summary>
    public bool? IsFeeRounding { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;
}
