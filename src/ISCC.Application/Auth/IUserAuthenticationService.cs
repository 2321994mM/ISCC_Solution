using ISCC.Application.Auth.Dtos;

namespace ISCC.Application.Auth;

/// <summary>
/// Authenticates a staff account against <c>dbPrivilage</c> and resolves the outlet it
/// belongs to from <c>PlantQuarantine_New</c>.
/// </summary>
public interface IUserAuthenticationService
{
    /// <summary>
    /// Validates a login name and password.
    /// </summary>
    /// <remarks>
    /// Returns null for both "no such login" and "wrong password". The two are
    /// indistinguishable to the caller by design, so the login page cannot be used to
    /// enumerate valid usernames.
    /// </remarks>
    /// <param name="loginName">Login name as typed. Trimmed before matching.</param>
    /// <param name="password">Password as typed.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The account, or null when the credentials do not match.</returns>
    Task<AuthenticatedUser?> ValidateCredentialsAsync(
        string loginName, string password, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets a new password and marks the account as having completed its first change.
    /// </summary>
    /// <remarks>
    /// The only write path in the auth service, and the reason it exists separately from
    /// <see cref="ValidateCredentialsAsync"/>: changing a password must not be reachable
    /// by supplying the new value alone.
    /// </remarks>
    /// <param name="userId">The <c>PR_User.Id</c> of the account to change.</param>
    /// <param name="newPassword">The new password, stored as given.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True when the account was found and updated.</returns>
    Task<bool> ChangePasswordAsync(
        short userId, string newPassword, CancellationToken cancellationToken = default);
}
