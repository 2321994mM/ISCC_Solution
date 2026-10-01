using System.ComponentModel.DataAnnotations;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// The sign-in form.
/// </summary>
/// <remarks>
/// <para>
/// <b>No <c>[Display]</c> or <c>[ErrorMessage]</c> attributes carrying localization keys.</b>
/// These look like they localize and do not. The <c>asp-for</c> tag helper reads
/// <c>DisplayAttribute.Name</c> and writes it into the <c>&lt;label&gt;</c> as literal text,
/// and <c>asp-validation-for</c> does the same with <c>ErrorMessage</c>. Neither goes
/// through <c>IStringLocalizer</c>, so a key there renders as the key itself — the page
/// showed a label reading "Login_Username". The correct place to localize a label is the
/// view, where the localizer is available; the keys live here only as comments naming which
/// key each field uses.
/// </para>
/// <para>
/// The legacy prototype hardcoded Arabic into this model, so an English user saw Arabic
/// field labels and Arabic validation text. Both are now resolved in the view.
/// </para>
/// </remarks>
public class LoginViewModel
{
    /// <summary>Login name. Label and required message come from keys in the view.</summary>
    [Required]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Password. Never round-tripped back to the form: the view deliberately re-renders it
    /// empty, so a failed sign-in does not echo the submitted password into the HTML and
    /// hence into the browser's back-forward cache and autofill history.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    /// <summary>Whether to issue a persistent cookie. Label comes from the view.</summary>
    public bool RememberMe { get; set; }

    /// <summary>
    /// Where to go after a successful sign-in. Re-validated against
    /// <c>Url.IsLocalUrl</c> by the controller, never trusted as posted.
    /// </summary>
    public string? ReturnUrl { get; set; }
}