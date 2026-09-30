using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExRequestTreatmentDatum
{
    public long Id { get; set; }

    public long ExRequestCommitteeId { get; set; }

    public long ExRequestItemId { get; set; }

    public long? ExRequestLotDataId { get; set; }

    public byte? TreatmentTypeId { get; set; }

    public long? CompanyId { get; set; }

    public long? StationId { get; set; }

    public string? StationPlace { get; set; }

    public byte TreatmentMethodId { get; set; }

    public byte? TreatmentMatId { get; set; }

    public decimal? Size { get; set; }

    public decimal? TreatmentMatAmount { get; set; }

    public decimal? TheDose { get; set; }

    public int? ExposureMinute { get; set; }

    public int? ExposureHour { get; set; }

    public int? ExposureDay { get; set; }

    public decimal? Temperature { get; set; }

    public string? Note { get; set; }

    public decimal? ThermalSealNumber { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? ItemShortNameId { get; set; }

    public bool? IsTotalAndroid { get; set; }

    public bool? IsFromAndroid { get; set; }

    public bool? IsTotal { get; set; }

    public string? Procedures { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public decimal? FeesActual { get; set; }

    public bool? IsPaid { get; set; }

    public virtual ExRequestCommittee ExRequestCommittee { get; set; } = null!;

    public virtual ICollection<ExRequestTreatmentDataConfirm> ExRequestTreatmentDataConfirms { get; set; } = new List<ExRequestTreatmentDataConfirm>();

    public virtual TreatmentMaterial? TreatmentMat { get; set; }
}
