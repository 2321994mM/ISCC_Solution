namespace ISCC.Api.Application.Areas.DE_Outlets.Models;

/// <summary>
/// The payload the outlets list page's inline edit modal posts to
/// <c>Outlet/UpdateOutlet</c>.
/// </summary>
/// <remarks>
/// Ported from the legacy <c>PlantQuar.DTO.DTO.DataEntry.Outlets.OutletDTO</c> fields that
/// the modal filled in. The legacy DTO also carried a <c>Contacts</c> collection, but the
/// modal never posted one — contacts are edited on the full Edit form — so it is not
/// repeated here.
/// <para>
/// <c>IsDisplay</c> is a checkbox on the modal but a <c>byte</c> column in the database
/// (system code 21), so it is modelled as <c>bool</c> here and cast on save. Modelling it
/// as <c>byte</c> is what produced the "checkbox posted 1 but the field expects 0/1"
/// binding failure that made the legacy Edit form 500.
/// </para>
/// </remarks>
public sealed class OutletEditInputModel
{
    /// <summary>The outlet being edited.</summary>
    public long Id { get; set; }

    /// <summary>الاسم بالعربية</summary>
    public string? ArName { get; set; }

    /// <summary>الاسم بالانجليزية</summary>
    public string? EnName { get; set; }

    /// <summary>العنوان بالعربية</summary>
    public string? AddressAr { get; set; }

    /// <summary>العنوان بالانجليزية</summary>
    public string? AddressEn { get; set; }

    /// <summary>مشرف الفرع</summary>
    public int? SupervisorId { get; set; }

    /// <summary>الادارة العامة</summary>
    public byte? GrAdminId { get; set; }

    /// <summary>System code 21: صادر / وارد / صادر+ وارد</summary>
    public int IsExport { get; set; }

    /// <summary>رقم المنفذ بالنسبة لل HR</summary>
    public long? IdHr { get; set; }

    public int? PortNationalId { get; set; }

    /// <summary>منفذ نشط</summary>
    public bool IsActive { get; set; }

    /// <summary>يظهر في القوائم (system code 21)</summary>
    public bool IsDisplay { get; set; }

    /// <summary>يقبل الدفع</summary>
    public bool CanAcceptPayment { get; set; }
}