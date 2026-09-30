using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المنفذ
/// </summary>
public partial class Outlet
{
    public long Id { get; set; }

    /// <summary>
    /// الادارة العامة
    /// </summary>
    public byte? GrAdminId { get; set; }

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

    /// <summary>
    /// مشرف الفرع
    /// From HR employee table
    /// </summary>
    public int? SupervisorId { get; set; }

    public bool IsActive { get; set; }

    /// <summary>
    /// from system code 21
    /// صادر	/وارد	/صادر+ وارد
    /// </summary>
    public int IsExport { get; set; }

    public long? UserUpdationId { get; set; }

    public DateOnly? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateOnly? UserDeletionDate { get; set; }

    public long UserCreationId { get; set; }

    public DateOnly UserCreationDate { get; set; }

    /// <summary>
    /// رقم المنفذ بالنسبة لل HR
    /// </summary>
    public long? IdHr { get; set; }

    public int? PortNationalId { get; set; }

    /// <summary>
    /// from system code 21
    /// صادر	/وارد	/صادر+ وارد
    /// </summary>
    public byte IsDisplay { get; set; }

    public bool CanAcceptPayment { get; set; }

    public virtual ICollection<Center> Centers { get; set; } = new List<Center>();

    public virtual ICollection<ExCheckRequest> ExCheckRequests { get; set; } = new List<ExCheckRequest>();

    public virtual ICollection<FumigationUnit> FumigationUnits { get; set; } = new List<FumigationUnit>();

    public virtual GeneralAdmin? GrAdmin { get; set; }

    public virtual ICollection<ImCheckRequest> ImCheckRequests { get; set; } = new List<ImCheckRequest>();

    public virtual ASystemCode IsExportNavigation { get; set; } = null!;

    public virtual ICollection<OutletEmployee> OutletEmployees { get; set; } = new List<OutletEmployee>();

    public virtual ICollection<PosInformation> PosInformations { get; set; } = new List<PosInformation>();
}
