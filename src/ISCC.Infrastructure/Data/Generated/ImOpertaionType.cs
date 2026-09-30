using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// أنواع عمليات الوارد
/// </summary>
public partial class ImOpertaionType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// 1 = permission request / 2 = check request / 3 = both permission and check request
    /// </summary>
    public byte? WithPermission { get; set; }
}
