using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المدير المسئول
/// </summary>
public partial class StationManagingDirector
{
    /// <summary>
    /// المدير المسئول
    /// </summary>
    public long Id { get; set; }

    public long StationId { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? ArName { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? EnName { get; set; }

    public string? ManagingDirectorNid { get; set; }

    /// <summary>
    /// العنوان بالعربية
    /// </summary>
    public string? AddressAr { get; set; }

    /// <summary>
    /// العنوان بالانجليزية
    /// </summary>
    public string? AddressEn { get; set; }

    public string? Mobile { get; set; }

    public virtual Station Station { get; set; } = null!;
}
