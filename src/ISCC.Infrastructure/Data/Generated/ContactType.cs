using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// نوع بيان الاتصال
/// </summary>
public partial class ContactType
{
    public byte Id { get; set; }

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    public string? NameAr { get; set; }

    /// <summary>
    /// الاسم بالانجليزية
    /// </summary>
    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public virtual ICollection<ExContactDatum> ExContactData { get; set; } = new List<ExContactDatum>();

    public virtual ICollection<HagrContact> HagrContacts { get; set; } = new List<HagrContact>();

    public virtual ICollection<StationContact> StationContacts { get; set; } = new List<StationContact>();
}
