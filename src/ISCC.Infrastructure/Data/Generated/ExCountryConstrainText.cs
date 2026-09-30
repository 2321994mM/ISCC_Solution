using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نصوص الاشتراطات
/// </summary>
public partial class ExCountryConstrainText
{
    public long Id { get; set; }

    public long CountryConstrainId { get; set; }

    public long? ExConstrainTextId { get; set; }

    public bool? IsAcceppted { get; set; }

    public bool IsActive { get; set; }

    public long UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public long? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? ParentId { get; set; }

    public virtual ExCountryConstrain CountryConstrain { get; set; } = null!;

    public virtual ExConstrainText? ExConstrainText { get; set; }
}
