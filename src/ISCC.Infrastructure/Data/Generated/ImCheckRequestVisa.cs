using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// عدد التاشيرات علي طلب الفحص
/// </summary>
public partial class ImCheckRequestVisa
{
    public long Id { get; set; }

    /// <summary>
    /// جدول التاشيره
    /// </summary>
    public long? ImVisaId { get; set; }

    /// <summary>
    /// جدول طلب الفحص الوارد
    /// </summary>
    public long? ImCheckRequestId { get; set; }

    public DateOnly? Date { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ImCheckRequest? ImCheckRequest { get; set; }

    public virtual ImVisa? ImVisa { get; set; }
}
