using System.Globalization;

namespace ISCC.Shared.Web;

/// <summary>
/// Bilingual strings used by the shared views.
/// </summary>
/// <remarks>
/// <para>
/// These live here rather than inline in the <c>.cshtml</c> because Arabic does not
/// survive reliably through editing tooling. Anything longer than a word should go into
/// a <c>.resx</c> under <c>ISCC.Shared.Localization</c> and be resolved through
/// <c>IStringLocalizer</c>. This type exists only for the handful of placeholder strings
/// in the shared skeleton views, where a resource lookup would be overkill and the strings
/// have no runtime dependencies.
/// </para>
/// </remarks>
public static class ViewText
{
    /// <summary>Name shown in the header and page title.</summary>
    public static string PortalName(CultureInfo culture) =>
        IsArabic(culture) ? "بوابة الهيئة" : "ISCC Portal";

    /// <summary>Shown on the placeholder landing page.</summary>
    public static string NoPagesMigratedYet(CultureInfo culture) =>
        IsArabic(culture) ? "لم يتم نقل أي صفحات بعد." : "No pages have been migrated yet.";

    /// <summary>
    /// Heading on the shared error page, chosen to match what actually went wrong.
    /// </summary>
    /// <param name="culture">The request culture.</param>
    /// <param name="statusCode">
    /// The status the request failed with. Anything outside 400-499 is treated as a
    /// server fault, including 0 when the page was opened directly.
    /// </param>
    /// <remarks>
    /// A single generic "something went wrong" for every status is actively unhelpful for
    /// the client-error cases: it tells a user who mistyped a URL that we logged an
    /// incident and asks them to retry, when nothing was logged and retrying cannot help.
    /// </remarks>
    public static string ErrorHeading(CultureInfo culture, int statusCode) => statusCode switch
    {
        404 => IsArabic(culture) ? "الصفحة غير موجودة" : "Page not found",
        403 => IsArabic(culture) ? "ليس لديك صلاحية الوصول" : "Access denied",
        401 => IsArabic(culture) ? "يجب تسجيل الدخول" : "Please sign in",
        _ => IsArabic(culture) ? "حدث خطأ" : "Something went wrong"
    };

    /// <summary>
    /// Body copy on the shared error page, chosen to match the status.
    /// </summary>
    /// <param name="culture">The request culture.</param>
    /// <param name="statusCode">The status the request failed with.</param>
    /// <remarks>
    /// The trace id is only offered where a log entry actually exists. Showing a
    /// reference number for a 404 sends support looking for a row that was never written.
    /// </remarks>
    public static string ErrorBody(CultureInfo culture, int statusCode) => statusCode switch
    {
        404 => IsArabic(culture)
            ? "الرابط الذي طلبته غير صحيح أو تم نقل الصفحة."
            : "The address you asked for does not exist, or the page has moved.",
        403 => IsArabic(culture)
            ? "ليس لديك صلاحية للوصول إلى هذه الصفحة."
            : "You do not have permission to view this page.",
        401 => IsArabic(culture)
            ? "يرجى تسجيل الدخول للمتابعة."
            : "Please sign in to continue.",
        _ => IsArabic(culture)
            ? "تم تسجيل المشكلة وسيتم التعامل معها. يرجى المحاولة مرة أخرى لاحقاً."
            : "The problem has been logged. Please try again later."
    };

    /// <summary>
    /// Whether a trace id is worth showing for this status.
    /// </summary>
    /// <param name="statusCode">The status the request failed with.</param>
    /// <returns>True for statuses that produce a log entry.</returns>
    public static bool ShouldShowTraceId(int statusCode) => statusCode is < 400 or >= 500;

    /// <summary>Label preceding the trace id on the error page.</summary>
    public static string ErrorReferenceLabel(CultureInfo culture) =>
        IsArabic(culture) ? "رقم التتبع:" : "Reference:";

    /// <summary>Default table empty state.</summary>
    public static string NoRecords(CultureInfo culture) =>
        IsArabic(culture) ? "لا توجد سجلات" : "No records";

    /// <summary>Pager previous link.</summary>
    public static string Previous(CultureInfo culture) =>
        IsArabic(culture) ? "السابق" : "Previous";

    /// <summary>Pager next link.</summary>
    public static string Next(CultureInfo culture) =>
        IsArabic(culture) ? "التالي" : "Next";

    private static bool IsArabic(CultureInfo culture) =>
        culture.TwoLetterISOLanguageName.StartsWith("ar", StringComparison.OrdinalIgnoreCase);
}
