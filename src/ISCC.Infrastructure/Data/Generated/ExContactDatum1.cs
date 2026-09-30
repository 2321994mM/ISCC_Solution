using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExContactDatum1
{
    public long Id { get; set; }

    public long ExporterId { get; set; }

    public byte ContactTypeId { get; set; }

    public int ExporterTypeId { get; set; }

    public string Value { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }
}
