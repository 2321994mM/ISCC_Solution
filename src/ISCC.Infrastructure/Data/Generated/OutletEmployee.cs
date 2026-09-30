using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// موظفين المنافذ
/// </summary>
public partial class OutletEmployee
{
    public long Id { get; set; }

    /// <summary>
    /// المنافذ
    /// </summary>
    public long OutletId { get; set; }

    /// <summary>
    /// الموظف
    /// </summary>
    public short EmployeeId { get; set; }

    public short? UserUpdationId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual Outlet Outlet { get; set; } = null!;
}
