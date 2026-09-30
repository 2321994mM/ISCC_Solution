using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تقسيم/ نقل الى مكان التحفظ
/// </summary>
public partial class ImPermissionItemDivisionCustody
{
    public long Id { get; set; }

    /// <summary>
    /// كود اماكن التحفظ
    /// </summary>
    public long ImCustodyPlaceId { get; set; }

    public long ImCheckRequestItemId { get; set; }

    /// <summary>
    /// الوزن الاجمالي
    /// </summary>
    public decimal GrossWeight { get; set; }

    /// <summary>
    /// كود وسائل النقل
    /// </summary>
    public byte TransportMeanId { get; set; }

    public string TransportMeanNumber { get; set; } = null!;

    /// <summary>
    /// اسم السائق
    /// </summary>
    public string DriverName { get; set; } = null!;

    /// <summary>
    /// رقم تليفون السائق
    /// </summary>
    public string DriverPhone { get; set; } = null!;

    public string DriverNationalId { get; set; } = null!;

    /// <summary>
    /// هل تم الموافقة على التقسيم
    /// حالة الطلب
    /// </summary>
    public bool? IsAccepted { get; set; }

    /// <summary>
    /// تاريخ القبول
    /// </summary>
    public DateOnly? AcceptDate { get; set; }

    public DateTime? AcceptUserUpdationDate { get; set; }

    /// <summary>
    /// الموظف الذى وافق على الصنف وهذا ليس له علاقة بمن ادخل الصنف( يقرا من الاذن نفسه)
    /// </summary>
    public short? AcceptUserCreationId { get; set; }

    public DateTime? AcceptUserCreationDate { get; set; }

    public short? AcceptUserUpdationId { get; set; }

    public virtual ImCheckRequestItem ImCheckRequestItem { get; set; } = null!;

    public virtual ImCustodyPlaceCheckRequest ImCustodyPlace { get; set; } = null!;

    public virtual ICollection<ImPermissionItemDivisionCustodyDismissCommittee> ImPermissionItemDivisionCustodyDismissCommittees { get; set; } = new List<ImPermissionItemDivisionCustodyDismissCommittee>();

    public virtual TransportMean TransportMean { get; set; } = null!;
}
