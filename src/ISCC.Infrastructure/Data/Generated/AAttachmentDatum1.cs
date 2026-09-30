using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AAttachmentDatum1
{
    public long Id { get; set; }

    public long RowId { get; set; }

    public short AAttachmentTableNameId { get; set; }

    public string? AttachmentNumber { get; set; }

    public string? AttachmentTypeName { get; set; }

    public string? AttachmentPath { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public byte[]? AttachmentPathBinary { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }
}
