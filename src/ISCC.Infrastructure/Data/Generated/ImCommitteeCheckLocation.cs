using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// أماكن الفحص التي يحددها المنفذ
/// </summary>
public partial class ImCommitteeCheckLocation
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public virtual ICollection<ImRequestCommittee> ImRequestCommittees { get; set; } = new List<ImRequestCommittee>();
}
