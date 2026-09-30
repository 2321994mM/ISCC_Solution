using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationDistributionInspection
{
    public long Id { get; set; }

    public long DistributionId { get; set; }

    public short InspectionStatus { get; set; }

    public string? RejectionReason { get; set; }

    public string? InspectionNotes { get; set; }

    public string? Attachments { get; set; }

    public bool IsFinalInspection { get; set; }

    public int? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public int? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public int? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ImFumigationDistribution Distribution { get; set; } = null!;
}
