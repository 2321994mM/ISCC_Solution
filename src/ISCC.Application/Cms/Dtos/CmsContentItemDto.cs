namespace ISCC.Application.Cms.Dtos;

/// <summary>
/// A single CMS content row from <c>dbo.WebsitetypeDetail</c>, projected for display.
/// </summary>
public class CmsContentItemDto
{
    public int Id { get; set; }
    public int SectionId { get; set; }

    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }

    public string? DescAr { get; set; }
    public string? DescEn { get; set; }

    public string? FilePath { get; set; }
    public string? LinkUrl { get; set; }

    public DateTime? Date { get; set; }
    public DateTime? UserCreationDate { get; set; }
}