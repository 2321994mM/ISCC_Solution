using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المخازن
/// </summary>
public partial class ImStore
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// مخزن/ساحة
    /// </summary>
    public string? Place { get; set; }

    public string? StoreOwner { get; set; }

    public decimal? Phone { get; set; }

    public decimal? Fax { get; set; }

    public string? Email { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }
}
