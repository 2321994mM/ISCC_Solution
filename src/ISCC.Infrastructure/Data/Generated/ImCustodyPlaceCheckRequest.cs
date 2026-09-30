using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اماكن التحفظ للطلب
/// </summary>
public partial class ImCustodyPlaceCheckRequest
{
    public long Id { get; set; }

    /// <summary>
    /// رقم اذن الاستيراد
    /// </summary>
    public long ImCheckRequestId { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// 0 if not done, 1 if investigation is done
    /// </summary>
    public bool? Status { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ImCustodyPlaceId { get; set; }

    /// <summary>
    /// المحطة
    /// </summary>
    public long? StationId { get; set; }

    public virtual ImCheckRequest ImCheckRequest { get; set; } = null!;

    public virtual ICollection<ImCommitteeCustodyPlace> ImCommitteeCustodyPlaces { get; set; } = new List<ImCommitteeCustodyPlace>();

    public virtual ImCustodyPlace? ImCustodyPlace { get; set; }

    public virtual ICollection<ImPermissionItemDivisionCustody> ImPermissionItemDivisionCustodies { get; set; } = new List<ImPermissionItemDivisionCustody>();

    public virtual Station? Station { get; set; }
}
