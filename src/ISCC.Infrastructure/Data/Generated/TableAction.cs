using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class TableAction
{
    public short Id { get; set; }

    public short IdTableName { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? NotsAr { get; set; }

    public string? NotsEn { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Nots { get; set; }

    public virtual AAttachmentTableName IdTableNameNavigation { get; set; } = null!;

    public virtual ICollection<TableActionLogCheckRequest> TableActionLogCheckRequests { get; set; } = new List<TableActionLogCheckRequest>();

    public virtual ICollection<TableActionLogEx> TableActionLogExes { get; set; } = new List<TableActionLogEx>();

    public virtual ICollection<TableActionLogFarm> TableActionLogFarms { get; set; } = new List<TableActionLogFarm>();

    public virtual ICollection<TableActionLogStation> TableActionLogStations { get; set; } = new List<TableActionLogStation>();

    public virtual ICollection<TableActionLog> TableActionLogs { get; set; } = new List<TableActionLog>();
}
