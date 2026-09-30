using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestFinalResult
{
    public long Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    public int? ExFinalResultId { get; set; }

    public DateOnly? Date { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ExFinalResult? ExFinalResult { get; set; }
}
