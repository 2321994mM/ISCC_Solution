using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequsetShippingMethod
{
    public long Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    public int? ContainersId { get; set; }

    public int? ContainersTypeId { get; set; }

    public string? ShipholdNumber { get; set; }

    public string? ContainerNumber { get; set; }

    public string? NavigationalNumber { get; set; }

    public decimal? TotalWeight { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ExCertificatesRequestsLotDatum> ExCertificatesRequestsLotData { get; set; } = new List<ExCertificatesRequestsLotDatum>();

    public virtual ICollection<ExCheckRequestItemsLotCategory> ExCheckRequestItemsLotCategories { get; set; } = new List<ExCheckRequestItemsLotCategory>();
}
