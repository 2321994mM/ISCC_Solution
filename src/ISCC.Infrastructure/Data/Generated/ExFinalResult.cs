using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExFinalResult
{
    public int Id { get; set; }

    public string? ArName { get; set; }

    public string? EnName { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsActive { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<ExCheckRequestFinalResult> ExCheckRequestFinalResults { get; set; } = new List<ExCheckRequestFinalResult>();
}
