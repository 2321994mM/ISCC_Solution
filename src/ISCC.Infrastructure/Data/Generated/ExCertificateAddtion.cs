using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اضافات  الاشتراطات للشهادة
/// </summary>
public partial class ExCertificateAddtion
{
    public long Id { get; set; }

    public long? PlantCertificatesRequestsId { get; set; }

    /// <summary>
    /// نص الاشتراط الاصلى
    /// </summary>
    public string? CertificateAddtionOriginal { get; set; }

    /// <summary>
    /// نص الاشتراطات بعد التعديل
    /// </summary>
    public string? CertificateAddtionOriginalUpdate { get; set; }

    /// <summary>
    /// رقم الاشتراط الاصلى
    /// </summary>
    public long? ConstrainId { get; set; }

    /// <summary>
    /// رقم موظف الحجر
    /// </summary>
    public long? AdminId { get; set; }

    /// <summary>
    /// الاشتراط للحجر بعد التعديل
    /// </summary>
    public string? CertificateAddtionUpdateAdmin { get; set; }

    public bool? Isaccepted { get; set; }

    public DateTime? DateAccepted { get; set; }

    public virtual ExCertificatesRequest? PlantCertificatesRequests { get; set; }
}
