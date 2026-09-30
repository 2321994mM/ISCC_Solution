using ISCC.Domain.Entities;
using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ISCC.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly ISCCDbContext _context;

    public AuthService(ISCCDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive, cancellationToken);

        if (user == null)
            return null;

        var passwordHash = HashPassword(password);
        if (user.PasswordHash != passwordHash)
            return null;

        return user;
    }

    public async Task<Session> CreateSessionAsync(User user, CancellationToken cancellationToken = default)
    {
        var session = new Session
        {
            UserId = user.Id,
            SessionToken = GenerateSessionToken(),
            ExpiresAt = DateTime.UtcNow.AddHours(8),
            IsActive = true
        };

        await _context.Sessions.AddAsync(session, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return session;
    }

    public async Task<bool> ValidateSessionAsync(string sessionToken, CancellationToken cancellationToken = default)
    {
        var session = await _context.Sessions
            .FirstOrDefaultAsync(s => s.SessionToken == sessionToken && s.IsActive, cancellationToken);

        if (session == null)
            return false;

        if (session.ExpiresAt < DateTime.UtcNow)
        {
            session.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);
            return false;
        }

        return true;
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private static string GenerateSessionToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray()) +
               Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
