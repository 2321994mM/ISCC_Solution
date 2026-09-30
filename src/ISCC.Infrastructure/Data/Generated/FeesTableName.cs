using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesTableName
{
    public short Id { get; set; }

    public string? TableName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<FeesTransaction> FeesTransactions { get; set; } = new List<FeesTransaction>();
}
