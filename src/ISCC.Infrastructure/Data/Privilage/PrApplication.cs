namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// An application registered for the staff portal, from <c>dbPrivilage.PR_Application</c>.
/// </summary>
/// <remarks>
/// Exists only to reach the category. The legacy group query joined through it purely to
/// filter on <c>PR_ApplicationCategoryId</c>, hardcoded to <c>1</c> at both call sites.
/// The join is preserved because the category is a real dimension of the data, not a
/// per-group constant that could simply be inlined.
/// </remarks>
public class PrApplication
{
    /// <summary>Surrogate key.</summary>
    public int Id { get; set; }

    /// <summary>Application name.</summary>
    public string? ApplicationName { get; set; }

    /// <summary>Free-text description.</summary>
    public string? ApplicationDescription { get; set; }

    /// <summary>
    /// Category this application belongs to. The staff portal filters on <c>1</c>.
    /// </summary>
    public int? PrApplicationCategoryId { get; set; }
}