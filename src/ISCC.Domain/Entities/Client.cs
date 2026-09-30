namespace ISCC.Domain.Entities;

public class Client : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public User? User { get; set; }
}
