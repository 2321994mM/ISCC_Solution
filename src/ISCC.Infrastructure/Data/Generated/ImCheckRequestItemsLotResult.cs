using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نتيجه اللوط
/// </summary>
public partial class ImCheckRequestItemsLotResult
{
    public long Id { get; set; }

    public long ImCheckRequestItemsLotCategoryId { get; set; }

    public string? Nots { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    /// <summary>
    /// الموقف مقبول او مرفوض
    /// </summary>
    public int? IsStatus { get; set; }

    /// <summary>
    /// الموقف مقبول او مرفوض
    /// </summary>
    public bool? IsStatusCommittee { get; set; }

    public virtual ImFumigation? ImFumigation { get; set; }

    public virtual ImCheckRequestLotResultStatus? IsStatusNavigation { get; set; }
}
