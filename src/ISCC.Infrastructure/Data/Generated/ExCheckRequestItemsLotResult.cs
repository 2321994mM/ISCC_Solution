using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestItemsLotResult
{
    public long Id { get; set; }

    public long ExCheckRequestItemsLotCategoryId { get; set; }

    /// <summary>
    /// الموقف مقبول او مرفوض
    /// </summary>
    public bool? IsStatusCommittee { get; set; }

    public int? IsStatus { get; set; }

    public string? Nots { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public virtual ExCheckRequestItemsLotCategory ExCheckRequestItemsLotCategory { get; set; } = null!;

    public virtual ExCheckRequestLotResultStatus? IsStatusNavigation { get; set; }
}
