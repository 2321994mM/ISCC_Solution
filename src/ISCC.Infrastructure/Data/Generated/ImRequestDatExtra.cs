using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// تفاصيل الشركة او الهيئة
/// </summary>
public partial class ImRequestDatExtra
{
    public long Id { get; set; }

    /// <summary>
    /// طلب الفحص
    /// </summary>
    public long ImRequestDataId { get; set; }

    /// <summary>
    /// الشركة المستوردة
    /// </summary>
    public string? ImportCompany { get; set; }

    /// <summary>
    /// عنوان مندوب صاحب الرسالة
    /// </summary>
    public string? ImporeterCompanyAddress { get; set; }

    /// <summary>
    /// اسم المرسل إليه
    /// </summary>
    public string? RecieverName { get; set; }

    /// <summary>
    /// صاحب الرسالة
    /// </summary>
    public string? OwnerName { get; set; }

    /// <summary>
    /// عنوان صلحب الرسالة
    /// </summary>
    public string? OwnerAddress { get; set; }

    /// <summary>
    /// الشركة المستوردة
    /// </summary>
    public string? ImportCompanyEn { get; set; }

    /// <summary>
    /// عنوان مندوب صاحب الرسالة
    /// </summary>
    public string? ImporeterCompanyAddressEn { get; set; }

    public virtual ImRequestDatum ImRequestData { get; set; } = null!;
}
