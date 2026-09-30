using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اعتماد المحطة
/// </summary>
public partial class StationAccreditationRequest
{
    public long Id { get; set; }

    /// <summary>
    /// المحطة
    /// </summary>
    public long StationId { get; set; }

    /// <summary>
    /// المحطة
    /// </summary>
    public long StationAccreditationDataId { get; set; }

    public byte StationAccreditationRequestTypeId { get; set; }

    public string? NotesQuarantine { get; set; }

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool? IsPaid { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? AmountTotal { get; set; }

    public byte? CommitteeTypeId { get; set; }

    /// <summary>
    /// موافقة ورفض الطلب
    /// 
    /// </summary>
    public bool? IsAccepted { get; set; }

    /// <summary>
    /// الموقف النهائي للطلب
    /// null لم يتم العمل على الطلب
    /// 0 يتم العمل على الطلب
    /// 1 تم الانتهاء من العمل على الطلب
    /// </summary>
    public bool? IsFinalRequst { get; set; }

    public virtual CommitteeType? CommitteeType { get; set; }

    public virtual Station Station { get; set; } = null!;

    public virtual ICollection<StationAccreditationCommittee> StationAccreditationCommittees { get; set; } = new List<StationAccreditationCommittee>();

    public virtual StationAccreditationDatum StationAccreditationData { get; set; } = null!;

    public virtual ICollection<StationAccreditationRequestFee> StationAccreditationRequestFees { get; set; } = new List<StationAccreditationRequestFee>();

    public virtual StationAccreditationRequestType StationAccreditationRequestType { get; set; } = null!;
}
