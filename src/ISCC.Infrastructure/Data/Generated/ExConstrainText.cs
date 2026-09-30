using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExConstrainText
{
    public long Id { get; set; }

    public byte ExConstrainCountryItemId { get; set; }

    public string? ConstrainTextAr { get; set; }

    public string? ConstrainTextEn { get; set; }

    public string? InSideCertificateAr { get; set; }

    public string? InSideCertificateEn { get; set; }

    /// <summary>
    /// شهادة الصحة النباتية
    /// </summary>
    public bool IsCertificateAddtion { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ExConstrainCountryItem ExConstrainCountryItem { get; set; } = null!;

    public virtual ICollection<ExCountryConstrainText> ExCountryConstrainTexts { get; set; } = new List<ExCountryConstrainText>();
}
