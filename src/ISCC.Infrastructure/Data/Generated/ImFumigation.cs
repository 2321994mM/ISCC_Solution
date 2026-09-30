using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImFumigation
{
    /// <summary>
    /// المعرف الفريد لطلب التطهير
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ربط بطلب الفحص Im_CheckRequest
    /// </summary>
    public long RequestId { get; set; }

    /// <summary>
    /// ربط بالشهادة الجمركية Im_CheckRequest_Customs_Message
    /// </summary>
    public int? CustomsMessageId { get; set; }

    /// <summary>
    /// ربط بلجنة الفحص Im_RequestCommittee
    /// </summary>
    public long CommitteeId { get; set; }

    /// <summary>
    /// وزن الشحنة الخاضعة للتطهير
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// مكان إجراء عملية العلاج
    /// </summary>
    public string? TreatmentLocation { get; set; }

    /// <summary>
    /// العنوان التفصيلي لمكان العلاج
    /// </summary>
    public string? TreatmentAddress { get; set; }

    /// <summary>
    /// ربط بميناء التطهير PortNational
    /// </summary>
    public int PortId { get; set; }

    /// <summary>
    /// حالة الطلب: 1 موافقة، 2 رفض، 3 إعادة علاج
    /// </summary>
    public short ApprovalStatus { get; set; }

    /// <summary>
    /// سبب التحفظ عند الرفض أو إعادة العلاج
    /// </summary>
    public string? ReservationReason { get; set; }

    /// <summary>
    /// مسار أو قائمة المرفقات الخاصة بالطلب
    /// </summary>
    public string? Attachments { get; set; }

    /// <summary>
    /// عدد بوالص الشحنة
    /// </summary>
    public int? PoliciesCount { get; set; }

    /// <summary>
    /// كمية المخلفات الناتجة عن التطهير
    /// </summary>
    public decimal? WasteQuantity { get; set; }

    /// <summary>
    /// الكمية المستلمة بعد التطهير
    /// </summary>
    public decimal? ReceivedQuantity { get; set; }

    /// <summary>
    /// يحدد هل السجل فعال أم محذوف منطقيًا
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// معرف المستخدم الذي أنشأ السجل
    /// </summary>
    public int? UserCreationId { get; set; }

    /// <summary>
    /// تاريخ إنشاء السجل
    /// </summary>
    public DateTime? UserCreationDate { get; set; }

    /// <summary>
    /// معرف المستخدم الذي عدّل السجل آخر مرة
    /// </summary>
    public int? UserUpdationId { get; set; }

    /// <summary>
    /// تاريخ آخر تعديل على السجل
    /// </summary>
    public DateTime? UserUpdationDate { get; set; }

    /// <summary>
    /// معرف المستخدم الذي حذف السجل
    /// </summary>
    public int? UserDeletionId { get; set; }

    /// <summary>
    /// تاريخ حذف السجل
    /// </summary>
    public DateTime? UserDeletionDate { get; set; }

    public short? WorkflowStatus { get; set; }

    public long? TreatmentDataId { get; set; }

    public string? Notes { get; set; }

    public long? SourceDistributionResultId { get; set; }

    public short? SourceResultStatus { get; set; }

    public int? SourceSupervisorUserId { get; set; }

    public long? LotCategoryId { get; set; }

    public string? WeightUnit { get; set; }

    public long? LotResultId { get; set; }

    public string? InspectionRequestHoldReason { get; set; }

    public string? InspectionRequestAction { get; set; }

    public long? FinalLotResultId { get; set; }

    public virtual ImRequestCommittee Committee { get; set; } = null!;

    public virtual ImCheckRequestCustomsMessage? CustomsMessage { get; set; }

    public virtual ICollection<ImFumigationReleaseRequest> ImFumigationReleaseRequests { get; set; } = new List<ImFumigationReleaseRequest>();

    public virtual ImCheckRequestItemsLotCategory? LotCategory { get; set; }

    public virtual ImCheckRequestItemsLotResult? LotResult { get; set; }

    public virtual PortNational Port { get; set; } = null!;

    public virtual ImCheckRequest Request { get; set; } = null!;

    public virtual ImRequestTreatmentDatum? TreatmentData { get; set; }
}
