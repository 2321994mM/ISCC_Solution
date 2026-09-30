using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الجزء النباتى للكائنات
/// </summary>
public partial class ItemPart
{
    public long Id { get; set; }

    public long ItemId { get; set; }

    public int SubPartId { get; set; }

    public bool IsAllowed { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual SubPart SubPart { get; set; } = null!;
}
