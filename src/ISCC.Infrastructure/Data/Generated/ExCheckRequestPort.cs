using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestPort
{
    public int Id { get; set; }

    public long? ExCheckRequestDataId { get; set; }

    public int PortId { get; set; }

    public int ReqPortTypeId { get; set; }

    public int IsNational { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte PortTypeId { get; set; }

    public virtual ExCheckRequestDatum? ExCheckRequestData { get; set; }
}
