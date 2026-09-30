using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الموقف النهائي لطلب الفحص
/// </summary>
public partial class ImCheckRequestFinalResult
{
    public long Id { get; set; }

    /// <summary>
    /// جدول طلب الفحص الوارد
    /// </summary>
    public long? ImCheckRequestId { get; set; }

    /// <summary>
    /// جدول الموقف النهائي
    /// </summary>
    public int? ImFinalResultId { get; set; }

    public DateOnly? Date { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ImFinalResult? ImFinalResult { get; set; }
}
