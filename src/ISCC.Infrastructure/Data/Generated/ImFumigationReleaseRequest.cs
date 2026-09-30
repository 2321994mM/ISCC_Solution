using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationReleaseRequest
{
    public long Id { get; set; }

    public int FumigationId { get; set; }

    public string ReleaseRequestNumber { get; set; } = null!;

    public decimal TotalQuantity { get; set; }

    public decimal PreviouslyReleasedQuantity { get; set; }

    public decimal RemainingQuantity { get; set; }

    public decimal ReleasedQuantity { get; set; }

    public decimal RejectedQuantity { get; set; }

    public string QuantityUnit { get; set; } = null!;

    public string StakeholderName { get; set; } = null!;

    public string ReleaseLocation { get; set; } = null!;

    public string? AttachmentNumber { get; set; }

    public string? Attachments { get; set; }

    public int? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public int? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public int? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ImFumigation Fumigation { get; set; } = null!;
}
