using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class TableActionLogEx
{
    public long Id { get; set; }

    public short IdTableAction { get; set; }

    public long? IdTableActionValue { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public long? ExCheckRequestId { get; set; }

    public string? Nots { get; set; }

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
