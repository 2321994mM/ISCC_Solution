using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImConstrainsSpecial
{
    public long Id { get; set; }

    public long? ImPermissionRequestId { get; set; }

    public string? ConstrainTextEn { get; set; }

    public string? ConstrainTextAr { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ImChooseConstrain> ImChooseConstrains { get; set; } = new List<ImChooseConstrain>();
}
