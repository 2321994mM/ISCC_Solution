using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigationDistribution
{
    public long Id { get; set; }

    public int FumigationId { get; set; }

    public long? OutletId { get; set; }

    public int? PortId { get; set; }

    public int? SupervisorUserId { get; set; }

    public decimal AssignedQuantity { get; set; }

    public string? QuantityUnit { get; set; }

    public string? TreatmentLocation { get; set; }

    public string? TreatmentAddress { get; set; }

    public short Status { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    public int? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public int? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public int? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public string? Attachments { get; set; }

    public string? InspectionRequestFacilityName { get; set; }

    public string? InspectionRequestFacilityAddress { get; set; }

    public string? InspectionRequestImporterName { get; set; }

    public string? InspectionRequestHoldReason { get; set; }

    public string? InspectionRequestCouponNumber { get; set; }

    public string? InspectionRequestAction { get; set; }

    public string? InspectionRequestVesselTrip { get; set; }

    public string? InspectionRequestCustomsCertificate { get; set; }

    public string? InspectionRequestItem { get; set; }

    public string? InspectionRequestOrigin { get; set; }

    public string? InspectionRequestCount { get; set; }

    public string? InspectionRequestWeight { get; set; }

    public string? InspectionRequestPoliciesCount { get; set; }

    public string? InspectionRequestPolicyNumbers { get; set; }

    public string? InspectionRequestNotes { get; set; }

    public long? RedistributedToId { get; set; }

    public virtual ImFumigationDistributionInspection? ImFumigationDistributionInspection { get; set; }

    public virtual ICollection<ImFumigationDistributionMessageRead> ImFumigationDistributionMessageReads { get; set; } = new List<ImFumigationDistributionMessageRead>();

    public virtual ICollection<ImFumigationDistributionMessage> ImFumigationDistributionMessages { get; set; } = new List<ImFumigationDistributionMessage>();

    public virtual ImFumigationDistributionResult? ImFumigationDistributionResult { get; set; }
}
