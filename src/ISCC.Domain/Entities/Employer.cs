namespace ISCC.Domain.Entities;

public class Employer : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string CommercialRegistration { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public User? User { get; set; }
}
