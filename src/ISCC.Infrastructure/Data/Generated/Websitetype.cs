using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class Websitetype
{
    public int Id { get; set; }

    public string? TypeAr { get; set; }

    public string? TypeEn { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsImage { get; set; }

    public virtual ICollection<WebsiteTypeDetail> WebsiteTypeDetails { get; set; } = new List<WebsiteTypeDetail>();
}
