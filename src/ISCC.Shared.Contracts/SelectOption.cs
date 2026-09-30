namespace ISCC.Shared.Contracts;

/// <summary>
/// One option in a shared select component. Carries both languages so the component can
/// render without a second round trip to the localizer.
/// </summary>
public class SelectOption
{
    /// <summary>The value submitted with the form.</summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>English display text. Used when the request culture is not Arabic.</summary>
    public string? TextEn { get; set; }

    /// <summary>Arabic display text. Used when the request culture is Arabic.</summary>
    public string? TextAr { get; set; }

    /// <summary>Optional grouping header, also bilingual.</summary>
    public string? GroupEn { get; set; }

    /// <summary>Optional grouping header, also bilingual.</summary>
    public string? GroupAr { get; set; }

    /// <summary>Whether the option cannot be chosen.</summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// Resolves the display text for a culture code, falling back to English and then to
    /// the raw <see cref="Value"/> so an option is never blank.
    /// </summary>
    public string Text(string cultureCode) =>
        cultureCode.StartsWith("ar", StringComparison.OrdinalIgnoreCase)
            ? (TextAr ?? TextEn ?? Value)
            : (TextEn ?? TextAr ?? Value);

    /// <summary>Resolves the group header for a culture code, or null when ungrouped.</summary>
    public string? Group(string cultureCode) =>
        cultureCode.StartsWith("ar", StringComparison.OrdinalIgnoreCase)
            ? (GroupAr ?? GroupEn)
            : (GroupEn ?? GroupAr);

    /// <summary>Convenience factory for an English-only option.</summary>
    public static SelectOption From(string value, string text) => new() { Value = value, TextEn = text, TextAr = text };

    /// <summary>Convenience factory for a bilingual option.</summary>
    public static SelectOption From(string value, string textEn, string textAr) =>
        new() { Value = value, TextEn = textEn, TextAr = textAr };
}
