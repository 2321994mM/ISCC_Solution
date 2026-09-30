using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class TableActionLogStation
{
    public long Id { get; set; }

    public short IdTableAction { get; set; }

    public long? IdTableActionValue { get; set; }

    public long? StationId { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public string? Nots { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// from A_SystemCode =3
    /// </summary>
    public int? UserTypeId { get; set; }

    /// <summary>
    /// from A_SystemCode =32
    /// </summary>
    public int? TypeLogId { get; set; }

    public virtual TableAction IdTableActionNavigation { get; set; } = null!;
}
