using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اعتمادات الشركة
/// </summary>
public partial class CompanyAccreditation
{
    public long Id { get; set; }

    /// <summary>
    /// الشركة
    /// </summary>
    public long? CompanyId { get; set; }

    /// <summary>
    /// الدولة
    /// </summary>
    public short? CountryId { get; set; }

    /// <summary>
    /// تاريخ بداية الاعتماد
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تاريخ نهاية الاعتماد
    /// </summary>
    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// null-&gt;ask for accredation
    /// 0-&gt;not accepted
    /// 1-&gt;Accepted
    /// </summary>
    public bool? IsApproved { get; set; }

    public short? UserUpdationId { get; set; }

    /// <summary>
    /// product or plant ID manual no relation
    /// </summary>
    public long? ItemShortNameId { get; set; }

    public virtual CompanyNational? Company { get; set; }

    public virtual ICollection<CompanyAccreditationCommittee> CompanyAccreditationCommittees { get; set; } = new List<CompanyAccreditationCommittee>();

    public virtual Country? Country { get; set; }

    public virtual ItemShortName? ItemShortName { get; set; }
}
