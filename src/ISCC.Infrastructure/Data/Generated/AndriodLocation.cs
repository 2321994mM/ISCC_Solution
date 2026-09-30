using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AndriodLocation
{
    public long Id { get; set; }

    public long CommitteId { get; set; }

    /// <summary>
    /// 1-&gt;Export , 0-&gt;Import
    /// </summary>
    public bool IsExport { get; set; }

    /// <summary>
    /// the action that user made &apos;Export, Treatment, Sample Data, ....
    /// </summary>
    public byte OperationId { get; set; }

    public long UserId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual AndriodOperation Operation { get; set; } = null!;
}
