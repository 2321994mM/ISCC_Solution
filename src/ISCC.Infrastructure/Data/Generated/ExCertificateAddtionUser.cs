using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الشروط الاضافية الجديدة
/// </summary>
public partial class ExCertificateAddtionUser
{
    public long Id { get; set; }

    public long? PlantCertificatesRequestsId { get; set; }

    public string? CertificateAddtionText { get; set; }

    /// <summary>
    /// اضافه العميل 1 او رد الحجر 0
    /// 
    /// </summary>
    public bool? IsClientOrAgree { get; set; }

    public virtual ExCertificatesRequest? PlantCertificatesRequests { get; set; }
}
