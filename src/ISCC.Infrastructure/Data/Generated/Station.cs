using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// محطة
/// </summary>
public partial class Station
{
    public long Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// العنوان بالعربية
    /// </summary>
    public string? AddressAr { get; set; }

    /// <summary>
    /// العنوان بالانجليزية
    /// </summary>
    public string? AddressEn { get; set; }

    public string? StationCode { get; set; }

    /// <summary>
    /// السجل الضريبي
    /// </summary>
    public string? TaxesRecord { get; set; }

    /// <summary>
    /// السجل التجاري
    /// </summary>
    public string? CommertialRecord { get; set; }

    /// <summary>
    /// رقم الترخيص الصناعي
    /// </summary>
    public string? IndustrialLicenseNum { get; set; }

    public string? FileUpload { get; set; }

    /// <summary>
    /// لو معتمدة 1
    /// </summary>
    public bool? IsApproved { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public short? GovId { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    /// <summary>
    /// from systemcode table 3
    /// </summary>
    public int? UserTypeId { get; set; }

    public long? CompanyId { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateOnly? EndDateIndustrialLicenseNum { get; set; }

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateOnly? StartDateIndustrialLicenseNum { get; set; }

    /// <summary>
    /// عدد ساعات العمل
    /// </summary>
    public int? WorkingHours { get; set; }

    /// <summary>
    /// متوسط عدد العمال
    /// </summary>
    public int? AverageNumberWorkers { get; set; }

    /// <summary>
    /// عدد الورديات
    /// </summary>
    public int? NumberShifts { get; set; }

    /// <summary>
    /// عدد ايام العمل
    /// </summary>
    public int? NumberWorkingDays { get; set; }

    /// <summary>
    /// موسمي 0 سنوي 1
    /// </summary>
    public byte? SeasonalAnnual { get; set; }

    public int? YearCreation { get; set; }

    /// <summary>
    /// موافقة ورفض الطلب
    /// 
    /// </summary>
    public bool? IsAccepted { get; set; }

    public decimal? FacilityArea { get; set; }

    public decimal? TheNumOfStorageRefrigerators { get; set; }

    public decimal? StorageFridgeCapacity { get; set; }

    public decimal? FastCoolingRefrigerators { get; set; }

    public decimal? TheNumOfProductionLines { get; set; }

    public decimal? ProductionCapacity { get; set; }

    /// <summary>
    /// اسباب الرفض
    /// </summary>
    public string? NotesReject { get; set; }

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaceStationExaminations { get; set; } = new List<ExCheckRequestPlace>();

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaceStationGenshis { get; set; } = new List<ExCheckRequestPlace>();

    public virtual ICollection<ImCustodyPlaceCheckRequest> ImCustodyPlaceCheckRequests { get; set; } = new List<ImCustodyPlaceCheckRequest>();

    public virtual ICollection<StationAccreditationRequest> StationAccreditationRequests { get; set; } = new List<StationAccreditationRequest>();

    public virtual ICollection<StationAccreditation> StationAccreditations { get; set; } = new List<StationAccreditation>();

    public virtual ICollection<StationContact> StationContacts { get; set; } = new List<StationContact>();

    public virtual ICollection<StationEmp> StationEmps { get; set; } = new List<StationEmp>();

    public virtual ICollection<StationManagingDirector> StationManagingDirectors { get; set; } = new List<StationManagingDirector>();
}
