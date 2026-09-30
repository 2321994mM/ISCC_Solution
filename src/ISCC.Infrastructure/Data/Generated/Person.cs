using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class Person
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public int? PersonIdtype { get; set; }

    /// <summary>
    /// رقم قومى/ باسبور
    /// </summary>
    public string? Idnumber { get; set; }

    public short? CountryId { get; set; }

    public string? Job { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public bool? IsActive { get; set; }

    public short? UserActivationId { get; set; }

    public DateTime? UserActivationDate { get; set; }

    public short? VillageId { get; set; }

    public short? CenterId { get; set; }

    public short? GovernId { get; set; }

    public string? NameEn { get; set; }

    public string? AddressEn { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ASystemCode? PersonIdtypeNavigation { get; set; }
}
