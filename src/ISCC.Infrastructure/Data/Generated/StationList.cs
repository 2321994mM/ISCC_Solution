using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationList
{
    public string StationStatus { get; set; } = null!;

    public int StationBtn { get; set; }

    public long StationId { get; set; }

    public string? ArName { get; set; }

    public string? StationCode { get; set; }

    public long? CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public short? GovId { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    public string? GovArName { get; set; }

    public string? CenterArName { get; set; }

    public string? VillageArName { get; set; }

    public bool? StationIsActive { get; set; }

    public bool? StationIsAccepted { get; set; }

    public short? StationUserDeletionId { get; set; }

    public long StationAccreditationDataId { get; set; }

    public byte StationAccreditationRequestTypeId { get; set; }

    public bool? StationAccreditationRequestIsactive { get; set; }

    public bool? StationAccreditationRequestIspaid { get; set; }

    public bool? StationAccreditationRequestIsAccepted { get; set; }

    public bool? IsFinalRequst { get; set; }

    public string? StationAccreditationDataName { get; set; }

    public bool? StationAccreditationDataIsActive { get; set; }

    public string? StationAccreditationRequestTypeName { get; set; }

    public bool? StationAccreditationRequestTypeIsActive { get; set; }

    public long StationAccreditationRequestId { get; set; }

    public int? AccreditationTypeId { get; set; }

    public byte? StationActivityTypeId { get; set; }

    public short? RequestUserDeletionId { get; set; }

    public long? StationAccreditationCommitteeId { get; set; }

    public DateOnly? DelegationDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsPaid { get; set; }

    public bool? Status { get; set; }

    public bool? IsAccepted { get; set; }

    public bool? IsStartAndroid { get; set; }

    public bool? IsCancel { get; set; }

    public short? CommitteeUserDeletionId { get; set; }

    public string Expr1 { get; set; } = null!;

    public int Expr2 { get; set; }
}
