using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نوع المرفق
/// </summary>
public partial class AAttachmentTableType
{
    public short Id { get; set; }

    public string? ArName { get; set; }

    public string? EnName { get; set; }

    public bool? IsActive { get; set; }

    public int? OprationTypeAttachment { get; set; }

    public virtual ICollection<AAttachmentDatum> AAttachmentData { get; set; } = new List<AAttachmentDatum>();

    public virtual ICollection<AAttachmentDataExCheckRequest> AAttachmentDataExCheckRequests { get; set; } = new List<AAttachmentDataExCheckRequest>();

    public virtual ICollection<AAttachmentDataStation> AAttachmentDataStations { get; set; } = new List<AAttachmentDataStation>();

    public virtual ICollection<ExCertificatesRequestsFile> ExCertificatesRequestsFiles { get; set; } = new List<ExCertificatesRequestsFile>();
}
