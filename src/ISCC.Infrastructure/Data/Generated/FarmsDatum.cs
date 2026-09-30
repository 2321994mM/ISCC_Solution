using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المزرعة معتمدة
/// </summary>
public partial class FarmsDatum
{
    public long Id { get; set; }

    public long? ItemId { get; set; }

    public string? FarmCode14 { get; set; }

    /// <summary>
    /// المراكز
    /// </summary>
    public short? VillageId { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? AddressAr { get; set; }

    public string? AddressEn { get; set; }

    /// <summary>
    /// الحوض أو البيفوت
    /// </summary>
    public string? ThePivot { get; set; }

    /// <summary>
    /// قراءة GPS
    /// </summary>
    public string? Gpsread { get; set; }

    /// <summary>
    /// لو معتمدة 1
    /// </summary>
    public bool? IsApproved { get; set; }

    public bool? IsActive { get; set; }

    /// <summary>
    /// is null for default 0 is stopped for a time 1 is stopped permantely
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// from web/system
    /// 1-&gt;online
    /// 0-&gt;offline
    /// </summary>
    public bool? IsOnlineOffline { get; set; }

    public string? FileUpload { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? CenterId { get; set; }

    /// <summary>
    /// المحافظة
    /// </summary>
    public short? GovernId { get; set; }

    public virtual Center? Center { get; set; }

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<FarmCompany> FarmCompanies { get; set; } = new List<FarmCompany>();

    public virtual ICollection<FarmItemCategory> FarmItemCategories { get; set; } = new List<FarmItemCategory>();

    public virtual ICollection<FarmRequest> FarmRequests { get; set; } = new List<FarmRequest>();

    public virtual Governate? Govern { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Village? Village { get; set; }
}
