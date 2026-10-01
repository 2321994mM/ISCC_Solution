using ISCC.Application.Menu.Dtos;

namespace ISCC.Shared.Web.Components;

/// <summary>
/// The view model for <c>Views/Shared/Components/Menu/Default.cshtml</c>.
/// </summary>
/// <remarks>
/// Deliberately not <c>MenuNode</c> from the application layer. That type carries the
/// privilege flags for future per-feature authorization; this one carries presentation
/// concerns the application layer has no concept of, such as whether a route has been ported
/// yet. Passing the domain shape straight through would couple the navigation markup to the
/// RBAC schema and make every rendering change a change to the menu contract.
/// </remarks>
public class MenuViewModel
{
    /// <summary>The tree, top-level groups first.</summary>
    public IReadOnlyList<MenuItem> Items { get; set; } = Array.Empty<MenuItem>();
}