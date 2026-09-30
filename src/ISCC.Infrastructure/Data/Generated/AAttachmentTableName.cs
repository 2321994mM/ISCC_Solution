using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اسماء الجداول فى قواعد البيانات
/// </summary>
public partial class AAttachmentTableName
{
    public short Id { get; set; }

    public string? TableName { get; set; }

    public string? Description { get; set; }

    public byte? PrModuleId { get; set; }

    public virtual ICollection<AAttachmentDatum> AAttachmentData { get; set; } = new List<AAttachmentDatum>();

    public virtual ICollection<AAttachmentDataExCheckRequest> AAttachmentDataExCheckRequests { get; set; } = new List<AAttachmentDataExCheckRequest>();

    public virtual ICollection<AAttachmentDataStation> AAttachmentDataStations { get; set; } = new List<AAttachmentDataStation>();

    public virtual ICollection<TableAction> TableActions { get; set; } = new List<TableAction>();
}
