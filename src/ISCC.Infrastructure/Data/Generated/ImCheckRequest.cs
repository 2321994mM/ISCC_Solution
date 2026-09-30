using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// طلب الفحص الوارد
/// </summary>
public partial class ImCheckRequest
{
    public long Id { get; set; }

    public long? OutletId { get; set; }

    /// <summary>
    /// رقم طلب الفحص
    /// </summary>
    public string CheckRequestNumber { get; set; } = null!;

    /// <summary>
    /// الشركة المصدرة
    /// </summary>
    public string? ExportCompany { get; set; }

    /// <summary>
    /// عنوان الشركة المصدرة
    /// </summary>
    public string? ExportCompanyAddress { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAccepted { get; set; }

    public DateTime? IsAcceptedDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// نوع إذن الاستراد
    /// </summary>
    public byte? ImOperationType { get; set; }

    public string? CompletionNotes { get; set; }

    public byte? CompletionStatus { get; set; }

    public DateTime? CompletionRequestDate { get; set; }

    public DateTime? CompletionResponseDate { get; set; }

    public short? CompletionResponseUserId { get; set; }

    public virtual ICollection<ImCheckRequestCustomsMessage> ImCheckRequestCustomsMessages { get; set; } = new List<ImCheckRequestCustomsMessage>();

    public virtual ICollection<ImCheckRequestDatum> ImCheckRequestData { get; set; } = new List<ImCheckRequestDatum>();

    public virtual ICollection<ImCheckRequestDistribution> ImCheckRequestDistributions { get; set; } = new List<ImCheckRequestDistribution>();

    public virtual ICollection<ImCheckRequestFinalResult> ImCheckRequestFinalResults { get; set; } = new List<ImCheckRequestFinalResult>();

    public virtual ICollection<ImCheckRequestManafest> ImCheckRequestManafests { get; set; } = new List<ImCheckRequestManafest>();

    public virtual ICollection<ImCheckRequestRefuseReason> ImCheckRequestRefuseReasons { get; set; } = new List<ImCheckRequestRefuseReason>();

    public virtual ICollection<ImCheckRequestVisa> ImCheckRequestVisas { get; set; } = new List<ImCheckRequestVisa>();

    public virtual ICollection<ImCheckRequsetShippingMethod> ImCheckRequsetShippingMethods { get; set; } = new List<ImCheckRequsetShippingMethod>();

    public virtual ICollection<ImCustodyPlaceCheckRequest> ImCustodyPlaceCheckRequests { get; set; } = new List<ImCustodyPlaceCheckRequest>();

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ICollection<ImPermissionRequest> ImPermissionRequests { get; set; } = new List<ImPermissionRequest>();

    public virtual ICollection<ImRequestCommittee> ImRequestCommittees { get; set; } = new List<ImRequestCommittee>();

    public virtual Outlet? Outlet { get; set; }
}
