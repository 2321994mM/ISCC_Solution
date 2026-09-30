using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اشترطات المزارع
/// </summary>
public partial class FarmConstrain
{
    public long Id { get; set; }

    public long? ItemId { get; set; }

    public short? CountryId { get; set; }

    public long? FarmConstrainTextId { get; set; }

    /// <summary>
    /// المعاينة
    /// </summary>
    public bool? IsPreview { get; set; }

    public int? AnalysisTypeId { get; set; }

    public bool? IsActive { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public byte? CountVisit { get; set; }

    public virtual AnalysisType? AnalysisType { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<FarmCommitteeConstrain> FarmCommitteeConstrains { get; set; } = new List<FarmCommitteeConstrain>();

    public virtual FarmConstrainText? FarmConstrainText { get; set; }

    public virtual Item? Item { get; set; }
}
