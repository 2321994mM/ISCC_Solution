using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class StationDatum
{
    public long StationId { get; set; }

    public string? ArName { get; set; }

    public string? StationCode { get; set; }

    public long? CompanyId { get; set; }

    public short? GovId { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    public string? GovArName { get; set; }

    public string? CenterArName { get; set; }

    public string? VillageArName { get; set; }

    public bool? StationIsActive { get; set; }

    public bool? StationIsAccepted { get; set; }

    public short? StationUserDeletionId { get; set; }

    public string? CompanyName { get; set; }
}
