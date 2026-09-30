using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اسباب رفض الطلب( صادر/وارد)
/// </summary>
public partial class RefuseReason
{
    public short Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public bool? IsStop { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// هل يرفض الطلب كله في حالة وجود إصابة
    /// </summary>
    public int? IsExport { get; set; }

    public int? RefusedStopped { get; set; }

    /// <summary>
    /// from systemcode table 20
    ///  اذن استراد 
    ///  طلب فحص وارد 74
    /// farm 78
    /// 
    /// </summary>
    public int? ASystemCodeId { get; set; }

    public virtual ICollection<ExCheckRequestRefuseReason> ExCheckRequestRefuseReasons { get; set; } = new List<ExCheckRequestRefuseReason>();

    public virtual ICollection<FarmRequestRefuseReason> FarmRequestRefuseReasons { get; set; } = new List<FarmRequestRefuseReason>();

    public virtual ICollection<ImCheckRequestRefuseReason> ImCheckRequestRefuseReasons { get; set; } = new List<ImCheckRequestRefuseReason>();

    public virtual ICollection<ImPermissionRequestRefuseReason> ImPermissionRequestRefuseReasons { get; set; } = new List<ImPermissionRequestRefuseReason>();
}
