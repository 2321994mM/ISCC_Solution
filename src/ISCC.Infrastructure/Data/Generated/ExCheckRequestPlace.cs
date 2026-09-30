using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequestPlace
{
    public long Id { get; set; }

    public long ExCheckRequestId { get; set; }

    /// <summary>
    ///  الميناء للجشني
    /// </summary>
    public int? PortNationalId { get; set; }

    /// <summary>
    /// المركز
    /// </summary>
    public short? CenterId { get; set; }

    /// <summary>
    /// المحافظة
    /// </summary>
    public short? GovernId { get; set; }

    /// <summary>
    /// محطة الجشني
    /// </summary>
    public long? StationGenshiId { get; set; }

    /// <summary>
    /// محطة الفحص
    /// </summary>
    public long? StationExaminationId { get; set; }

    /// <summary>
    /// مكان الفحص
    /// </summary>
    public string? ExaminationLocation { get; set; }

    /// <summary>
    /// مسمسي الاعتماد للمحطة
    /// </summary>
    public long? StationAccreditationDataExaminationId { get; set; }

    public long? OutletExmainiationId { get; set; }

    public long? OutletGenshiId { get; set; }

    public virtual Center? Center { get; set; }

    public virtual ExCheckRequest ExCheckRequest { get; set; } = null!;

    public virtual Governate? Govern { get; set; }

    public virtual PortNational? PortNational { get; set; }

    public virtual Station? StationExamination { get; set; }

    public virtual Station? StationGenshi { get; set; }
}
