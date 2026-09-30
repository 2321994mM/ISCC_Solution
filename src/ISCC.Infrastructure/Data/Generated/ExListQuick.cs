using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExListQuick
{
    public long? OutletUserId { get; set; }

    public string? OutletUserName { get; set; }

    public short? CenterId { get; set; }

    public long ExCheckRequestId { get; set; }

    public string ImCheckRequestNumber { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public bool? IsAccepted { get; set; }

    public bool? IsActive { get; set; }

    public string? ExportCountryName { get; set; }

    public long ImporterId { get; set; }

    public int ImporterTypeId { get; set; }

    public bool? IsPaid { get; set; }

    public long? OutletId { get; set; }

    public string? ImporterTypeName { get; set; }

    public string? ImporterName { get; set; }

    public short? F { get; set; }

    public long G { get; set; }

    public long? OutletExaminationId { get; set; }

    public string? OutletExaminationName { get; set; }

    public long? StationExaminationId { get; set; }

    public long? OutletGenshiId { get; set; }

    public string? OutletGenshiName { get; set; }

    public long? StationGenshiId { get; set; }

    public int? ClosedRequest { get; set; }

    public int FinalResultId { get; set; }

    public string FinalResultName { get; set; } = null!;

    public string? StationExaminationName { get; set; }

    public string? StationGenshiName { get; set; }
}
