using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// إذن استيرادوالتجديد
/// </summary>
public partial class ImPermissionRequestHistory
{
    public long? Id { get; set; }

    public decimal? ImPermissionNumber { get; set; }

    /// <summary>
    /// تاريخ وصول الشحنة
    /// </summary>
    public DateOnly ArrivalDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool? IsPrintAr { get; set; }

    public bool? IsPrintEn { get; set; }

    public bool? IsNoticeArrival { get; set; }

    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// حاله التجديد
    /// </summary>
    public byte? RenewalStatus { get; set; }

    /// <summary>
    /// عدد مرات التجديد
    /// </summary>
    public byte? PrintCount { get; set; }

    /// <summary>
    /// تاريخ الاصدار
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تاريخ اخر طباعه
    /// </summary>
    public DateOnly? EndDate { get; set; }
}
