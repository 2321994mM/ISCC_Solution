using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ImCountryConstrainText
{
    public long Id { get; set; }

    public string? ConstrainTextAr { get; set; }

    public string? ConstrainTextEn { get; set; }

    public string? InSideCertificateAr { get; set; }

    public string? InSideCertificateEn { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public byte? ImConstrainTypeId { get; set; }

    public virtual ICollection<ImConstrainInitiatorText> ImConstrainInitiatorTexts { get; set; } = new List<ImConstrainInitiatorText>();

    public virtual ImConstrainType? ImConstrainType { get; set; }
}
