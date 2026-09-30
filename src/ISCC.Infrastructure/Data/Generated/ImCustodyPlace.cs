using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اماكن التحفظ
/// </summary>
public partial class ImCustodyPlace
{
    public long Id { get; set; }

    /// <summary>
    /// الوصف انجليزى
    /// </summary>
    public string EnDesc { get; set; } = null!;

    /// <summary>
    /// الوصف عربى
    /// </summary>
    public string ArDesc { get; set; } = null!;

    public double StorageCapacity { get; set; }

    public short CenterId { get; set; }

    public string Address { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public string NationalId { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public double PreviewQuantityDuration { get; set; }

    /// <summary>
    /// كمية/تاريخ
    /// </summary>
    public DateTime? DateStored { get; set; }

    /// <summary>
    /// الكمية المخزنة/التاريخ
    /// </summary>
    public double Quantity { get; set; }

    /// <summary>
    /// 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool? IsApproved { get; set; }

    /// <summary>
    /// 0 if not done, 1 if investigation is done
    /// </summary>
    public bool? Status { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// مخزن/ساحة
    /// </summary>
    public byte ImCustodyPlaceType { get; set; }

    public virtual ICollection<ImCustodyPlaceCheckRequest> ImCustodyPlaceCheckRequests { get; set; } = new List<ImCustodyPlaceCheckRequest>();

    public virtual ImCustodyPlaceType ImCustodyPlaceTypeNavigation { get; set; } = null!;
}
