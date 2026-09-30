using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// انواع عمليات الرسوم - صادر وارد مزارع محطات
/// </summary>
public partial class FeesProcess
{
    public byte Id { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public virtual ICollection<FeesTypeAction> FeesTypeActions { get; set; } = new List<FeesTypeAction>();
}
