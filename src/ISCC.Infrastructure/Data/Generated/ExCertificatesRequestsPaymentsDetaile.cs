using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCertificatesRequestsPaymentsDetaile
{
    public long Id { get; set; }

    public long? ExCertificatesRequestsPaymentsId { get; set; }

    public string? OrderNumber { get; set; }

    /// <summary>
    /// 0 تم رفض عملية البنك
    /// 1 تم قبول العملية 
    /// null تم الارسال ولم الرد من البنك
    /// </summary>
    public bool? IsSuccessBank { get; set; }

    /// <summary>
    /// كود العملية من البنك
    /// </summary>
    public string? CodeBank { get; set; }

    /// <summary>
    /// from systemcode table 3
    /// نوع الموظف حجر ولا شركة ولا فرد ولاهيئه
    /// </summary>
    public int? UserTypeId { get; set; }

    public DateOnly? Date { get; set; }

    /// <summary>
    /// from systemcode table 30
    /// نوع عملية الدفع فيزا - كاش
    /// </summary>
    public int? PaymentTypeId { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public virtual ExCertificatesRequestsPayment? ExCertificatesRequestsPayments { get; set; }
}
