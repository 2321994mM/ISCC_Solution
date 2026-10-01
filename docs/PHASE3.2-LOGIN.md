# Phase 3.2 — Sign-in for the employers/staff portal

Ports the legacy login into `ISCC.Api.Application` and puts authorization in front of
every endpoint. Live DB was read only; nothing was written.

## The area question

**Areas are not legacy structure.** Both legacy apps use them, including the `net9.0`
prototype:

- `PlantQuar.WEB` (4.8) — `Areas/Employee/`, `Areas/EX_User/`, `Areas/Import/`
- `PlantQuarantine.NewMvc` (net9.0) — `Areas/Import/{Controllers,Data,Models,Views}`

They are an unchanged ASP.NET Core feature. But an Area is only a **host-level routing and
view-location** concern — "what URL, and where do the `.cshtml` files live". It does not
replace the Clean Architecture layers, and business logic in an Area folder would be wrong.

**Sign-in gets no Area.** Three reasons: it is cross-cutting rather than a business area;
`/Account/Login` is load-bearing (it is the cookie `LoginPath`, the prototype's route, and
bookmarked by staff); and an `Account` area would yield `/Account/Account/Login` unless
specially configured. Business areas — Import, Farm, Export, Committee, Station — start at
Phase 3.3.

```
ISCC.Application/Auth/                          contract + Dtos
ISCC.Infrastructure/Auth/                        EF implementation
src/Host/ISCC.Api.Application/
  Controllers/AccountController.cs               route /Account/Login, no area
  Models/LoginViewModel.cs
  Views/Account/Login.cshtml
```

## What the scan found

`PlantQuarantine.NewMvc` (net9.0) already contained a working login: claims principal,
8h/24h cookie split, `IS_Change_Password` gate. Ported rather than written fresh.

Two blockers found while scanning, both resolved:

- `PrivilageDbContext` **existed but was never registered in DI.** Its own XML comment
  claimed DI wiring. Any service taking it would have failed at startup. Now registered.
- `UseAuthentication()` was **missing from the pipeline** entirely — `UseAuthorization()`
  was there alone. `[Authorize]` does not authenticate; the symptom would be a redirect
  loop on every protected page.

## The password gate — deferred, defaulting to inert

`IS_Change_Password` on `dbPrivilage.PR_User`:

| value | accounts |
|---|---|
| `1` | 458 |
| `NULL` | 492 |
| `0` | 48 |

**The two legacy sources disagree.**

`PlantQuar.BLL`'s `IsUserlogin12` has two branches and **both return `2`** — the gate does
nothing. That is production behaviour today: everyone can log in.

`PlantQuarantine.NewMvc` reads the flag and blocks when it is not set. But it ships **no
change-password screen**, so enforcing it would lock out **540 of 998 staff accounts with
no way back in**.

Decision deferred by request. Implemented as `Auth:RequirePasswordChange`, **default
false**, so flipping it later is a settings change rather than a code change. Do not set it
true before porting the change-password flow.

Verified both ways. Default off: `=1`, `=0` and `NULL` accounts all authenticate. Flag on:
`=0` and `NULL` are refused and logged as
`Sign-in refused: account 17 has not completed its password change.`

## Behaviour changes from the prototype

1. **`Active` is now filtered.** The prototype's hand-written SQL did not filter it, so a
   deactivated account could still sign in. All 998 live rows are `Active = 1`, so this
   changes nothing today.
2. **`Language` / `LanguageIsAr` come from the request culture.** The prototype hardcoded
   `ar-Eg` / `1` on every sign-in, pinning every user to Arabic. It also read only
   `Outlet.Ar_Name` and `A_SystemCode.ValueName` for the outlet and outlet-type claims, so
   an English user saw Arabic outlet names inside an English page. Both names are now
   loaded.
3. **`[Display]`/`[ErrorMessage]` attributes do not localize.** `asp-for` writes
   `DisplayAttribute.Name` into the `<label>` as literal text, and `asp-validation-for`
   does the same with `ErrorMessage`; neither routes through `IStringLocalizer`. Keys
   there render as the key — the first build showed a label reading `Login_Username`.
   Localization moved to the view.

Also added, not ported: `ReturnUrl` is re-validated with `Url.IsLocalUrl` (otherwise
`?returnUrl=https://evil.example` turns a successful sign-in into an off-site redirect),
one generic message for wrong-password and unknown-user so the form cannot enumerate
accounts, no password claim, and the password input is never re-rendered.

