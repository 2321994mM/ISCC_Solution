using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ASystemCodeType
{
    public int Id { get; set; }

    public string? TableName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ASystemCode> ASystemCodes { get; set; } = new List<ASystemCode>();
}
