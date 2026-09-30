using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تفاصيل عناصر الوارد
/// </summary>
public partial class ImRequestDatum
{
    public long Id { get; set; }

    /// <summary>
    /// نوع إذن الاستراد
    /// </summary>
    public byte? ImOperationType { get; set; }

    /// <summary>
    /// الشركة/الهيئة/الفرد المستوردة
    /// </summary>
    public long ImporterId { get; set; }

    /// <summary>
    /// from systemcode table 3
    /// </summary>
    public int ImporterTypeId { get; set; }

    /// <summary>
    /// الدولة المصدرة
    /// </summary>
    public short ExportCountryId { get; set; }

    /// <summary>
    /// وسيلة الشحن
    /// </summary>
    public byte? ShipmentMeanId { get; set; }

    /// <summary>
    /// وسيلة النقل
    /// </summary>
    public byte? TransportMeanId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? ImPermissionRequestId { get; set; }

    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// اسم الباخرة
    /// </summary>
    public string? ShipName { get; set; }

    /// <summary>
    /// مندوب صاحب الرسالة
    /// </summary>
    public string? DelegateName { get; set; }

    /// <summary>
    /// عنوان مندوب صاحب الرسالة
    /// </summary>
    public string? DelegateAddress { get; set; }

    public virtual Country ExportCountry { get; set; } = null!;

    public virtual ICollection<ImRequestDatExtra> ImRequestDatExtras { get; set; } = new List<ImRequestDatExtra>();

    public virtual ICollection<ImRequestPort> ImRequestPorts { get; set; } = new List<ImRequestPort>();

    public virtual ShipmentMean? ShipmentMean { get; set; }

    public virtual TransportMean? TransportMean { get; set; }
}
