using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationDistributionResult
{
    public long Id { get; set; }

    public long DistributionId { get; set; }

    public short ResultStatus { get; set; }

    public string? ReservationReason { get; set; }

    public int? PoliciesCount { get; set; }

    public decimal? WasteQuantity { get; set; }

    public decimal? ReceivedQuantity { get; set; }

    public string? ResultNotes { get; set; }

    public bool IsFinalResult { get; set; }

    public int? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public int? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public int? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public string? Attachments { get; set; }

    public virtual ImFumigationDistribution Distribution { get; set; } = null!;
}
