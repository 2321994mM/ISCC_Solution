using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تقسيم الرسالة
/// </summary>
public partial class ImSubDivission
{
    public long Id { get; set; }

    public long ImItemId { get; set; }

    public decimal? Quantity { get; set; }

    /// <summary>
    /// رقم بوليصة الشحن
    /// </summary>
    public string? ShipmentPolicyNumber { get; set; }

    public string? CustomsCertificate { get; set; }

    public string FilePath { get; set; } = null!;

    public virtual ImPermissionItem ImItem { get; set; } = null!;
}
