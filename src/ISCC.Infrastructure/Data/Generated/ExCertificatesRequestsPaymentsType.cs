using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCertificatesRequestsPaymentsType
{
    public byte Id { get; set; }

    public string? Name { get; set; }

    public double? Value { get; set; }

    public virtual ICollection<ExCertificatesRequestsPayment> ExCertificatesRequestsPayments { get; set; } = new List<ExCertificatesRequestsPayment>();
}
