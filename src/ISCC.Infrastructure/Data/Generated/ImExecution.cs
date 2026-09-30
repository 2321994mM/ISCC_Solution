using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنة الاعدام
/// </summary>
public partial class ImExecution
{
    public long Id { get; set; }

    public long ImRequestCommitteeId { get; set; }

    public string ExecutionPlace { get; set; } = null!;

    public string ExecutionMethod { get; set; } = null!;

    public byte[]? ExecutionFile { get; set; }

    public virtual ICollection<ImExecutionItem> ImExecutionItems { get; set; } = new List<ImExecutionItem>();

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;
}
