using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شركات المحطة
/// </summary>
public partial class StationCompany
{
    public long Id { get; set; }

    public long? CompanyId { get; set; }

    public long? StationAccreditationId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// 2 تحت الدراسة
    /// 1 مقبول
    /// 0 مرفوض
    /// 3 ايقاف
    /// 
    /// 
    /// 
    /// </summary>
    public byte? Status { get; set; }

    /// <summary>
    /// from systemcode table 3
    /// </summary>
    public int? CompanyTypeId { get; set; }

    public virtual StationAccreditation? StationAccreditation { get; set; }
}
