namespace ISCC.Application.TradeProcedures.Dtos;

/// <summary>
/// One export requirement row — the output of the 4-table join across
/// <c>Ex_CountryConstrains</c>, <c>Countries</c>, <c>Ex_CountryConstrain_Texts</c>
/// and <c>EX_Constrain_Texts</c>.
/// </summary>
public class ExportConstraintDto
{
    public string? CountryName { get; set; }

    /// <summary>The parent item's Arabic name (<c>Item_ShortName.Item.Name_Ar</c>).</summary>
    public string? ItemName { get; set; }

    public string? ShortNameAr { get; set; }
    public long? ItemId { get; set; }

    public string? ConstrainTextAr { get; set; }
    public string? ConstrainTextEn { get; set; }
    public string? InSideCertificateAr { get; set; }
    public string? InSideCertificateEn { get; set; }
}
