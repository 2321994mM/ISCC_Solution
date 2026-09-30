using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCommitteeResult
{
    public long Id { get; set; }

    public long CommitteeId { get; set; }

    public long ExRequestItemId { get; set; }

    public long? LotDataId { get; set; }

    public long? EmployeeId { get; set; }

    public byte? CommitteeResultTypeId { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsAdminResult { get; set; }

    public string? AdminFinalResultNote { get; set; }

    public double? QuantitySize { get; set; }

    public double? Weight { get; set; }

    public string? Notes { get; set; }

    public bool? IsTotal { get; set; }

    public long? ItemShortNameId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public bool? IsTotalAndroid { get; set; }

    public double? WeightOld { get; set; }

    public virtual ICollection<AAttachmentDataExCommitteeResultInfection> AAttachmentDataExCommitteeResultInfections { get; set; } = new List<AAttachmentDataExCommitteeResultInfection>();

    public virtual ExRequestCommittee Committee { get; set; } = null!;

    public virtual CommitteeResultType? CommitteeResultType { get; set; }

    public virtual ICollection<ExCommitteeResultConfirm> ExCommitteeResultConfirms { get; set; } = new List<ExCommitteeResultConfirm>();

    public virtual ICollection<ExCommitteeResultInfection> ExCommitteeResultInfections { get; set; } = new List<ExCommitteeResultInfection>();

    public virtual ItemShortName? ItemShortName { get; set; }
}
