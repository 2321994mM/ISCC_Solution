using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اجراءات اللجنة
/// </summary>
public partial class ImRequestCommitteeProcedure
{
    public long Id { get; set; }

    public long ImRequestCommitteeId { get; set; }

    /// <summary>
    /// إجراءات تتم على اللوط (نقل تحت تحفظ/فحص/تحاليل/...)
    /// </summary>
    public byte ImProcedureTypeId { get; set; }

    /// <summary>
    /// السبب
    /// </summary>
    public string? ReasonText { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short UserCreationId { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ImProcedureType ImProcedureType { get; set; } = null!;

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;
}
