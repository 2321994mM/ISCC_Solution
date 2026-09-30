namespace ISCC.Application.Cms.Dtos;

/// <summary>Display name of a CMS section, from <c>dbo.Websitetype</c>.</summary>
public class CmsSectionDto
{
    public int Id { get; set; }
    public string? TypeAr { get; set; }
    public string? TypeEn { get; set; }
}