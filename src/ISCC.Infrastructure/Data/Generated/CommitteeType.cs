using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الغرض من اللجنة
/// </summary>
public partial class CommitteeType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public int? TypeId { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<CompanyAccreditationCommittee> CompanyAccreditationCommittees { get; set; } = new List<CompanyAccreditationCommittee>();

    public virtual ICollection<ExRequestCommittee> ExRequestCommittees { get; set; } = new List<ExRequestCommittee>();

    public virtual ICollection<FarmCommittee> FarmCommittees { get; set; } = new List<FarmCommittee>();

    public virtual ICollection<ImRequestCommittee> ImRequestCommittees { get; set; } = new List<ImRequestCommittee>();

    public virtual ICollection<StationAccreditationCommittee> StationAccreditationCommittees { get; set; } = new List<StationAccreditationCommittee>();

    public virtual ICollection<StationAccreditationRequest> StationAccreditationRequests { get; set; } = new List<StationAccreditationRequest>();

    public virtual ASystemCode? Type { get; set; }
}
