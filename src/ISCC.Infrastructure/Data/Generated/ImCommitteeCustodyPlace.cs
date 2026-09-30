using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// لجنة معاينة مكان التحفظ
/// </summary>
public partial class ImCommitteeCustodyPlace
{
    public int Id { get; set; }

    public long ImCustodyPlaceId { get; set; }

    /// <summary>
    /// تاريخ الفحص
    /// </summary>
    public DateOnly? CheckDate { get; set; }

    /// <summary>
    ///  بداية ساعة الفحص 
    /// </summary>
    public TimeOnly? StartTime { get; set; }

    /// <summary>
    /// انتهاء ساعة الفحص
    /// </summary>
    public TimeOnly? EndTime { get; set; }

    /// <summary>
    /// الوزن
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// العدد
    /// </summary>
    public short Quantity { get; set; }

    /// <summary>
    /// هل حاوية أم لا
    /// </summary>
    public bool IsPackage { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public short IsApproved { get; set; }

    /// <summary>
    /// 0 if not done, 1 if investigation is done
    /// </summary>
    public bool Status { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual ImCustodyPlaceCheckRequest ImCustodyPlace { get; set; } = null!;
}
