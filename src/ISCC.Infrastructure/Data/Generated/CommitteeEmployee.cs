using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// أعضاء اللجنة
/// </summary>
public partial class CommitteeEmployee
{
    public long CommitteeId { get; set; }

    public long EmployeeId { get; set; }

    /// <summary>
    /// is admin for the current committee
    /// </summary>
    public bool Isadmin { get; set; }

    /// <summary>
    /// from system code 20 (export :73 , Import 74, Farm 78) 
    /// </summary>
    public int OperationType { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ASystemCode OperationTypeNavigation { get; set; } = null!;
}
