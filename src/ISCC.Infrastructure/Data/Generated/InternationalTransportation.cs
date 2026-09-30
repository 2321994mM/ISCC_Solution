using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class InternationalTransportation
{
    public long Id { get; set; }

    public string? ArName { get; set; }

    public string? EnName { get; set; }

    public string? TransferMethod { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public byte? TransportMeanId { get; set; }

    public byte? ShipmentMeanId { get; set; }

    public virtual ICollection<ExCheckRequestDatum> ExCheckRequestData { get; set; } = new List<ExCheckRequestDatum>();

    public virtual ICollection<ImCheckRequestDatum> ImCheckRequestData { get; set; } = new List<ImCheckRequestDatum>();
}
