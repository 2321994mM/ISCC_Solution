using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImChooseConstrain
{
    public long Id { get; set; }

    public byte? ImConstrainTypeId { get; set; }

    public long? ImConstrainsSpecialId { get; set; }

    public long? ImConstrainInitiatorTextId { get; set; }

    public virtual ImConstrainInitiatorText? ImConstrainInitiatorText { get; set; }

    public virtual ImConstrainType? ImConstrainType { get; set; }

    public virtual ImConstrainsSpecial? ImConstrainsSpecial { get; set; }
}
