using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الموقف النهائي لطلب الفحص
/// </summary>
public partial class ImFinalResult
{
    public int Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    /// <summary>
    /// الطلب فعال ام لا
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// تم ايقاف الطلب ام لا
    /// 0 = مرفوض
    /// 1 = مقبول
    /// </summary>
    public bool? Status { get; set; }

    public virtual ICollection<ImCheckRequestFinalResult> ImCheckRequestFinalResults { get; set; } = new List<ImCheckRequestFinalResult>();
}
