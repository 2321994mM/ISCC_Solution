using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// طلب تغير وجهه
/// </summary>
public partial class ExCertificatesNewCountry
{
    public int Id { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserUpdationId { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public int? NewCountryId { get; set; }

    public bool? Isaccepted { get; set; }

    public int? OldCountryId { get; set; }

    public long? ExCheckRequestId { get; set; }

    public int? PortInternationalIdNew { get; set; }

    public int? PortInternationalIdOld { get; set; }

    public int? ReqPortTypeId { get; set; }

    public int? PortTypeIdOld { get; set; }

    public int? PortTypeIdNew { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }
}
