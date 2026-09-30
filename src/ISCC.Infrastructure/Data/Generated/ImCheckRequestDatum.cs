using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestDatum
{
    public long Id { get; set; }

    public long ImporterId { get; set; }

    public int ImporterTypeId { get; set; }

    public short ExportCountryId { get; set; }

    public byte? ShipmentMeanId { get; set; }

    public byte? TransportMeanId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? ImCheckRequestId { get; set; }

    public string? ShipName { get; set; }

    public string? DelegateName { get; set; }

    public string? DelegateAddress { get; set; }

    /// <summary>
    /// دولة العبور
    /// </summary>
    public short? TransitCountryId { get; set; }

    public long? InternationalTransportationId { get; set; }

    public long? TransitRegionsId { get; set; }

    public long? ExportRegionsId { get; set; }

    public short? GovernateId { get; set; }

    public long? ShippingCompaniesId { get; set; }

    public virtual Country ExportCountry { get; set; } = null!;

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ICollection<ImCheckRequestDataExtra> ImCheckRequestDataExtras { get; set; } = new List<ImCheckRequestDataExtra>();

    public virtual InternationalTransportation? InternationalTransportation { get; set; }

    public virtual ShipmentMean? ShipmentMean { get; set; }

    public virtual ShippingCompany? ShippingCompanies { get; set; }

    public virtual TransportMean? TransportMean { get; set; }
}
