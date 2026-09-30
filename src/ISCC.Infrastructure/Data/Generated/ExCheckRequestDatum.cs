using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestDatum
{
    public long Id { get; set; }

    public long ImporterId { get; set; }

    public int ImporterTypeId { get; set; }

    public short? ExportCountryId { get; set; }

    public byte? ShipmentMeanId { get; set; }

    public byte? TransportMeanId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? ExCheckRequestId { get; set; }

    public string? ShipName { get; set; }

    /// <summary>
    /// مندوب صاحب الرسالة
    /// </summary>
    public string? DelegateName { get; set; }

    /// <summary>
    /// عنوان مندوب صاحب الرسالة
    /// </summary>
    public string? DelegateAddress { get; set; }

    public short? TransitCountryId { get; set; }

    public long? InternationalTransportationId { get; set; }

    public long? TransitRegionsId { get; set; }

    public long? ExportRegionsId { get; set; }

    public short? GovernateId { get; set; }

    public long? ShippingCompaniesId { get; set; }

    /// <summary>
    /// الرقم القومي لمندوب صاحب الرسالة
    /// </summary>
    public string? NationalIdcompanyOwner { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ICollection<ExCheckRequestDataExtra> ExCheckRequestDataExtras { get; set; } = new List<ExCheckRequestDataExtra>();

    public virtual ICollection<ExCheckRequestPort> ExCheckRequestPorts { get; set; } = new List<ExCheckRequestPort>();

    public virtual Country? ExportCountry { get; set; }

    public virtual InternationalTransportation? InternationalTransportation { get; set; }

    public virtual ShipmentMean? ShipmentMean { get; set; }

    public virtual ShippingCompany? ShippingCompanies { get; set; }

    public virtual TransportMean? TransportMean { get; set; }
}
