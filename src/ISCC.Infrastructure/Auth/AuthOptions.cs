using ISCC.Application.Auth;
using ISCC.Application.Auth.Dtos;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Infrastructure.Data.Privilage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ISCC.Infrastructure.Auth;

/// <summary>
/// Authentication settings, bound from the <c>Auth</c> configuration section.
/// </summary>
public class AuthOptions
{
    /// <summary>Configuration section name.</summary>
    public const string SectionName = "Auth";

    /// <summary>
    /// Whether login is refused until <c>IS_Change_Password</c> is set.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Defaults to false, and that is a deliberate decision, not an oversight.</b>
    /// </para>
    /// <para>
    /// The two legacy sources disagree. <c>PlantQuar.BLL</c>'s <c>IsUserlogin12</c> has
    /// two branches — <c>IS_Change_Password == true</c> and the else — and
    /// <b>both return 2</b>, so the gate does nothing and every account can log in. That
    /// is the behaviour of the system in production today.
    /// </para>
    /// <para>
    /// The <c>net9.0</c> prototype, <c>PlantQuarantine.NewMvc</c>, reads the flag and
    /// blocks login when it is not set. But the flag is set for only <b>458 of 998</b>
    /// live accounts (492 NULL, 48 zero), and the prototype ships no change-password
    /// screen. Turning the gate on would lock out <b>540 staff accounts with no way back
    /// in</b>.
    /// </para>
    /// <para>
    /// So the default reproduces production, and setting this to true becomes a
    /// configuration change rather than a code change once the change-password screen is
    /// ported. Do not set it to true before then.
    /// </para>
    /// </remarks>
    public bool RequirePasswordChange { get; set; }

    /// <summary>Cookie lifetime in hours when the user does not tick "remember me".</summary>
    public int SessionHours { get; set; } = 8;

    /// <summary>
    /// Cookie lifetime in hours when the user does tick "remember me". Legacy used 24.
    /// </summary>
    public int RememberMeHours { get; set; } = 24;
}
