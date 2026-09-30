namespace ISCC.Application.TradeProcedures.Dtos;

/// <summary>A plant variety entry for the second cascading drop-down.</summary>
public class ItemOptionDto
{
    public long Id { get; set; }

    /// <summary>
    /// Display label. Import composes it as <c>Item.Name_Ar + "/" + ShortName_Ar</c>;
    /// export uses <c>ShortName_Ar</c> alone. That difference is deliberate and
    /// preserved — see <c>TradeProcedureService</c>.
    /// </summary>
    public string? NameAr { get; set; }

    public string? NameEn { get; set; }
}
