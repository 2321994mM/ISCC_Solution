namespace ISCC.Application.Dashboard.Dtos;

/// <summary>
/// One slice of a dashboard chart: a label and the tonnage behind it.
/// </summary>
/// <remarks>
/// The legacy VMs behind this chart (<c>CountriesVM</c>, <c>CountriesExVM</c>,
/// <c>ProductsVM</c>, <c>ProductsEXVM</c>) were four identical classes. They collapsed
/// into this one. Two of their field names were actively misleading and are corrected
/// here:
/// <list type="bullet">
///   <item><description>
///     <c>Country</c> was used for the product charts too, where it actually held a plant
///     variety (<c>Item_ShortName.ShortName_Ar</c>). Now <see cref="Label"/>.
///   </description></item>
///   <item><description>
///     <c>CountOrders</c> held a tonnage in tonnes — nothing to do with order counts.
///     Now <see cref="TonnageTonnes"/>.
///   </description></item>
/// </list>
/// </remarks>
public class DashboardGroupDto
{
    /// <summary>Country name, or plant variety name, depending on the chart.</summary>
    public string? Label { get; set; }

    /// <summary>Total gross weight for the group, converted from kg to tonnes.</summary>
    public double TonnageTonnes { get; set; }
}