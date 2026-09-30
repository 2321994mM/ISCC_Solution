using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FeesTransactionsDetile
{
    public long Id { get; set; }

    public long? FeesActionId { get; set; }

    public long? FeesTransactionsId { get; set; }

    public long? ItemsId { get; set; }

    public long? ShiftId { get; set; }

    public long? SampleDataId { get; set; }

    /// <summary>
    /// جاي من جدول Im_Request_TreatmentData عشان لو اكثر من لوط هيبقى كل لوط له id مختلف
    /// </summary>
    public long? TreatmentDataId { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual FeesAction? FeesAction { get; set; }

    public virtual FeesTransaction? FeesTransactions { get; set; }
}
