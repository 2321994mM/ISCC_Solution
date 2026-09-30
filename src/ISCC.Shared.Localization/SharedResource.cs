namespace ISCC.Shared.Localization;

/// <summary>
/// Marker type used to resolve localized strings from this shared resource assembly.
/// </summary>
/// <remarks>
/// Inject as <c>IStringLocalizer&lt;SharedResource&gt;</c> to get strings out of
/// <c>Resources/Resource.resx</c> (neutral / English) and <c>Resource.&lt;culture&gt;.resx</c>
/// (e.g. Arabic). The type never gets instantiated.
/// </remarks>
public sealed class SharedResource
{
}
