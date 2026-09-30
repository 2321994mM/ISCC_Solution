using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AndriodOperation
{
    public byte Id { get; set; }

    public string OperationName { get; set; } = null!;

    public virtual ICollection<AndriodLocation> AndriodLocations { get; set; } = new List<AndriodLocation>();
}
