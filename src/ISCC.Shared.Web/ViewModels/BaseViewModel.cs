namespace ISCC.Shared.Web;

/// <summary>
/// Base class for view models that carry bilingual text.
/// </summary>
/// <remarks>
/// Lives in a shared project so every portal's view models inherit the same shape. The
/// legacy solution had no such base; each portal re-declared the same properties.
/// </remarks>
public abstract class BaseViewModel
{
    /// <summary>English title.</summary>
    public string? TitleEn { get; set; }

    /// <summary>Arabic title.</summary>
    public string? TitleAr { get; set; }
}

/// <summary>
/// View model for the shared error page.
/// </summary>
public class ErrorViewModel : BaseViewModel
{
    /// <summary>Correlation id, shown to the user so support can find the log entry.</summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// The status the request failed with, so the page can say something true.
    /// </summary>
    /// <remarks>
    /// Needed because the same view serves a genuine fault and a 404. Telling someone a
    /// missing page "has been logged and please try again later" is wrong in a way that
    /// costs real time: nothing was logged, and retrying will not help. 0 means the page
    /// was opened directly rather than reached by a failure.
    /// </remarks>
    public int StatusCode { get; set; }

    /// <summary>Whether there is a trace id worth displaying.</summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
