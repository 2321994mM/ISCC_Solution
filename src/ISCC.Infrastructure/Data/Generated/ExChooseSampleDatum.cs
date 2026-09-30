using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExChooseSampleDatum
{
    public long Id { get; set; }

    public long? ItemShortNameId { get; set; }

    public int? AnalysisLabTypeId { get; set; }

    public long? ExCountryConstrainAnalysisLabTypeId { get; set; }

    public long? ExCheckRequestId { get; set; }

    public virtual AnalysisLabType? AnalysisLabType { get; set; }

    public virtual ExCheckRequest? ExCheckRequest { get; set; }

    public virtual ExCountryConstrainAnalysisLabType? ExCountryConstrainAnalysisLabType { get; set; }

    public virtual ItemShortName? ItemShortName { get; set; }
}
