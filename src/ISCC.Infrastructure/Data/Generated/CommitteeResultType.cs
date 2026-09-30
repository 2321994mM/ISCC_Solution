using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// مرفوض/ مقبول ..........
/// </summary>
public partial class CommitteeResultType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ExCommitteeResult> ExCommitteeResults { get; set; } = new List<ExCommitteeResult>();

    public virtual ICollection<ImCommitteeResult> ImCommitteeResults { get; set; } = new List<ImCommitteeResult>();
}
