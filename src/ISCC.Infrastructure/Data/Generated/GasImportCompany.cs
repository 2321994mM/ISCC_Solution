using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// شركات استيراد الغاز
/// </summary>
public partial class GasImportCompany
{
    public long Id { get; set; }

    public long? CompanyId { get; set; }

    /// <summary>
    /// كمية الغاز المستوردة
    /// </summary>
    public decimal? GasAmount { get; set; }

    /// <summary>
    /// تاريخ الموافقة
    /// </summary>
    public DateOnly? AcceptanceDate { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public virtual CompanyNational? Company { get; set; }

    public virtual ICollection<SteamingCompany> SteamingCompanies { get; set; } = new List<SteamingCompany>();
}
