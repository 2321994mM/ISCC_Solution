using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنة الصرف
/// </summary>
public partial class ImPermissionItemDivisionCustodyDismissCommittee
{
    public long Id { get; set; }

    /// <summary>
    /// كود نقل مكان التحفظ
    /// </summary>
    public long ImPermissionItemDivisionCustodyId { get; set; }

    /// <summary>
    /// كود اساسيات اللجنه
    /// </summary>
    public long ImRequestCommitteeId { get; set; }

    /// <summary>
    /// تاريخ الخروج
    /// </summary>
    public DateOnly? DismissDate { get; set; }

    /// <summary>
    /// وقت الخروج
    /// </summary>
    public TimeOnly? DismissTime { get; set; }

    /// <summary>
    /// 1 if committe accept else 0
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// 1 if investigation is done,0 if not done
    /// if car is come or not
    /// </summary>
    public bool Status { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// ترصيص
    /// </summary>
    public string? LockLead { get; set; }

    public string? Notes { get; set; }

    public virtual ImPermissionItemDivisionCustody ImPermissionItemDivisionCustody { get; set; } = null!;

    public virtual ICollection<ImPermissionItemDivisionCustodyReceiveCommittee> ImPermissionItemDivisionCustodyReceiveCommittees { get; set; } = new List<ImPermissionItemDivisionCustodyReceiveCommittee>();

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;
}
