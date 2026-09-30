using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// معالجات الاشتراطات
/// </summary>
public partial class ExCountryConstrainTreatment
{
    public long Id { get; set; }

    public long CountryConstrainId { get; set; }

    /// <summary>
    /// الجرعة
    /// </summary>
    public decimal? TheDose { get; set; }

    public int? ExposureDay { get; set; }

    public int? ExposureMinute { get; set; }

    public int? ExposureHour { get; set; }

    /// <summary>
    /// 1 لو مفعل انه يظهر في الشهادة الزراعية
    /// </summary>
    public bool IsAcive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ParentId { get; set; }

    /// <summary>
    /// التحليل اختيارى =0 
    /// التحليل اجباري =1
    /// </summary>
    public bool IsOptional { get; set; }

    public byte TreatmentMethodsId { get; set; }

    public virtual ExCountryConstrain CountryConstrain { get; set; } = null!;

    public virtual ICollection<ExChooseTreatment> ExChooseTreatments { get; set; } = new List<ExChooseTreatment>();

    public virtual TreatmentMethod TreatmentMethods { get; set; } = null!;
}
