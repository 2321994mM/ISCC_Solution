using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesTransactionsPaymentDetile
{
    public long Id { get; set; }

    public long? FeesTransactionsId { get; set; }

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

    public virtual FeesTransaction? FeesTransactions { get; set; }

    public virtual PosInformation? PosInformation { get; set; }
}
