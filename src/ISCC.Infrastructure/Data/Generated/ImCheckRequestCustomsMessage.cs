using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// البيانات الجمركيه
/// </summary>
public partial class ImCheckRequestCustomsMessage
{
    public int Id { get; set; }

    /// <summary>
    /// كود الطلب
    /// </summary>
    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// رقم الشهاده الجمركيه
    /// </summary>
    public string? CustomsCertificateNumber { get; set; }

    /// <summary>
    /// تاريخ الشهاده الجمركيه
    /// </summary>
    public DateOnly? CertificationDate { get; set; }

    /// <summary>
    /// تاريخ الشحن
    /// </summary>
    public DateOnly? ShipmentDate { get; set; }

    /// <summary>
    /// تاريخ الوصول 
    /// </summary>
    public DateOnly? ArrivalDate { get; set; }

    /// <summary>
    /// رقم الشهادة لكل منتج
    /// </summary>
    public string? CertificateNumberEachProduct { get; set; }

    public string? ManifestNumber { get; set; }

    public long? ShippingAgencyId { get; set; }

    /// <summary>
    /// نوع الطلب
    /// </summary>
    public byte? ImOperationType { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ShippingAgency? ShippingAgency { get; set; }
}
