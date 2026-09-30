using ISCC.Domain.Enums;

namespace ISCC.Domain.Entities;

public class Payment : BaseEntity
{
    public string PaymentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string? Description { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public int? EmployerId { get; set; }
    public Employer? Employer { get; set; }
}
