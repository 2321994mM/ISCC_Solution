using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesTransaction
{
    public long Id { get; set; }

    /// <summary>
    /// id table (fees_tablename)
    /// </summary>
    public short? TableNameId { get; set; }

    /// <summary>
    /// id الجدول الرئيسي اللي متحدد في (fess_tablename)
    /// </summary>
    public long? TableId { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? AmountTotal { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

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

    /// <summary>
    /// from systemcode table 3
    /// نوع الموظف حجر ولا شركة ولا فرد ولاهيئه
    /// </summary>
    public int? UserTypeId { get; set; }

    public DateOnly? Date { get; set; }

    /// <summary>
    /// نوع الحساب من system code رقم 33
    /// </summary>
    public int? AccountType { get; set; }

    public virtual ICollection<FeesTransactionsDetile> FeesTransactionsDetiles { get; set; } = new List<FeesTransactionsDetile>();

    public virtual ICollection<FeesTransactionsPaymentDetile> FeesTransactionsPaymentDetiles { get; set; } = new List<FeesTransactionsPaymentDetile>();

    public virtual FeesTableName? TableName { get; set; }
}
