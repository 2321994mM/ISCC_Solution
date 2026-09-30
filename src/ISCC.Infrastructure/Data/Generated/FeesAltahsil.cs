using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesAltahsil
{
    public long Id { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal AmountTotal { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// from systemcode table 30
    /// نوع عملية الدفع فيزا - كاش
    /// </summary>
    public int? PaymentTypeId { get; set; }

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

    public DateOnly? Date { get; set; }

    /// <summary>
    /// نوع الحساب من system code رقم 33
    /// </summary>
    public int? AccountType { get; set; }

    public string? Office { get; set; }

    public string? CustomsCertificateNumber { get; set; }

    public string NationalId { get; set; } = null!;

    public string? TaxRegistry { get; set; }

    public string? CommercialRegister { get; set; }

    public string? Name { get; set; }

    public string? FarmName { get; set; }

    public string? LedgerNumber { get; set; }

    public bool IsUsed { get; set; }

    public DateTime? UsedDate { get; set; }

    public string? Department { get; set; }

    public string? Item { get; set; }

    public short? UsedByUserId { get; set; }

    public string? UsedByUserName { get; set; }

    public virtual ASystemCode? AccountTypeNavigation { get; set; }

    public virtual ICollection<FeesAltahsilDetile> FeesAltahsilDetiles { get; set; } = new List<FeesAltahsilDetile>();

    public virtual ASystemCode? PaymentType { get; set; }
}
