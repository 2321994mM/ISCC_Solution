using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تفاصيل الدفع للشهادات
/// </summary>
public partial class FeesCertificatesPaymentDetile
{
    public long Id { get; set; }

    public string? AttachmentPath { get; set; }

    /// <summary>
    /// رقم البطاقه(pos) او المجموعه(كاش) علي حسب طريقه الدفع
    /// </summary>
    public string? CardOrGroupNumber { get; set; }

    /// <summary>
    /// رقم مرجعي او القسيمه
    /// </summary>
    public string? ReferenceOrCouponNumber { get; set; }

    /// <summary>
    /// تاريخ الدفع
    /// </summary>
    public DateOnly? PaymentDate { get; set; }

    public long? PosInformationId { get; set; }

    public long? ExCertificatesRequestsId { get; set; }

    public virtual ExCertificatesRequest? ExCertificatesRequests { get; set; }
}
