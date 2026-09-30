using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الرسائل العليمة
/// </summary>
public partial class ImScientificResearch
{
    public long Id { get; set; }

    public long? ImPermissionId { get; set; }

    public long ImScientificResearchPersonId { get; set; }

    public long ImScientificResearchOrganizationId { get; set; }

    /// <summary>
    /// الوظيفة الحالية
    /// </summary>
    public string? PersonJobTitleAr { get; set; }

    /// <summary>
    /// المدير الحالى
    /// </summary>
    public string? OrgManagerNameAr { get; set; }

    public string? OrgManagerNameEn { get; set; }

    /// <summary>
    /// ميناء الدخول
    /// </summary>
    public int PortNationalId { get; set; }

    /// <summary>
    /// رقم الشهادة الجمركية
    /// </summary>
    public string TaxCertificateNumber { get; set; } = null!;

    /// <summary>
    /// رقم بوليصة الشحن
    /// </summary>
    public string ShipmentPolicyNumber { get; set; } = null!;

    /// <summary>
    /// وسيلة الشحن
    /// </summary>
    public byte ShipmentMeanId { get; set; }

    /// <summary>
    /// وسيلة النقل
    /// </summary>
    public byte TransportMeanId { get; set; }

    /// <summary>
    /// العدد
    /// </summary>
    public short Quantity { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// اسم وسيلة الشحن
    /// </summary>
    public string? TransportMeanName { get; set; }

    public virtual ImPermissionRequest? ImPermission { get; set; }

    public virtual ICollection<ImScientificResearchItemPlantInseketLieble> ImScientificResearchItemPlantInseketLiebles { get; set; } = new List<ImScientificResearchItemPlantInseketLieble>();

    public virtual ICollection<ImScientificResearchItemPlantProduct> ImScientificResearchItemPlantProducts { get; set; } = new List<ImScientificResearchItemPlantProduct>();

    public virtual ImScientificResearchOrganization ImScientificResearchOrganization { get; set; } = null!;

    public virtual ImScientificResearchPerson ImScientificResearchPerson { get; set; } = null!;

    public virtual PortNational PortNational { get; set; } = null!;

    public virtual ShipmentMean ShipmentMean { get; set; } = null!;

    public virtual TransportMean TransportMean { get; set; } = null!;
}