## Authorization is now secure by default

Set as a **fallback policy**, not per-controller decoration:

```csharp
options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
```

Forgetting `[Authorize]` is silent; the fallback is not.

**This changes Phase 3.1.** Its three reference-data endpoints were verified
unauthenticated and now return `401`. That is the correct posture for a staff portal —
importers, outlets and quarantine statuses are internal lookups the legacy MVC app only
ever served inside a session. Worth noting the legacy solution had just 6 `[Authorize]`
across 587 controllers, so "public by default" was its de facto rule; that rule is what
this replaces.

`[Authorize]` was also removed from `Logout` — the class-level `[AllowAnonymous]` overrode
it, so it looked like protection while doing nothing.

## Verification

22 assertions against the live DB, all passing.

| Check | Result |
|---|---|
| Unauthenticated API access (4 endpoints) | `401` + JSON `UNAUTHENTICATED`, not a 302 to HTML |
| Anonymous `/` | redirects to `/Account/Login` |
| Anonymous `/Account/Login` | `200`, no redirect loop |
| `IS_Change_Password` = 1 / 0 / NULL | all allowed (gate inert by default) |
| Wrong password | rejected, generic message |
| Unknown user | rejected, identical message |
| Blank fields | rejected |
| Login name padded with spaces | accepted (trimmed) |
| Password echoed into HTML on failure | no |
| Culture survives a rejected POST | yes |
| Remember-me cookie | persistent |
| Authenticated `GET /api/reference-data/importers` | `200`, Phase 3.1 envelope intact |
| Authenticated `GET /` | `200`, no bounce to login |
| Cookie after logout | `401` |
| External `returnUrl` (4 variants incl. `//host`) | dropped |
| Local `returnUrl` | kept |
| Arabic page | `dir=rtl`, Arabic script, zero English leakage in visible text |
| English page | `ltr`, zero Arabic leakage, zero raw localization keys |

### Live DB after the work — unchanged

`PlantQuarantine_New`: 298 tables, 15,328 error rows, 321,469 `Im_CheckRequest`, 0
`HangFire` tables, 3 indexes on `Im_CheckRequest_Data`.
`dbPrivilage`: 998 `PR_User`, all active, flag split 458 / 48 / 492, test accounts'
passwords and `LastLoginDate` untouched.

> **For the data owner:** `Im_CheckRequest_Data` read 321,464 at the end of this phase but
> 321,549 earlier in the session, while `Im_CheckRequest` matched exactly at 321,469
> throughout. The auth service issues two SELECTs and no writes, and no account's
> `LastLoginDate` moved, so this is the live application rather than this work — but 85 rows
> is worth confirming.

## Two traps worth recording

**Substring assertions hide label bugs.** Testing the page with `-match 'Username'` passes
when the label reads `Login_Username`. Every assertion here extracts text from a specific
element and compares exactly.

**Arabic needs two corrections before it can be asserted on.** Razor HTML-encodes non-ASCII,
so Arabic arrives as `&#x627;` and a script-range regex finds nothing — decode entities
first. And `Invoke-WebRequest` ignores `<meta charset="utf-8">` and decodes as Latin-1, so
it must be replaced with a `WebClient` whose `Encoding` is UTF-8, and HTML tags stripped
before comparing, or `id="UserName"` and `asp-action="Login"` match the English words
being searched for.

Separately: Serilog rolled `employers-20261001_001.log` while an earlier process held the
original open, so several "no log line" readings were of the stale file. Always check for a
rolled file before concluding nothing was logged.

## Still outstanding

- **Change-password screen** is the prerequisite for `RequirePasswordChange: true`. The
  contract has `ChangePasswordAsync`; nothing calls it yet.
- The legacy 4.8 change-password posts the password in a **URL query string**, leaking it
  into IIS and proxy logs. Per decision, port the flow with the credential in the body.
- **Passwords are still plaintext** in `PR_User`, as agreed. `AuthenticatedUser` carries no
  password and `PrUser.PlaintextPassword` forces a rename if hashing is ever introduced.
- **RBAC still enforces nothing.** All 134 `PR_UserGroup` rows have NULL CRUD flags and all
  8,418 `PR_GroupModuleMenuPrivilage` rows have every flag `= 1`, so "in a group means you
  can do everything". Authenticate-only matches the legacy `Session["UserId"]` check;
  enforcing permissions is a behaviour change, not a port.
- **Repo is still public and the SQL password is still live** in history. Rotate `new` and
  set the repo to Private.