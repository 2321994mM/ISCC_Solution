using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmRequest
{
    public long Id { get; set; }

    public long? FarmsDataId { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAcceppted { get; set; }

    /// <summary>
    /// null لم يتم انتهاء العمل على الطلب
    /// 0 تم رفض الطلب
    /// 1 تم قبول الطلب
    /// 
    /// </summary>
    public bool? IsStatus { get; set; }

    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تم الانتهاء من الدفع
    /// </summary>
    public bool IsPaid { get; set; }

    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// from web/system
    /// 1-&gt;online
    /// 0-&gt;offline
    /// </summary>
    public bool? IsOnlineOffline { get; set; }

    public byte FarmRequestTypeId { get; set; }

    public decimal Fees { get; set; }

    public decimal FeesActual { get; set; }

    public DateOnly? EndDateRequest { get; set; }

    public DateOnly? StartDateRequest { get; set; }

    /// <summary>
    /// الموقف النهائي للطلب
    /// null لم يتم العمل على الطلب
    /// 0 يتم العمل على الطلب
    /// 1 تم الانتهاء من العمل على الطلب
    /// </summary>
    public bool? IsFinalRequst { get; set; }

    public string? PrintText { get; set; }

    public virtual ICollection<FarmCommittee> FarmCommittees { get; set; } = new List<FarmCommittee>();

    public virtual ICollection<FarmCountry> FarmCountries { get; set; } = new List<FarmCountry>();

    public virtual ICollection<FarmRequestItemCategory> FarmRequestItemCategories { get; set; } = new List<FarmRequestItemCategory>();

    public virtual ICollection<FarmRequestRefuseReason> FarmRequestRefuseReasons { get; set; } = new List<FarmRequestRefuseReason>();

    public virtual FarmRequestType FarmRequestType { get; set; } = null!;

    public virtual FarmsDatum? FarmsData { get; set; }
}
