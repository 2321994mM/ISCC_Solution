using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestCustomsMessage
{
    public int Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    public long? ExCertificatesRequestsId { get; set; }

    public string? CustomsCertificateNumber { get; set; }

    public DateOnly? CertificationDate { get; set; }

    public DateOnly? ShipmentDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public string? CertificateNumberEachProduct { get; set; }

    public string? ManifestNumber { get; set; }

    public long? ShippingAgencyId { get; set; }

    public byte? ImOperationType { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ExCertificatesRequest? ExCertificatesRequests { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ShippingAgency? ShippingAgency { get; set; }
}
