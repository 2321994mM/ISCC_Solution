using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImRequestTreatmentDatum
{
    public long Id { get; set; }

    /// <summary>
    /// لجنة المعالجة
    /// </summary>
    public long ImRequestCommitteeId { get; set; }

    public long ImRequestItemId { get; set; }

    public long? ImRequestLotDataId { get; set; }

    public byte? TreatmentTypeId { get; set; }

    /// <summary>
    /// شركة المعالجة
    /// </summary>
    public long? CompanyId { get; set; }

    /// <summary>
    /// مكان المعالجة(محطة معتمدة)
    /// </summary>
    public long? StationId { get; set; }

    public string? StationPlace { get; set; }

    /// <summary>
    /// طريقة المعالجة
    /// </summary>
    public byte TreatmentMethodId { get; set; }

    /// <summary>
    /// مادة المعالجة
    /// </summary>
    public byte? TreatmentMatId { get; set; }

    /// <summary>
    /// حجم الرسالة (متر مكعب / سم مكعب)
    /// </summary>
    public decimal? Size { get; set; }

    /// <summary>
    /// كمية المادة المستخدمة في المعالجة
    /// </summary>
    public decimal? TreatmentMatAmount { get; set; }

    /// <summary>
    /// الجرعة
    /// </summary>
    public decimal? TheDose { get; set; }

    public int? ExposureMinute { get; set; }

    public int? ExposureHour { get; set; }

    public int? ExposureDay { get; set; }

    /// <summary>
    /// درجة الحرارة
    /// </summary>
    public decimal? Temperature { get; set; }

    public string? Note { get; set; }

    /// <summary>
    /// رقم الختم الحراري
    /// </summary>
    public decimal? ThermalSealNumber { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    /// <summary>
    /// الاسم المختصر 
    /// </summary>
    public long? ItemShortNameId { get; set; }

    /// <summary>
    /// في حاله الفحص لو كلي واتحول الي جزئي
    /// </summary>
    public bool? IsTotalAndroid { get; set; }

    /// <summary>
    /// مين رمي row (system or android)
    /// </summary>
    public bool? IsFromAndroid { get; set; }

    /// <summary>
    /// (0) in the case of all,(1) in the case of the part في حاله الجزئي او الكلي
    /// </summary>
    public bool? IsTotal { get; set; }

    public string? Procedures { get; set; }

    /// <summary>
    /// المبلغ
    /// </summary>
    public decimal? Amount { get; set; }

    public decimal? FeesActual { get; set; }

    public bool? IsPaid { get; set; }

    public virtual ICollection<ImFumigation> ImFumigations { get; set; } = new List<ImFumigation>();

    public virtual ImRequestCommittee ImRequestCommittee { get; set; } = null!;

    public virtual ICollection<ImRequestTreatmentDataConfirm> ImRequestTreatmentDataConfirms { get; set; } = new List<ImRequestTreatmentDataConfirm>();

    public virtual TreatmentMaterial? TreatmentMat { get; set; }
}
