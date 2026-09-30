using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// منافستو
/// </summary>
public partial class ImManafest
{
    public long Id { get; set; }

    /// <summary>
    /// رقم المنافيست
    /// </summary>
    public string ManafestNum { get; set; } = null!;

    /// <summary>
    /// تاريخ تقديم المنافيست
    /// </summary>
    public DateOnly? SubmissionDate { get; set; }

    /// <summary>
    /// اسم الباخرة
    /// </summary>
    public string? ShipName { get; set; }

    /// <summary>
    /// تاريخ الوصول
    /// </summary>
    public DateOnly? ArriveDate { get; set; }

    /// <summary>
    /// وقت الوصول
    /// </summary>
    public TimeOnly? ArriveTime { get; set; }

    /// <summary>
    /// شركة الملاحة
    /// </summary>
    public string? NavigationCompany { get; set; }

    /// <summary>
    /// المنشأ(دولة)
    /// </summary>
    public string? Origin { get; set; }

    /// <summary>
    /// ميناء الشحن
    /// </summary>
    public string? ShipmentPort { get; set; }

    /// <summary>
    /// رقم البوليصة
    /// </summary>
    public string? PolicyNumber { get; set; }

    /// <summary>
    /// اسم المستورد
    /// </summary>
    public string? ImporterName { get; set; }

    /// <summary>
    /// اسم الصنف
    /// </summary>
    public string? PlantName { get; set; }

    /// <summary>
    /// العدد
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// الوحدة
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// الوزن القائم
    /// </summary>
    public decimal? GrossWeight { get; set; }

    /// <summary>
    /// الوزن الصافي
    /// </summary>
    public decimal? NetWeight { get; set; }

    /// <summary>
    /// بيان التعديلات
    /// </summary>
    public string? EditRecord { get; set; }

    /// <summary>
    /// تاريخ نهاية التفريغ
    /// </summary>
    public DateOnly? DischargeEndDate { get; set; }

    /// <summary>
    /// تاريخ التقدم للمنافيستو للحجر
    /// </summary>
    public DateOnly? ToHagrDate { get; set; }

    /// <summary>
    /// تاريخ تسديد الرسالة
    /// </summary>
    public DateOnly? ExaminationDate { get; set; }

    /// <summary>
    /// رقم الشهادة الجمركية
    /// </summary>
    public string? CustomsCertificate { get; set; }

    /// <summary>
    /// رقم طلب الاتمام
    /// </summary>
    public string? CompletionApplicationNum { get; set; }

    /// <summary>
    /// ترانزيت أم لا
    /// </summary>
    public bool IsTransit { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ImCheckRequestManafest> ImCheckRequestManafests { get; set; } = new List<ImCheckRequestManafest>();
}
