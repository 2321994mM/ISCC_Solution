using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class FreeZone
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public short? GovId { get; set; }

    public string? AddressAr { get; set; }

    public string? AddressEn { get; set; }

    public decimal? Phone { get; set; }

    public decimal? Fax { get; set; }

    public string? Email { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual Governate? Gov { get; set; }
}
