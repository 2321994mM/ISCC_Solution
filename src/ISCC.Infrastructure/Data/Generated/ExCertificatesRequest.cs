using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// بيانات الشهادة
/// </summary>
public partial class ExCertificatesRequest
{
    public long Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    /// <summary>
    /// رقم بوليصة الشحن
    /// </summary>
    public string? ShippingPolicyNumber { get; set; }

    public string? ShippingCompanyName { get; set; }

    /// <summary>
    ///  وسيلة الشحن
    /// </summary>
    public long? ShipmentmeanId { get; set; }

    public DateOnly? ShippingDate { get; set; }

    public string? ShippingAgency { get; set; }

    /// <summary>
    /// رقم الشركة
    /// </summary>
    public long ImporterId { get; set; }

    public int ExporterId { get; set; }

    public long ExporterTypeId { get; set; }

    public string? Details { get; set; }

    public string? CertificateNumber { get; set; }

    public int CertificateNo { get; set; }

    public int ArrivePortId { get; set; }

    public bool? Isaccepted { get; set; }

    public bool Isprint { get; set; }

    /// <summary>
    /// لغة الشهادة
    /// </summary>
    public bool? Isenglish { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    /// <summary>
    /// لوط
    /// </summary>
    public bool? IsLot { get; set; }

    /// <summary>
    /// حاويات
    /// </summary>
    public bool? IsContainers { get; set; }

    /// <summary>
    /// معالجه
    /// </summary>
    public bool? IsTreatment { get; set; }

    public bool? IsAdditionalDeclaretion { get; set; }

    public bool? IsPaid { get; set; }

    /// <summary>
    /// طــريقة النقل
    /// </summary>
    public byte? TransportMeanId { get; set; }

    /// <summary>
    /// تفاصيل أو رقم الرحلة
    /// </summary>
    public string? ShipName { get; set; }

    /// <summary>
    /// وسـائل النقل الدولية
    /// </summary>
    public long? InternationalTransportationId { get; set; }

    /// <summary>
    /// أسم الشركة المستوردة باللغه الأنجيلزية
    /// </summary>
    public string? ImportCompanyNameEn { get; set; }

    /// <summary>
    /// عنوان الشركة المستوردة باللغه الأنجيلزية
    /// </summary>
    public string? ImporeterCompanyAddressEn { get; set; }

    /// <summary>
    /// أسم الشركة المستوردة باللغه العربية
    /// </summary>
    public string? ImportCompanyNameAr { get; set; }

    /// <summary>
    /// عنوان الشركة المستوردة باللغه العربية
    /// </summary>
    public string? ImporeterCompanyAddressAr { get; set; }

    /// <summary>
    /// ميناء الشحن
    /// </summary>
    public int? ShippingPort { get; set; }

    /// <summary>
    /// الدولة المستوردة
    /// </summary>
    public short ImportingCountry { get; set; }

    /// <summary>
    /// نوع الميناء الدوله المستورده
    /// </summary>
    public byte PortTypeImportingCountry { get; set; }

    /// <summary>
    /// ميناء الوصول
    /// </summary>
    public int? PortAccess { get; set; }

    /// <summary>
    /// دولة العبور
    /// </summary>
    public short? TransitCountry { get; set; }

    /// <summary>
    /// نوع الميناء دوله العبور
    /// </summary>
    public byte? PortTypeTransitCountry { get; set; }

    /// <summary>
    /// ميناء العبور
    /// </summary>
    public int? TransitPort { get; set; }

    public string? RejectReason { get; set; }

    public virtual ICollection<ExCertificateAddtionUser> ExCertificateAddtionUsers { get; set; } = new List<ExCertificateAddtionUser>();

    public virtual ICollection<ExCertificateAddtion> ExCertificateAddtions { get; set; } = new List<ExCertificateAddtion>();

    public virtual ICollection<ExCertificatesRequestsFile> ExCertificatesRequestsFiles { get; set; } = new List<ExCertificatesRequestsFile>();

    public virtual ICollection<ExCertificatesRequestsLotDatum> ExCertificatesRequestsLotData { get; set; } = new List<ExCertificatesRequestsLotDatum>();

    public virtual ICollection<ExCertificatesRequestsPayment> ExCertificatesRequestsPayments { get; set; } = new List<ExCertificatesRequestsPayment>();

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ICollection<ExCheckRequestCustomsMessage> ExCheckRequestCustomsMessages { get; set; } = new List<ExCheckRequestCustomsMessage>();

    public virtual ICollection<FeesCertificatesPaymentDetile> FeesCertificatesPaymentDetiles { get; set; } = new List<FeesCertificatesPaymentDetile>();
}
