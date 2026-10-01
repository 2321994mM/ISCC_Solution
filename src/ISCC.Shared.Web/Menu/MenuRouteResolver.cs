using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

namespace ISCC.Shared.Web.Menu;

/// <summary>
/// Decides whether a <c>PR_Menu.MenuURL</c> value still resolves to a controller action in
/// this solution, so the navigation can mark links whose owning area has not been ported yet
/// rather than rendering dead anchors.
/// </summary>
/// <remarks>
/// <para>
/// <b>Why this exists.</b> <c>PR_Menu</c> holds 221 free-text routes such as
/// <c>Im_CheckRequests/List_ImCheckRequest/Index</c>, and the legacy views emitted them as
/// <c>href="~/@item.MenuURL"</c> — plain string concatenation, validated neither at build
/// time nor at render time. Only a few of those areas exist here so far, so a faithfully
/// ported menu is mostly links to controllers that have not been migrated, and rendering them
/// as normal anchors produces a menu that looks right and 404s on click.
/// </para>
/// <para>
/// This does not rewrite or drop those links. It classifies them, so the view can render them
/// as visibly inert. That keeps the whole intended menu visible — which is the useful thing
/// to have while porting — while making it obvious which parts are not ready.
/// </para>
/// <para>
/// <b>Not a security control.</b> A route that resolves is still subject to the normal
/// authorization fallback policy, and a route that does not resolve cannot be reached at all.
/// Inert-rendering a link is a navigation affordance; authorization happens on the endpoint.
/// </para>
/// <para>
/// Lives here rather than in <c>ISCC.Infrastructure</c> because it depends on
/// <c>ControllerActionDescriptor</c>, which is an MVC type. Infrastructure has no MVC
/// dependency and must not acquire one.
/// </para>
/// </remarks>
public class MenuRouteResolver
{
    private readonly HashSet<string> _implementedRoutes;

    /// <summary>
    /// Builds the set of implemented routes from the application's endpoint table.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Enumerated once per construction, not per render. Rebuilding a set of every endpoint
    /// on every page view, to answer a question that can only change on redeploy, would be
    /// pure waste. Registered as a singleton for that reason.
    /// </para>
    /// <para>
    /// Two sources are indexed, because one covers only half the cases:
    /// </para>
    /// <list type="number">
    /// <item>
    /// The route template text of each attribute-routed endpoint. A template such as
    /// <c>Im_CheckRequests/List_ImCheckRequest/Index</c> is character-for-character the same
    /// shape as a <c>PR_Menu.MenuURL</c>, so this matches on a direct string comparison.
    /// </item>
    /// <item>
    /// The descriptor's <c>ControllerName</c>/<c>ActionName</c> pair, keyed by area. Needed
    /// because the class name and the route name differ — <c>ListImCheckRequest</c> is
    /// routed as <c>List_ImCheckRequest</c> — and the legacy URLs use both forms depending
    /// on which controller the DBA recorded them against.
    /// </item>
    /// </list>
    /// </remarks>
    /// <param name="endpoints">The application's endpoint data sources.</param>
    public MenuRouteResolver(IEnumerable<EndpointDataSource> endpoints)
    {
        _implementedRoutes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var endpoint in endpoints.SelectMany(source => source.Endpoints))
        {
            if (endpoint.Metadata.GetMetadata<ControllerActionDescriptor>() is not { } action)
            {
                // Static files, health checks, the exception-handler endpoint: none of these
                // can be the target of a PR_Menu value.
                continue;
            }

            var area = ResolveArea(endpoint);

            _implementedRoutes.Add(BuildKey(area, action.ControllerName, action.ActionName));

            // The attribute-routed form, which is what most of the legacy URLs actually look
            // like. Also indexes the [Route(...)]-renamed form of the same action.
            if (endpoint is RouteEndpoint { RoutePattern.RawText: { } template })
            {
                IndexTemplate(template);
            }
        }
    }

    /// <summary>
    /// Classifies a stored menu URL against the implemented routes.
    /// </summary>
    /// <param name="menuUrl">The raw <c>PR_Menu.MenuURL</c> value.</param>
    /// <param name="url">
    /// The value to emit as <c>href</c>, normalised to a single leading slash. Null when
    /// <paramref name="menuUrl"/> is blank.
    /// </param>
    /// <param name="isImplemented">
    /// True when a matching action exists. False means the owning area has not been ported,
    /// so the entry should be inert.
    /// </param>
    public void Resolve(string? menuUrl, out string? url, out bool isImplemented)
    {
        if (string.IsNullOrWhiteSpace(menuUrl))
        {
            url = null;
            isImplemented = false;
            return;
        }

        var segments = menuUrl
            .Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        url = "/" + string.Join('/', segments);

        // Anything that is not exactly area/controller/action cannot be matched. Guessing a
        // shape for it would produce a false "implemented" as often as a false "missing", and
        // a false "implemented" is the worse of the two: it renders a link that 404s.
        if (segments.Length != 3)
        {
            isImplemented = false;
            return;
        }

        var (area, controller, action) = (segments[0], segments[1], segments[2]);

        // Tried with the stored area and with an empty one. The legacy menu contains both
        // forms for the same controller, and a controller that lived in an area there may sit
        // at the root here and vice versa. Matching both keeps that reshuffling from turning
        // every relocated controller into a dead link.
        isImplemented = _implementedRoutes.Contains(BuildKey(area, controller, action))
            || _implementedRoutes.Contains(BuildKey(string.Empty, controller, action));
    }

    /// <summary>
    /// Indexes an attribute-route template as a key, dropping any route parameters.
    /// </summary>
    /// <remarks>
    /// A template of <c>Station/Details/{id}</c> is stored as <c>Station/Details/Index</c> in
    /// PR_Menu, or as <c>Station/Details</c> with the action in the query string. The
    /// parameter slot is stripped so both match the same key.
    /// </remarks>
    /// <param name="template">The raw route template text.</param>
    private void IndexTemplate(string template)
    {
        var parts = template
            .Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(segment => segment.Contains('{', StringComparison.Ordinal) ? null : segment)
            .OfType<string>()
            .ToArray();

        if (parts.Length == 0)
        {
            return;
        }

        // An attribute template with no leading area still counts under both the empty area
        // and the first segment, because the legacy URLs record the area for some controllers
        // and omit it for others.
        _implementedRoutes.Add(string.Join('/', parts));

        if (parts.Length == 3)
        {
            _implementedRoutes.Add(BuildKey(string.Empty, parts[1], parts[2]));
            _implementedRoutes.Add(BuildKey(parts[0], parts[1], parts[2]));
        }
    }

    /// <summary>
    /// Works out the area an endpoint belongs to.
    /// </summary>
    /// <remarks>
    /// Read from the route pattern defaults, which is where MVC puts it for both attribute
    /// and conventional routing. An endpoint with no <c>area</c> default is not in an area.
    /// </remarks>
    /// <param name="endpoint">The endpoint.</param>
    /// <returns>The area name, or empty for a non-area controller.</returns>
    private static string ResolveArea(Endpoint endpoint)
        => endpoint is RouteEndpoint routeEndpoint
           && routeEndpoint.RoutePattern.Defaults.TryGetValue("area", out var areaDefault)
           && areaDefault is string areaName
            ? areaName
            : string.Empty;

    private static string BuildKey(string area, string controller, string action)
        => string.Concat(area, "/", controller, "/", action);
}