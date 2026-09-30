using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesAltahsilDetile
{
    public long Id { get; set; }

    public byte? FeesTypeId { get; set; }

    public long? FeesAltahsilId { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// Ø§Ù„Ø¹Ø¯Ø¯
    /// </summary>
    public int? Quantity { get; set; }

    public string? FeeDescription { get; set; }

    public virtual FeesAltahsil? FeesAltahsil { get; set; }

    public virtual FeesType? FeesType { get; set; }
}
