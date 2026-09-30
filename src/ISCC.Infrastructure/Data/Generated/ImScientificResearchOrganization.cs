using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// الجهة المقدمة للطلب
/// </summary>
public partial class ImScientificResearchOrganization
{
    public long Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? Email { get; set; }

    public string? AddressEn { get; set; }

    public string? AddressAr { get; set; }

    public string? PhoneNo { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public virtual ICollection<ImScientificResearch> ImScientificResearches { get; set; } = new List<ImScientificResearch>();
}
