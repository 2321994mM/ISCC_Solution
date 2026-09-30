using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المرفقات الخاصة بالشهادة
/// </summary>
public partial class ExCertificatesRequestsFile
{
    public long Id { get; set; }

    public long PlantCertificatesRequestsId { get; set; }

    public string? FilePath { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? AAttachmentTableTypeId { get; set; }

    public virtual AAttachmentTableType? AAttachmentTableType { get; set; }

    public virtual ExCertificatesRequest PlantCertificatesRequests { get; set; } = null!;
}
