using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// ثابت - معالجة - نبات - نوباتجية - سحب
/// 
/// </summary>
public partial class FeesType
{
    public byte Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool IsActive { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public int AccountType { get; set; }

    public string? FullName { get; set; }

    public decimal? Price { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual ICollection<FeesAction> FeesActions { get; set; } = new List<FeesAction>();

    public virtual ICollection<FeesAltahsilDetile> FeesAltahsilDetiles { get; set; } = new List<FeesAltahsilDetile>();

    public virtual ICollection<FeesAmountFixed> FeesAmountFixeds { get; set; } = new List<FeesAmountFixed>();
}
