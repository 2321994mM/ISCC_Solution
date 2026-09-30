using ISCC.Domain.Entities;

namespace ISCC.Domain.Interfaces;

public interface IAuthService
{
    Task<User?> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<Session> CreateSessionAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> ValidateSessionAsync(string sessionToken, CancellationToken cancellationToken = default);
}
