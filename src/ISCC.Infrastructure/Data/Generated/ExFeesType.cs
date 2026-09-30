using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExFeesType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Value { get; set; }

    /// <summary>
    /// نوع الحساب من system code رقم 33
    /// </summary>
    public int? AccountType { get; set; }

    /// <summary>
    /// صادر وارد ورية مهندس
    /// رقم 20
    /// فى system code
    /// 
    /// </summary>
    public int? FeesType { get; set; }

    /// <summary>
    /// نوع الوردية وقيمتها
    /// </summary>
    public long FeesActionId { get; set; }

    public virtual ICollection<ExRequestCommitteeFeesEng> ExRequestCommitteeFeesEngs { get; set; } = new List<ExRequestCommitteeFeesEng>();
}
