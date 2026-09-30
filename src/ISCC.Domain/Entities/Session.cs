namespace ISCC.Domain.Entities;

public class Session : BaseEntity
{
    public string SessionToken { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsActive { get; set; } = true;
}
