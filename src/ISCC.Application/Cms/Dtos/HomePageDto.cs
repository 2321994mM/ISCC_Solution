namespace ISCC.Application.Cms.Dtos;

/// <summary>
/// Everything <c>HomeController.Index</c> renders, gathered in one round trip of the
/// service rather than five separate queries inside a controller action.
/// </summary>
public class HomePageDto
{
    /// <summary>Section 9 — hero slider images.</summary>
    public List<CmsContentItemDto> Slider { get; set; } = new();

    /// <summary>Section 11 — ministry introduction, newest only (legacy took 1).</summary>
    public List<CmsContentItemDto> Intro { get; set; } = new();

    /// <summary>Section 7 — news, newest 3 (legacy took 3), descriptions truncated.</summary>
    public List<CmsContentItemDto> News { get; set; } = new();

    /// <summary>Section 8 — advertisements, newest 3 (legacy took 3).</summary>
    public List<CmsContentItemDto> Advertisements { get; set; } = new();

    /// <summary>Section 10 — alerts, all rows, no ordering (legacy behaviour).</summary>
    public List<CmsContentItemDto> Alerts { get; set; } = new();
}