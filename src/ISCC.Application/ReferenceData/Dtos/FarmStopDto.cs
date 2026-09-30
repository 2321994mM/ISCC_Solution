namespace ISCC.Application.ReferenceData.Dtos;

/// <summary>
/// A suspended-farm record from <c>dbo.FarmStop</c>.
/// </summary>
/// <remarks>
/// <c>StopDate</c> and <c>Previewdate</c> are <c>varchar</c> in the database, not date
/// types — see <c>FarmStop</c> in the scaffolded model. They are passed through as
/// strings exactly as the legacy controller did.
/// </remarks>
public class FarmStopDto
{
    public long Id { get; set; }
    public string? Farmcode { get; set; }
    public string? Farmname { get; set; }
    public string? Compname { get; set; }
    public string? Cropname { get; set; }
    public string? StopDate { get; set; }
    public string? Previewdate { get; set; }
    public string? Text104 { get; set; }
}