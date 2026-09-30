using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCheckRequestPort
{
    public int Id { get; set; }

    public long? ImCheckRequestDataId { get; set; }

    /// <summary>
    /// رقم الميناء
    /// </summary>
    public int? PortId { get; set; }

    /// <summary>
    /// ميناء شحن وصور وعبور
    /// </summary>
    public int ReqPortTypeId { get; set; }

    /// <summary>
    /// دولية ولا لا
    /// </summary>
    public int IsNational { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    /// <summary>
    /// نوع المينا بحرى جوى مطار
    /// </summary>
    public byte PortTypeId { get; set; }
}
