namespace ISCC.Application.TradeProcedures.Dtos;

/// <summary>
/// One import requirement row — the output of the 4-table join across
/// <c>Im_Initiators</c>, <c>Countries</c>, <c>Im_Constrain_Initiator_Texts</c>
/// and <c>Im_CountryConstrain_Texts</c>.
/// </summary>
public class ImportConstraintDto
{
    /// <summary>Legacy set this to the <c>Im_Initiator.ID</c>, despite the name.</summary>
    public long InitiatorRowId { get; set; }

    public string? InitiatorNameAr { get; set; }
    public string? InitiatorNameEn { get; set; }

    /// <summary>The parent item's Arabic name (<c>Item_ShortName.Item.Name_Ar</c>).</summary>
    public string? ItemName { get; set; }

    public string? ShortNameAr { get; set; }

    public long? CountryId { get; set; }
    public long? ItemShortNameId { get; set; }
    public long? ItemId { get; set; }

    public string? ConstrainTextAr { get; set; }
    public string? ConstrainTextEn { get; set; }
    public string? InSideCertificateAr { get; set; }
    public string? InSideCertificateEn { get; set; }
}
