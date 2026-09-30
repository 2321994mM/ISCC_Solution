using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class CompanyNational1
{
    public long Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? AddressAr { get; set; }

    public string? AddressEn { get; set; }

    public string? TaxesRecord { get; set; }

    public string? CommertialRecord { get; set; }

    public bool IsTreatment { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsOnlineOffline { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public string OwnerAr { get; set; } = null!;

    public bool? IsApproved { get; set; }

    public string? OwnerEn { get; set; }

    public short? CenterId { get; set; }

    public short? VillageId { get; set; }

    public short? UserActivationId { get; set; }

    public DateTime? UserActivationDate { get; set; }

    public virtual ICollection<CompanyActivity1> CompanyActivity1s { get; set; } = new List<CompanyActivity1>();
}
