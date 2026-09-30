using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class LiableItemsShortName
{
    public long Id { get; set; }

    public int? LiableItemId { get; set; }

    public int? PlantPurposeId { get; set; }

    public int? LiableItemsStatusId { get; set; }

    public int? BiologicalPhaseId { get; set; }

    public string? ScientficNameEn { get; set; }

    public string? ScientficNameAr { get; set; }

    public string? ShortNameAr { get; set; }

    public string? ShortNameEn { get; set; }

    public string? Hscode { get; set; }

    /// <summary>
    /// الموقف من التصدير
    /// </summary>
    public bool ExportStatus { get; set; }

    /// <summary>
    /// الموقف من الاستيراد
    /// </summary>
    public bool ImportStatus { get; set; }

    public string? Reason { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual BiologicalPhase? BiologicalPhase { get; set; }

    public virtual LiableItem? LiableItem { get; set; }

    public virtual LiableItemsStatus? LiableItemsStatus { get; set; }

    public virtual ItemPurpose? PlantPurpose { get; set; }
}
