using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// عناصر لجنة الاعدام
/// </summary>
public partial class ImExecutionItem
{
    public long Id { get; set; }

    public long ImExecutionId { get; set; }

    public long ImCheckRequestItemId { get; set; }

    public decimal GrossWeight { get; set; }

    public long? ImCheckRequestItemsLotCategoryId { get; set; }

    public virtual ImCheckRequestItem ImCheckRequestItem { get; set; } = null!;

    public virtual ImCheckRequestItemsLotCategory? ImCheckRequestItemsLotCategory { get; set; }

    public virtual ImExecution ImExecution { get; set; } = null!;
}
