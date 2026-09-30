using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FarmFee
{
    public int FarmFeesId { get; set; }

    public int? AcreStart { get; set; }

    public int? AcreEnd { get; set; }

    public decimal? Fees { get; set; }

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public short? UserCreationId { get; set; }

    /// <summary>
    /// null-&gt; for user , value -&gt; if the admin add the row
    /// </summary>
    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public bool? Type { get; set; }
}
