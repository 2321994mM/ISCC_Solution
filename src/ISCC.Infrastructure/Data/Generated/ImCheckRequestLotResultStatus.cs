using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestLotResultStatus
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool? IsActive { get; set; }

    /// <summary>
    /// 0 عدم استكمال الاعمال
    /// لا يمكن استكمال الاعمال 1
    /// </summary>
    public bool? IsContinue { get; set; }

    public byte? CommitteeTypeId { get; set; }

    public virtual ICollection<ImCheckRequestItemsLotResult> ImCheckRequestItemsLotResults { get; set; } = new List<ImCheckRequestItemsLotResult>();
}
