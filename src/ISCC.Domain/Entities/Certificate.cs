namespace ISCC.Domain.Entities;

public class Certificate : BaseEntity
{
    public string CertificateNumber { get; set; } = string.Empty;
    public CertificateType Type { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public int? EmployerId { get; set; }
    public Employer? Employer { get; set; }
}
