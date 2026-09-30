using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// ميناء
/// </summary>
public partial class ImRequestPort
{
    public int Id { get; set; }

    /// <summary>
    /// طلب الفحص
    /// </summary>
    public long? ImRequestDataId { get; set; }

    /// <summary>
    /// الميناء
    /// </summary>
    public int? PortId { get; set; }

    /// <summary>
    /// نوع الميناء التصدير
    /// transit/arrive/shipping
    /// </summary>
    public int ReqPortTypeId { get; set; }

    /// <summary>
    /// 21 National / 22 International
    /// </summary>
    public int IsNational { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public byte PortTypeId { get; set; }

    public virtual ImRequestDatum? ImRequestData { get; set; }

    public virtual ASystemCode IsNationalNavigation { get; set; } = null!;

    public virtual ASystemCode ReqPortType { get; set; } = null!;
}
