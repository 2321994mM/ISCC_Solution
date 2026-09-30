using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestDistribution
{
    public long Id { get; set; }

    public long? ImCheckRequestId { get; set; }

    public long? ItemId { get; set; }

    public long? ItemShortNameId { get; set; }

    public long? ImInitiatorId { get; set; }

    public long? ItemCategoryId { get; set; }

    public int ImporterTypeId { get; set; }

    public long ImporterId { get; set; }

    public DateTime? DateDistribution { get; set; }

    public byte? NumDistribution { get; set; }

    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// الوزن الصافي
    /// </summary>
    public decimal? NetWeight { get; set; }

    public bool? IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ImCheckRequest? ImCheckRequest { get; set; }
}
