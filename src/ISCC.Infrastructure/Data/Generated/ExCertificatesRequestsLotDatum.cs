using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// بيانات اللوطات
/// </summary>
public partial class ExCertificatesRequestsLotDatum
{
    public long Id { get; set; }

    public long? PlantCertificatesRequestsId { get; set; }

    public long? LotId { get; set; }

    public long? ItemShortNameId { get; set; }

    public bool? Isaccepted { get; set; }

    public long? ExCheckRequsetShippingMethodId { get; set; }

    public virtual ExCheckRequsetShippingMethod? ExCheckRequsetShippingMethod { get; set; }

    public virtual ExCertificatesRequest? PlantCertificatesRequests { get; set; }
}
