using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنة الاستلام
/// </summary>
public partial class ImPermissionItemDivisionCustodyReceiveCommittee
{
    public long Id { get; set; }

    /// <summary>
    /// كود لجنه الصرف
    /// </summary>
    public long ImPermissionItemDivisionCustodyDismissCommitteeId { get; set; }

    /// <summary>
    /// تاريخ الاستلام
    /// </summary>
    public DateOnly? ReceiveDate { get; set; }

    /// <summary>
    /// وقت الاستلام
    /// </summary>
    public TimeOnly? ReceiveTime { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// 0 if not done, 1 if investigation is done
    /// </summary>
    public bool Status { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// الوزن الاجمالي
    /// </summary>
    public decimal GrossWeight { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// كود اساسيات اللجنه
    /// </summary>
    public long ImRequestCommitteeId { get; set; }

    public virtual ImPermissionItemDivisionCustodyDismissCommittee ImPermissionItemDivisionCustodyDismissCommittee { get; set; } = null!;

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;
}
