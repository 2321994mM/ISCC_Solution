using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestSampleDatum
{
    public long Id { get; set; }

    public int AnalysisLabTypeId { get; set; }

    public long ExRequestCommitteeId { get; set; }

    public long ExRequestItemId { get; set; }

    public long? LotDataId { get; set; }

    public DateOnly? WithdrawDate { get; set; }

    public string? SampleBarCode { get; set; }

    public double? SampleSize { get; set; }

    public double? SampleRatio { get; set; }

    public bool? IsAccepted { get; set; }

    public string? NotesAr { get; set; }

    public string? RejectReasonAr { get; set; }

    public string? RejectReasonEn { get; set; }

    public string? NotesEn { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public bool? AdminConfirmation { get; set; }

    public short? AdminUser { get; set; }

    public DateTime? AdminDate { get; set; }

    public bool? IsPrint { get; set; }

    public bool? IsTotal { get; set; }

    public long? ItemShortNameId { get; set; }

    public bool? IsTotalAndroid { get; set; }

    public bool? IsFromAndroid { get; set; }

    public string? SylAlkhatimaNumber { get; set; }

    public decimal? Amount { get; set; }

    public decimal? FeesActual { get; set; }

    public bool? IsPaid { get; set; }

    public int? CountSample { get; set; }

    public virtual AnalysisLabType AnalysisLabType { get; set; } = null!;

    public virtual ICollection<ExCheckRequestSampleDataConfirm> ExCheckRequestSampleDataConfirms { get; set; } = new List<ExCheckRequestSampleDataConfirm>();

    public virtual ExRequestCommittee ExRequestCommittee { get; set; } = null!;
}
