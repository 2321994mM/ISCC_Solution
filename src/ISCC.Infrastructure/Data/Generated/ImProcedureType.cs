using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// إجراءات تتم على اللوط (نقل تحت تحفظ/فحص/تحاليل/...)
/// </summary>
public partial class ImProcedureType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ImRequestCommitteeProcedure> ImRequestCommitteeProcedures { get; set; } = new List<ImRequestCommitteeProcedure>();
}
