namespace ISCC.Application.Dashboard.Dtos;

/// <summary>Everything the public statistics dashboard renders.</summary>
/// <remarks>
/// The legacy action passed three of these values (<c>People</c>, <c>Public_Organizations</c>,
/// <c>Company_Nationals</c>) plus the reporting year through <c>ViewBag</c> while passing the
/// four chart series through a model. They are unified here so the view has a single,
/// discoverable contract.
/// </remarks>
public class DashboardDto
{
    /// <summary>The reporting year the figures were filtered to.</summary>
    public int Year { get; set; }

    public int PeopleCount { get; set; }

    public int PublicOrganizationCount { get; set; }

    public int CompanyNationalCount { get; set; }

    /// <summary>Top 5 origin countries by inbound (import) tonnage.</summary>
    public List<DashboardGroupDto> ImportCountries { get; set; } = new();

    /// <summary>Top 5 destination countries by outbound (export) tonnage.</summary>
    public List<DashboardGroupDto> ExportCountries { get; set; } = new();

    /// <summary>Top 4 plant varieties by inbound tonnage.</summary>
    public List<DashboardGroupDto> ImportProducts { get; set; } = new();

    /// <summary>Top 4 plant varieties by outbound tonnage.</summary>
    public List<DashboardGroupDto> ExportProducts { get; set; } = new();
}