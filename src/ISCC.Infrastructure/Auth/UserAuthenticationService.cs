using ISCC.Application.Auth;
using ISCC.Application.Auth.Dtos;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Privilage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ISCC.Infrastructure.Auth;

/// <summary>
/// EF Core implementation of <see cref="IUserAuthenticationService"/>, spanning both
/// databases.
/// </summary>
/// <remarks>
/// <para>
/// The account lives in <c>dbPrivilage</c> and the outlet in
/// <c>PlantQuarantine_New</c>, so this is the one place the two contexts meet. EF cannot
/// join across them, so the outlet is a second query. That is a property of the data
/// layout, not a shortcut, and it is why <see cref="PrivilageDbContext"/> exists as a
/// separate context rather than as more <c>DbSet</c>s.
/// </para>
/// <para>
/// Replaces the raw <c>SqlConnection</c>/<c>SqlCommand</c> of
/// <c>PlantQuarantine.NewMvc</c>'s <c>UserAuthenticationService</c>, which issued the
/// same two queries by hand.
/// </para>
/// </remarks>
public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly PrivilageDbContext _privilage;
    private readonly PlantQuarantineDbContext _plant;
    private readonly AuthOptions _options;
    private readonly ILogger<UserAuthenticationService> _logger;

    public UserAuthenticationService(
        PrivilageDbContext privilage,
        PlantQuarantineDbContext plant,
        IOptions<AuthOptions> options,
        ILogger<UserAuthenticationService> logger)
    {
        _privilage = privilage;
        _plant = plant;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<AuthenticatedUser?> ValidateCredentialsAsync(
        string loginName, string password, CancellationToken cancellationToken = default)
    {
        var normalizedLogin = (loginName ?? string.Empty).Trim();

        if (normalizedLogin.Length == 0 || string.IsNullOrEmpty(password))
        {
            return null;
        }

        // The password is compared in the WHERE clause, exactly as the legacy code did.
        // PR_User.Password holds plaintext, so this is a plain string equality against a
        // plaintext column. It is not a hashing bug that could be fixed by changing the
        // query: the column contains no hash. Changing this means migrating 998 stored
        // passwords, which is a separate piece of work, not a login port.
        //
        // Active is filtered here. NewMvc's hand-written SQL did NOT filter it, so a
        // deactivated account could still log in through the prototype. All 998 live rows
        // are Active = 1 today, so this changes nothing now and closes the hole later.
        var user = await _privilage.PrUsers
            .Where(u => u.LoginName == normalizedLogin
                     && u.PlaintextPassword == password
                     && u.Active)
            .Select(u => new AuthenticatedUser
            {
                UserId = u.Id,
                LoginName = u.LoginName ?? string.Empty,
                FullNameAr = u.FullName ?? string.Empty,
                FullNameEn = u.FullNameEn ?? string.Empty,
                EmpId = u.EmpId,
                OutletHrId = u.OutletId,
                IsPasswordChanged = u.IsChangePassword == true
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            // Deliberately does not log the attempted login name. At 998 accounts a
            // log line per failed attempt is a credential-stuffing target and a
            // disclosure risk, since the login name is half the credential.
            _logger.LogInformation("Failed sign-in attempt.");
            return null;
        }

        if (_options.RequirePasswordChange && !user.IsPasswordChanged)
        {
            _logger.LogInformation(
                "Sign-in refused: account {UserId} has not completed its password change.",
                user.UserId);
            return null;
        }

        if (user.OutletHrId.HasValue)
        {
            await PopulateOutletAsync(user, cancellationToken);
        }

        return user;
    }

    public async Task<bool> ChangePasswordAsync(
        short userId, string newPassword, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(newPassword))
        {
            return false;
        }

        var account = await _privilage.PrUsers
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (account is null)
        {
            return false;
        }

        account.PlaintextPassword = newPassword;
        account.IsChangePassword = true;
        account.LastLoginDate = DateOnly.FromDateTime(DateTime.Now);

        return await _privilage.SaveChangesAsync(cancellationToken) > 0;
    }

    /// <summary>
    /// Resolves the outlet from its HR id and attaches its names and type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>PR_User.Outlet_ID</c> holds <c>Outlet.ID_HR</c>, not <c>Outlet.ID</c>. The two
    /// are different columns and the business tables use <c>Outlet.ID</c>, so getting the
    /// join wrong returns a plausible-looking wrong outlet instead of failing.
    /// </para>
    /// <para>
    /// Both names are loaded. The legacy query took only <c>Ar_Name</c> and only
    /// <c>sc.ValueName</c>, so an English user was shown Arabic outlet and outlet-type
    /// names inside an English page.
    /// </para>
    /// <para>
    /// <c>Outlet.IsExport</c> is an <c>A_SystemCode</c> id — 1 Local, 81 Import, 82 All —
    /// not a boolean despite the name. <c>A_SystemCode.Id</c> is unique across all 115
    /// rows, so this is a plain many-to-one lookup; the legacy LEFT JOIN was an inner join
    /// in effect.
    /// </para>
    /// </remarks>
    private async Task PopulateOutletAsync(AuthenticatedUser user, CancellationToken cancellationToken)
    {
        // Left join written out rather than navigated: there is no foreign key between
        // Outlet.IsExport and A_SystemCode.Id, so EF has no navigation to follow and no
        // relationship to infer one from. Left, not inner, so an outlet with an unmapped
        // type code still returns its name.
        var outlet = await (
            from o in _plant.Outlets
            join sc in _plant.ASystemCodes on o.IsExport equals sc.Id into typeCodes
            from sc in typeCodes.DefaultIfEmpty()
            where o.IdHr == user.OutletHrId
            select new
            {
                o.Id,
                o.ArName,
                o.EnName,
                o.IsExport,
                TypeAr = sc == null ? null : sc.ValueName,
                TypeEn = sc == null ? null : sc.ValueNameEn
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (outlet is null)
        {
            // Not fatal. A user with an Outlet_ID that no longer resolves still signs in;
            // the outlet simply stays empty and screens that need it will show no data.
            // Failing the login instead would lock out a valid account over a stale
            // foreign key, which is a worse outcome than a degraded page.
            _logger.LogWarning(
                "Outlet {OutletHrId} referenced by user {UserId} does not exist.",
                user.OutletHrId, user.UserId);
            return;
        }

        user.OutletId = outlet.Id;
        user.OutletNameAr = outlet.ArName ?? string.Empty;
        user.OutletNameEn = outlet.EnName ?? string.Empty;
        user.OutletTypeId = outlet.IsExport;
        user.OutletTypeAr = outlet.TypeAr ?? string.Empty;
        user.OutletTypeEn = outlet.TypeEn ?? string.Empty;
    }
}
