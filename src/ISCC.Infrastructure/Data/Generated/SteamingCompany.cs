using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شركات التبخير
/// </summary>
public partial class SteamingCompany
{
    public long Id { get; set; }

    /// <summary>
    /// شركة المكافحة
    /// </summary>
    public long? CompanyId { get; set; }

    /// <summary>
    /// كمية الغاز المنصرف للمعالجة
    /// </summary>
    public decimal? OutGasAmount { get; set; }

    /// <summary>
    /// شركة استيراد الغاز
    /// </summary>
    public long? GasCompanyId { get; set; }

    /// <summary>
    /// تاريخ الصرف
    /// </summary>
    public DateOnly? OutGasDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual CompanyNational? Company { get; set; }

    public virtual GasImportCompany? GasCompany { get; set; }
}
