using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImConstrainInitiatorText
{
    public long Id { get; set; }

    public long? ConstrainTextId { get; set; }

    public long? ImInitiatorId { get; set; }

    public bool IsActive { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool IsActive1 { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public byte? GroupId { get; set; }

    public virtual ImCountryConstrainText? ConstrainText { get; set; }

    public virtual ICollection<ImChooseConstrain> ImChooseConstrains { get; set; } = new List<ImChooseConstrain>();

    public virtual ImInitiator? ImInitiator { get; set; }
}
