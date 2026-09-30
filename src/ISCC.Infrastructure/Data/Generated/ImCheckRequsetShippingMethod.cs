using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اساليب الشحن لطلب الفحص الوارد
/// </summary>
public partial class ImCheckRequsetShippingMethod
{
    public long Id { get; set; }

    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// حاوية او صب
    /// </summary>
    public int? ContainersId { get; set; }

    /// <summary>
    /// عبوات او بدون
    /// </summary>
    public int? ContainersTypeId { get; set; }

    /// <summary>
    /// رقم عنبر السفينة
    /// </summary>
    public string? ShipholdNumber { get; set; }

    /// <summary>
    /// رقم الحاوية
    /// </summary>
    public string? ContainerNumber { get; set; }

    /// <summary>
    /// رقم السيل الملاحي
    /// </summary>
    public string? NavigationalNumber { get; set; }

    public decimal? TotalWeight { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ICollection<ImCheckRequestItem> ImCheckRequestItems { get; set; } = new List<ImCheckRequestItem>();
}
