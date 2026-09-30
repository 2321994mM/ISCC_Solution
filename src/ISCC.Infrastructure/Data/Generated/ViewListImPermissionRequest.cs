using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ViewListImPermissionRequest
{
    public long ImPermissionRequestId { get; set; }

    public decimal? ImPermissionNumber { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public string? OperationTypeName { get; set; }

    public string? ExportCountryName { get; set; }

    public long ImporterId { get; set; }

    public int ImporterTypeId { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsPrintAr { get; set; }

    public bool? IsPrintEn { get; set; }

    public long? ImCheckRequestId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public byte? RenewalStatus { get; set; }

    public byte? PrintCount { get; set; }

    public string? ImporterTypeName { get; set; }

    public string? ImporterName { get; set; }

    public string? ShortName { get; set; }
}
