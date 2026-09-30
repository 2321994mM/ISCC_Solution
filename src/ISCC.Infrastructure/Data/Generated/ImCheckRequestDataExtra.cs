using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestDataExtra
{
    public long Id { get; set; }

    public long ImCheckRequestDataId { get; set; }

    public string? ImportCompany { get; set; }

    public string? ImporeterCompanyAddress { get; set; }

    public string? RecieverName { get; set; }

    public string? OwnerName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? ImportCompanyEn { get; set; }

    public string? ImporeterCompanyAddressEn { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ImCheckRequestDatum ImCheckRequestData { get; set; } = null!;
}
