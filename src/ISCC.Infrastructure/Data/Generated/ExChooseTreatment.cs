using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// اختيار المعالجه
/// </summary>
public partial class ExChooseTreatment
{
    public long Id { get; set; }

    public long? ExCheckRequestId { get; set; }

    public byte? TreatmentMethodsId { get; set; }

    /// <summary>
    /// product or plant ID manual no relation
    /// </summary>
    public long ItemShortNameId { get; set; }

    /// <summary>
    /// التحليل اختيارى =0 
    /// التحليل اجباري =1
    /// </summary>
    public bool IsOptional { get; set; }

    public long? ExCountryConstrainTreatmentId { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ExCountryConstrainTreatment? ExCountryConstrainTreatment { get; set; }

    public virtual TreatmentMethod? TreatmentMethods { get; set; }
}
