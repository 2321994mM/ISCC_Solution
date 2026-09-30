namespace ISCC.Domain.Entities;

public class Inspection : BaseEntity
{
    public string InspectionNumber { get; set; } = string.Empty;
    public DateTime InspectionDate { get; set; }
    public InspectionStatus Status { get; set; }
    public string? Notes { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public int? EmployerId { get; set; }
    public Employer? Employer { get; set; }
}
