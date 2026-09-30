using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تحصيل الرسوم الخاصه بالشهاده
/// </summary>
public partial class ExCertificatesRequestsPayment
{
    public long Id { get; set; }

    public long PlantCertificatesRequestsId { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public double? Value { get; set; }

    public byte? ExCertificatesRequestsPaymentsType { get; set; }

    public bool? IsPayment { get; set; }

    public virtual ICollection<ExCertificatesRequestsPaymentsDetaile> ExCertificatesRequestsPaymentsDetailes { get; set; } = new List<ExCertificatesRequestsPaymentsDetaile>();

    public virtual ExCertificatesRequestsPaymentsType? ExCertificatesRequestsPaymentsTypeNavigation { get; set; }

    public virtual ExCertificatesRequest PlantCertificatesRequests { get; set; } = null!;
}
