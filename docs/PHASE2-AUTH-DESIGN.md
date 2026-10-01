# Phase 2 — Auth Design (from `dbPrivilage`)

Status: **planned**, pending decisions below.

## Legacy reference (canonical)

The `PlantQuarantine.NewMvc` project in `ISCC_PlantQuarantine` implements the real login flow:

- Two connection strings: `Privilege` (database `dbPrivilage`) and `PlantQuarantine` (database `PlantQuarantine_New`)
- Validates against `PR_User` with plaintext comparison:  
  `WHERE LoginName = @LoginName AND Password = @Password`
- Rejects login if `IS_Change_Password` is `false` ("must change password")
- Enriches user with outlet info from `Outlet` (main DB) when `Outlet_ID` (OutletHr) is present
- Issues a Cookie authentication ticket with claims: `NameIdentifier`, `Name`, `LoginName`, `EmpId`, `OutletHr`, `OutletId`, `OutletName`, `OutletNameEn`, `OutletType`, `OutletTypeId`, `Language="ar-Eg"`, `LanguageIsAr="1"`
- Cookie expiry: 24h if RememberMe, else 8h

## Auth tables (dbPrivilage)

Real, populated RBAC model:

- `PR_User` (998 active): `Id` (smallint), `LoginName`, `FullName`/`FullNameEn`, `Password` (nvarchar 300, **plaintext**), `Active` (bit), `IS_Change_Password` (bit), `EmpId`, `Outlet_ID`, `LastLoginDate`, address/phone fields, failure flags. **603** users have non-null passwords; lengths 3–16.
- `PR_Group` (21), `PR_UserGroup` (134) — maps users to groups with CRUD flags (`CanView, CanAdd, CanEdit, CanDelete, CanPrint`)
- `PR_Menu` (221), `PR_Module` (55), `PR_GroupModuleMenu` (194), `PR_GroupModuleMenuPrivilage` (8,418) — granular menu/privilege model
- `PR_Admin` (1), `PR_Application` (2), `PR_ApplicationCategory` (3), `PR_Mission` (23)
- `USER_TYPE` (0 rows) — keyless in schema, appears unused

## Critical constraints

1. **Plaintext passwords** — cannot be migrated to hashes as-is without user interaction. See Decisions #1.
2. **Two databases** — `dbPrivilage` must remain separate from `PlantQuarantine_New`. Do not merge into `PlantQuarantineDbContext`.
3. **No login endpoint in PlantQuar.API** — 238 WebAPI2 controllers, no `[HttpPost("login")]` found. Android API auth contract is unknown (see Decisions #2).
4. **Live DB untouched** — any bulk password rewrite is risky and must not happen automatically.

## Host mapping

| Host | Legacy source | Auth scheme | Notes |
|---|---|---|---|
| `ISCC.Api.Application` (staff/employers portal) | `PlantQuar.WEB` (MVC Areas, 349 controllers) | **Cookie** | Must align with `BaseController` session/culture and shared Razor layout. |
| `ISCC.Api.Android` (mobile API) | `PlantQuar.API` (WebAPI2, 238 controllers) | **JWT (likely)** | Stateless. Contract unknown — needs confirmation. |
| `ISCC.Api.Gate` (client portal) | Capqwebsite | Unchanged | Out of scope for this repo. |

## Recommended implementation

1. **Second DbContext**: `ISCC.Infrastructure/Data/PrivilageDbContext.cs` targeting `dbPrivilage`. Model only the tables we read/write for auth (`PR_User`, `PR_Group`, `PR_UserGroup`, `PR_Menu`, `PR_Module`, `PR_GroupModuleMenu`, `PR_GroupModuleMenuPrivilage`). Avoid full scaffolding unless necessary.
2. **Clean Architecture placement**:
   - Interfaces: `ISCC.Application/Abstraction/Auth/IUserAuthenticationService.cs` (or `ISCC.Domain.Abstraction.Auth` if we want domain-level auth)
   - DTOs: `ISCC.Application/DTOs/Auth/AuthenticatedUser.cs`, `LoginRequest/LoginResult`
   - Implementation: `ISCC.Infrastructure/Auth/UserAuthenticationService.cs` (uses both `PrivilageDbContext` and `PlantQuarantineDbContext` for outlet enrichment)
3. **Password handling (transitional)**:
   - On login: first attempt plaintext compare against `PR_User.Password` (backward compatible). If it matches and the stored value is not yet hashed, hash it on-the-fly and update `PR_User.Password` to the hash, set `IS_Change_Password = 1` (or keep as-is per policy), update `LastLoginDate`.
   - Going forward: store only hashes (e.g. ASP.NET Core `IPasswordHasher<PR_User>` or PBKDF2). This avoids a bulk migration and lets users transition naturally on login.
4. **Portals (Cookie)**: wire Cookie auth in `ISCC.Api.Application`/`ISCC.Api.Gate` Program.cs consistent with NewMvc (same claim names, expiry policy). Keep culture cookie write order intact (before/after `UseRequestLocalization` as we already have).
5. **Android API (JWT)**: add JWT Bearer support behind a config flag (`Auth:Jwt:Enabled`) but **do not** force it until the contract is confirmed. Add Swagger security definition only when JWT is enabled.

## Decisions needed (block Phase 2 implementation)

1. **Password migration strategy**  
   - A) **Force reset on first login** (recommended): after plaintext auth succeeds once, immediately redirect to "change password" screen; do not issue auth ticket until new password is set and hashed. This is cleanest and safest.  
   - B) **Silent rehash on successful login** (pragmatic): accept plaintext, if it's not a hash, overwrite with hash and continue. Users don't notice friction.  
   - C) **Keep plaintext forever** (not recommended): easy now, creates long-term risk.

2. **Android API authentication contract**  
   How does the Android app authenticate today? Does it call a login endpoint? If so, where (route) and what does it expect (token type, expiry, claims)? If unknown, I propose we implement cookie auth for portals only for now and defer JWT wiring until we can inspect traffic or the legacy API's auth surface.

3. **RBAC enforcement level**  
   - A) **Authenticate only** initially (just logged-in check), add menu/privilege checks per area as we port controllers.  
   - B) **Full RBAC from day one** (enforce `PR_GroupModuleMenuPrivilage` against controller/actions). More work up front but prevents privilege leakage.

4. **Privilage boundary**  
   Keep `dbPrivilage` as a separate DbContext (recommended). Agree this is the intended split (not merging into the main DB).

## Concrete next step

Write the design doc (this file), commit it, then implement minimal cookie auth for `ISCC.Api.Application` aligned with the NewMvc approach — **without** changing password storage yet — and surface the above decisions in the commit/PR notes. That keeps us moving while blocking on the security-critical choices.
