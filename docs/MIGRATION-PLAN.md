# ISCC Migration Plan — Legacy `Capqwebsite` → Clean Architecture (.NET 9)

## Solution layout

```
ISCC_Solution/
├── ISCC.sln
├── Directory.Packages.props          central package versions
├── docs/                             this plan + phase2-verification.txt
└── src/
    ├── ISCC.Domain/                  entities, enums, value objects
    │   └── Abstraction/
    │       ├── IRepository/          IRepository<T>, IUnitOfWork
    │       └── IService/             reserved for *domain* service abstractions (see its README)
    ├── ISCC.Application/             use cases + service contracts
    │   ├── Cms/          ├── ReferenceData/   ├── TradeProcedures/   └── Dashboard/
    ├── ISCC.Infrastructure/          PlantQuarantineDbContext + 300 generated POCOs
    ├── ISCC.Shared.Localization/      SharedResource.resx / .Ar.resx
    └── Host/                         the 3 deployable hosts
        ├── ISCC.Api.Application/      employers portal  (was ISCC.Web.Employers)
        ├── ISCC.Api.Gate/             client portal     (was ISCC.Web.Client)
        └── ISCC.Api.Android/          Android API
```

Dependency direction is one-way and must stay so:

```
ISCC.Domain  <-  ISCC.Application  <-  ISCC.Infrastructure  <-  Host projects
```

`ISCC.Domain` has **no project references of its own.** That constraint is why the
application service contracts (`ICmsContentService`, `IReferenceDataService`,
`ITradeProcedureService`, `IDashboardService`) stay in `ISCC.Application` — they return
Application DTOs, so relocating them into `ISCC.Domain` would require `Domain -> Application`
while the reverse edge already exists. See `src/ISCC.Domain/Abstraction/IService/README.md`.

The three hosts moved from `src/` to `src/Host/`, so all their `<ProjectReference>` paths
gained one `..\` segment.
---
Analysis date: 2026-09-30
Legacy source: `C:\Users\Nabila\source\repos\ISCC_Capqwebsite`
Target: `C:\Users\Nabila\source\repos\ISCC_Solution`

Every number in this document was produced by reading the legacy source, not estimated.

---

## Progress

> ### ⏪ Phase 2 reverted on 2026-09-30 — read this first
>
> All 10 ported controllers, their Razor views, `wwwroot` assets, view models, the four
> Application-layer feature services and their Infrastructure implementations were **deleted**
> at the user's request: the legacy repositories being used as the migration reference turned
> out not to be the correct ones, so the porting was done against the wrong source.
>
> - The work is **not lost** — it is intact in git history at commit **`470b657`**.
>   `git checkout 470b657 -- src/Host/ISCC.Api.Application src/ISCC.Application src/ISCC.Infrastructure/Services`
>   brings it all back.
> - **What survives** (deliberately kept): `ISCC.Domain`, `ISCC.Infrastructure` including the
>   `PlantQuarantineDbContext` scaffold of the live `PlantQuarantine_New` database, the
>   `IRepository`/`IUnitOfWork` abstractions, `ISCC.Shared.Localization`, all three host
>   skeletons, and `BaseController`.
> - **The live database was not touched** — verified after the deletion: 298 tables and
>   321,469 rows in `Im_CheckRequest` still present.
> - The findings below are **retained as analysis**. They describe real defects in the legacy
>   code (three pages that could never render, the `Math.Round`-over-aggregate that throws, the
>   missing authentication) and are worth keeping whichever repos turn out to be the real
>   reference, but they were measured against the repo that may not be authoritative.

| Phase | Item | Status |
|---|---|---|
| 0.2 | Delete `ISCCDbContext`, single context | ✅ done |
| 0.1 | Repo private + rotate SQL password | 🔴 **still outstanding — user action** |
| 0.3/0.4 | Legacy `EF/`, `ViewModels/`, old `src/` | ⏸ deliberately **kept** as migration reference; not deleted |
| — | Restructure: `Domain/Abstraction/{IRepository,IService}`, 3 hosts → `src/Host/` | ✅ done (`470b657`) — **still current** |
| 1.3 | `ICmsContentService` (6 controllers share it) | ⏪ reverted with Phase 2 |
| 1.5 | Localization wired, language switcher implemented | ⏪ reverted (`CultureController` deleted); `Shared.Localization` project survives |
| 2.1 | `HomeController` | ⏪ reverted |
| 2.2 | `NewsController` (+ fixed 150/200 truncation, fixed NRE → 404) | ⏪ reverted |
| 2.3 | `OfficesController` | ⏪ reverted |
| 2.4 | `AgricultureLawController` | ⏪ reverted |
| 2.5 | `contactController` | ⏪ reverted |
| 2.6 | `FarmController` | ⏪ reverted |
| 2.10 | `ErrorController` | ⏪ reverted |
| 2.11 | `_Layout` + 17 CSS/JS/font assets | ⏪ reverted |
| 2.7 | `ImportingProcedureController` | ⏪ reverted — 🔴 **legacy page was 100% broken**, see below |
| 2.8 | `ExportingProcedureController` | ⏪ reverted — 🔴 **legacy page was 100% broken**, see below |
| 2.9 | `dashBoardController` | ⏪ reverted → `DashboardController`, see below |

**The solution is currently an empty skeleton.** Phase 2 restarts from the corrected legacy
repositories; the skeleton, the DbContext scaffold and the localisation project carry over.

## Shared foundation

Four capabilities that every later phase depends on, built once in two shared projects so
the three hosts cannot drift apart. All of it is verified by running the hosts, not by
inspecting the code.

### `ISCC.Shared.Contracts` — the wire format

Holds `ApiResponse<T>`, `ApiError`, `ErrorCodes`, `PagedResult<T>`/`IPagedResult`,
`SelectOption` and `ApiControllerBase`. Only a `FrameworkReference` to
`Microsoft.AspNetCore.App`, so the Android API can use it without taking a Razor
dependency.

Every response a client can receive is the same shape:

```json
{ "success": false, "error": { "code": "NOT_FOUND", "message": "...", "details": {}, "traceId": "..." }, "traceId": "..." }
```

That includes the failures that never become exceptions. An unmatched route used to return
a bare `404` with an empty body, which is the one case a client parsing the envelope cannot
handle. `ErrorCodes.ForStatus` / `MessageForStatus` close that gap.

### `ISCC.Shared.Web` — the portal layer

`BaseController`, the shared Razor views and layout, the functional components, and the
pipeline wiring, all configured by one `AddSharedWeb` / `UseSharedWeb` pair.

**Error handling.** One `IExceptionHandler` serves JSON callers; HTML falls through to
re-execution on the shared error view. `SharedExceptionHandler.Map` is the single authority
for the status code, and the HTML path asks it for its answer too, so a browser and an API
client are told the same thing about the same failure. Unhandled exception messages never
reach the caller; they get a `traceId` that matches the row written to
`A__plant_Error_Save` and the Serilog file. The error page is status-aware — a 404 says
"page not found" and shows no reference number, because nothing was logged.

**Functional components.** `iscc-table` (with paging and a bilingual empty state),
`iscc-select`, `iscc-select2` (including cascading dropdowns over an AJAX endpoint). These
are behavioural widgets, not styling: they replace 11 hand-written legacy tables that each
had their own idea of an empty state. `/Home/Components` is the proof sheet.

> ⚠️ `TableColumn.Format` takes a **custom** format (`N0`, `N2`, `0.00`), not a composite
> one. `IFormattable.ToString("{0:N0}")` does not throw — it silently returns the literal
> string `{3650:N4}`, which looks like a data bug. The component normalises `{0:N0}` to
> `N0` so both spellings work, but prefer the plain form in new code.

**Assets.** The shared `wwwroot` is embedded in the assembly and served at `/_shared/...`.
A Razor class library normally serves its `wwwroot` through the static-web-assets manifest,
which only works when the host was published correctly. The host `wwwroot` folders do not
exist, so the usual `CompositeFileProvider` fallback throws `DirectoryNotFoundException`
during startup.

### Hangfire

Background jobs for the three hosts, storage in the same database under the `HangFire`
schema. The dashboard is **off by default** (`Hangfire:DashboardEnabled`) and gated by an
`IDashboardAuthorizationFilter`, so enabling it before Phase 3 lands fails closed (401)
rather than open.

> ### 🔴 Creating the Hangfire schema — read before the first deployment
>
> `PrepareSchemaIfNecessary` **defaults to `false`**, in code as well as in every committed
> `appsettings.json`. A `true` default would mean that deploying a host which merely forgot
> to set the value silently issues DDL against the live `PlantQuarantine_New` — 298 tables
> and 15,328 rows of production error logging. Letting a config default make that decision
> is not good enough, so it has to be typed out.
>
> The app therefore never needs DDL rights at runtime. Create the schema once, by hand:
>
> ```powershell
> # Option A — let Hangfire install it, on a scratch database only.
> #   Set Hangfire:PrepareSchemaIfNecessary=true, start the host, set it back.
> #
> # Option B — extract the bundled script, review it, then run it explicitly.
> #   Hangfire.SqlServer ships install.sql inside the NuGet package.
> #   (Get-ChildItem "$env:USERPROFILE\.nuget\packages\hangfire.sqlserver\1.8.25" -Recurse -Filter *.sql)
> #   sqlcmd -S <server> -d PlantQuarantine_New -u <user> -p <password> -C -i install.sql
> ```
>
> **Verified after a full run of all three hosts: the live database is unchanged.** No
> `HangFire*` tables exist, the table count is still 298 and `A__plant_Error_Save` still
> holds 15,328 rows. Until the schema is created deliberately, the worker logs connection
> failures and no jobs run — which is the intended failure mode, since no job has been
> written yet.

Two further decisions:

- The worker is registered with `services.AddHangfireServer(...)`, not
  `app.UseHangfireServer(...)`, which is obsolete in Hangfire 1.8.
- `RecurringJobSeeder` swallows storage failures. An exception out of a hosted service
  stops the host, and the Android API's job is to serve mobile clients; a Hangfire outage
  should degrade background processing, not take the API offline.

### `ISCC.Api.Android` is a stateless API

It passes `useSession: false`. Session lives in the one process that created it, so behind
a load balancer a second instance would silently see an empty session, and the middleware
would set a cookie the API never reads. It also has no error view, so its status-code
handler writes the envelope directly rather than re-executing to Razor.

> Registering **both** `UseStatusCodePages` and `UseStatusCodePagesWithReExecute` on one
> host is a subtle bug, not a redundancy: the middleware registered last is the innermost,
> so it fills the buffered body first and the outer one then sees a non-empty response and
> does nothing. A JSON caller would get HTML. One middleware, one writer.

### Known limit: language choice on a first-request error

The resolved culture is mirrored into the `.AspNetCore.Culture` cookie so the language
choice survives navigation. Re-execution for an error page reads the request cookies parsed
at the start of the outer request, so the very first request that *both* switches language
*and* 404s renders the error page in the previous language. It is correct from the next
navigation onwards. Threading the culture through re-execution would be a lot of machinery
for a self-correcting cosmetic case.

---

### `dashBoardController` → `DashboardController`

Class renamed to idiomatic PascalCase with an explicit `[Route("/dashBoard/dash")]` to pin
the URL, because the nav menu links to it by literal string. The legacy `Index` action was
**not** ported: it returned the entire `WebsiteTypeDetails` table unfiltered through a
24-line view that polled itself every 60 s, and nothing in the solution references the route.

| Legacy VM | Replaced by |
|---|---|
| `CountriesVM`, `CountriesExVM`, `ProductsVM`, `ProductsEXVM` | one `DashboardGroupDto` |
| `DashboardVM` + 4 `ViewBag` values | one `DashboardDto` |

Two legacy field names were actively misleading and were corrected: `Country` held a *plant
variety* on two of the four charts, and `CountOrders` held a **tonnage in tonnes**, not an
order count.

Preserved behaviours worth knowing about:

- **The reporting year rolls over in April**, not January — a visitor in February 2026 sees
  2025 figures.
- **Inbound charts filter on `IsAccepted_Date`; outbound charts filter on `User_Creation_Date`.**
  A consignment created last year but accepted this year drops out of the export charts and
  vice versa. Currently *not* observable — both return 0 rows for 2026 because the whole
  export data set spans 2024–2025 only — but it is a real divergence and is left as found.
- **Inbound queries reach line items through the shipping-method table; outbound queries join
  them directly to the request**, skipping that table.
- **The country charts group by `ExportCountry_Id`** — the country of origin of an inbound
  consignment, read off the request-data table.
- The country charts divided the summed weight by 1000 *after* aggregating; the product
  charts divided each row *before* summing. With `decimal` weights these are not always
  identical, so each keeps its own shape.

**Fixed over legacy:**

- `db.People.ToList().Count()` (×3) materialised every row of `Person`,
  `Public_Organization` and `Company_National` just to take a row count — now `COUNT(*)`.
- `orderby Math.Round((double)g.Sum(...))` cannot be translated to SQL by any EF version and
  throws `NotSupportedException` at runtime. The aggregate stays in SQL; rounding and ranking
  moved in-memory, which is what the query was trying to express. Ties are broken
  deterministically by the unrounded value.
- Each chart declared its label array twice: first via a `foreach` emitting `<text>` markup,
  then immediately reassigned from a JSON serialisation. The first pass was always discarded
  but had already been written into the page. Collapsed to one `const`.
- Tonnages are `double`s rendered into JS array literals; a culture with a comma decimal
  separator would have split `[1234,5]` into two elements. Now formatted invariantly.

### 🔴 Three legacy pages could never render at all

`/ImportingProcedure/Index`, `/ExportingProcedure/Index` and `/Farm/Index` all began with:

```csharp
var langCookies = Context.Request.Cookies.FirstOrDefault(c => c.Key == "Lang").Value;
```

`FirstOrDefault` returns `null` when no such cookie is present, so the trailing `.Value`
threw `NullReferenceException` on **every** request. No code in the legacy solution ever
wrote a `Lang` cookie — the only `Cookies.Append` in the entire application is commented
out, and it was for `UserId`, not `Lang`. So these three pages were permanently broken, and
all three are linked from the main navigation menu.

That means **745 lines of controller code across `ImportingProcedureController`,
`ExportingProcedureController` and `FarmController` had never successfully executed.**
There is therefore no production behaviour to compare against for them; the ported versions
were verified against hand-written SQL transcriptions of the legacy LINQ instead — the
import and export constraint queries return identical row counts on both sides.

Fixed by reading the culture resolved by `RequestLocalizationMiddleware` rather than a
cookie that never existed. Occurrences: 5 views.

### Filter divergences preserved in the trade-procedure service

`ImportingProcedureController` and `ExportingProcedureController` applied *different*
soft-delete rules to each other, and different rules again between their own three queries.
All are reproduced verbatim rather than normalised, because normalising would change which
rows appear:

| Query | Rule |
|---|---|
| Import — countries, constraints | `IsActive` + `UserDeletionDate IS NULL` + `UserDeletionId IS NULL` on all joined tables |
| Import — items | same, but `Im_Constrain_Initiator_Texts` is inner-joined and **not filtered at all**, so initiators having no requirement text are still excluded |
| Export — countries | `UserDeletionDate` checked on `Country` but **not** on `Ex_CountryConstrains` |
| Export — items | `Ex_CountryConstrains` filtered; **`Item_ShortNames` not filtered at all**, so deleted varieties can still be listed |
| Export — constraints | `Countries` joined but **never filtered** |

Also preserved: import labels a variety as `"ParentItem/Variety"` while export shows the bare
variety name; and the legacy `Im_InitiatorVM.IDInitiator` field, despite its name, was
assigned the **country** id — renaming it without changing the value would have broken the
cascading drop-down round trip.

Verified live against `PlantQuarantine_New` after the first Phase 2 slice: 9 pages
return HTTP 200, `/Offices/Index` renders 32 office cards with 50 map embeds,
`/News/Index?ID=7` renders 12 cards, and `lang`/`dir` follow the negotiated culture
(`ar`/`rtl` by default, `en`/`ltr` on `Accept-Language: en`).

Build: **0 errors, 0 warnings**. The AutoMapper advisory `NU1903` is gone.

---

## 1. What the legacy backend actually is

| Metric | Count |
|---|---|
| Controllers | 22 (17 top-level + 5 in `Fees\`) |
| Total controller lines | 3,530 |
| Public actions | 50 |
| Controllers that touch the DB | 15 |
| Controllers that are dead shells | 7 (4 truly unreferenced) |
| Views | 44 (30 MIGRATE / 13 DEAD / 3 duplicated) |
| Distinct DB tables referenced | 27 |
| **Stored procedures called** | **0** |
| SQL sequences used | 2 explicitly (`A__plant_Error_Save_SEQ`, `WebsiteTypeDetail_SEQ`) |
| Legacy EF project files | 301 — **100% `dotnet ef` scaffold output, zero hand-written logic** |
| ViewModels classes | 29 (28 used, 1 orphan) + 21 nested DTOs |

### Corrections to earlier assumptions

| Earlier belief | Reality |
|---|---|
| "Need to copy 286 stored procedures / functions / views" | **No code calls any of them.** Only 2 sequences are used, and they're called via `NEXT VALUE FOR`. The 286 SPs are dead weight from other systems. Do **not** copy them. |
| "Legacy EF has domain logic worth preserving" | **Zero.** Verified: 300 entity POCOs with no methods, constructors, attributes, or helpers. `AgricultureDBContext.cs` has exactly one hand-added block (the `OnConfiguring`). |
| "Legacy controllers are 4,023 lines" | 3,530. |
| "8 controllers touch the DB" | 15 do. 7 don't. |
| "DataTables is used" | Not present anywhere. All pagination is hand-rolled. |

### Database model: the new scaffold is a superset

Verified by diffing `PlantQuarantineDbContext` (311 DbSets) against the legacy `AgricultureDBContext` (300 DbSets):

| Object | Legacy | New scaffold | Status |
|---|---|---|---|
| `dbo` tables | 283 | ✅ | superset |
| `rejection` schema tables | 4 | ✅ all 4 present | superset |
| Keyless tables (`USER_TYPE`, `Im_PermissionRequest_History`) | 2 | ✅ both present | superset |
| Views | 11 | ✅ **14** (adds 3 `vw_Im_Fumigation_*`) | superset |

**Conclusion: the legacy `EF/` project can be deleted with zero loss.** Nothing in it survives that isn't already better in `PlantQuarantineDbContext`.

---

## 2. 🔴 Blocking security finding — must be resolved before migration

The legacy app has **no ASP.NET Core authentication or authorization at all**.

| Check | Result |
|---|---|
| `AddAuthentication()` | never called |
| `AddAuthentication` / `AddAuthorization` | never called |
| `UseAuthentication()` | never called |
| `UseAuthorization()` | called, but is a **no-op** (zero policies registered) |
| `[Authorize]` attributes | **zero** in the entire app |
| `[AllowAnonymous]` | 13 instances, all **inert no-ops** |
| `[ValidateAntiForgeryToken]` | **exactly one**, on a single action |

Access control consists entirely of hand-written `Session.GetString("UserSession")` checks scattered across 9 actions, plus a path allow-list in `Program.cs`.

### Unauthenticated endpoints that mutate data

| Endpoint | Impact |
|---|---|
| `DataEntry.Index` (POST) | Anonymous **INSERT** into `WebsiteTypeDetail` |
| `DataEntry.Update` (POST) | Anonymous **UPDATE** any row by posted ID |
| `DataEntry.Delete` (GET `?id=`) | Anonymous **DELETE**, state-changing GET, raw IDOR |
| `Fees.GeneralPayment` / `InspectionPayment` | Open payment forms |
| `Fees.SaveGeneralPayment` / `SaveInspectionPayment` (POST) | Creates real payment orders, **no antiforgery** |
| `Resit.Index` (GET) | Sets `IsSuccess_Bank = true`, `Code_Bank = "00"` **from query string** — anyone can forge a successful payment |
| `ResitPayment.Index` (GET) | Same forgery |
| `CheckGeneralPayment.Check` / `CheckResult` (POST/GET) | Mutates `Fees_Altahsils`, calls bank acquirer |

### Credentials in source

> **The values are redacted here on purpose.** This repository is public, so writing the
> credentials down in it would republish a secret that is already in git history and in the
> legacy source. Each one below is still recoverable from the location given, and each one
> has to be rotated regardless — see the outstanding actions at the top.

| Location | Credential |
|---|---|
| `LoginController.cs:33` | `admin` / *(redacted)* — plaintext, role `Administrator` |
| `LoginController.cs:49` | `Fess` / *(redacted)* — plaintext, role `PaymentOnly` |
| `ViewModels/ResponseAcquirerCode.cs`, `Method_Bank.cs` | Mastercard gateway URL + **Base64 Basic-auth credentials**, hardcoded |
| `Capqwebsite/appsettings.json`, `EF/Node.txt` | SQL Server login for the live `PlantQuarantine_New` |

> **This is a live financial system with forgeable payment confirmations.** The `Resit` forgery in particular means an attacker can mark any fee as paid without transferring money.
>
> Porting this code as-is would replicate the vulnerability. Auth must be designed before Phase 4, not after.

---

## 3. Portal assignment

| Legacy controller | Lines | Target portal |
|---|---|---|
| `LoginController` | 125 | Shared |
| `HomeController`, `NewsController`, `OfficesController`, `AgricultureLawController`, `contactController`, `FarmController`, `dashBoardController`, `ImportingProcedureController`, `ExportingProcedureController`, `ErrorController` | ~860 | **Client** (public, anonymous) |
| `Fees/*` (5 controllers) | 1,669 | **Client** |
| `DataEntryController` | 486 | **Employers** (CMS admin) |
| `Advertisements`, `advList`, `Newsdeteils`, `ImportServices`, `ExportServices` | 78 | **Drop** — dead |

---

## 4. Phased plan

### Phase 0 — Foundations 🔴 blocking

| # | Task | Why |
|---|---|---|
| 0.1 | Set GitHub repo to **Private**; rotate SQL login `new` | Password is in public commit `e253d9f` |
| 0.2 | Delete `ISCC_Solution`'s competing `ISCCDbContext`; keep `PlantQuarantineDbContext` as the only context | 2 contexts in DI is a runtime hazard; legacy model verified equivalent |
| 0.3 | Delete the abandoned `src/` scaffold inside `ISCC_Capqwebsite` (6 projects, ~duplicate of ours) | Prevents porting the wrong code |
| 0.4 | Delete legacy `EF/` and `ViewModels/` projects from the build | Verified zero unique content in `EF/`; VMs get re-homed into Application/Presentation |
| 0.5 | Keep this document as the traceability checklist; tick items as they land | |

### Phase 1 — Application layer foundation

| # | Task |
|---|---|
| 1.1 | Review and harden `IRepository<T>` + `UnitOfWork` (already scaffolded) |
| 1.2 | Register `PlantQuarantineDbContext` scoped; verify sequences are reachable |
| 1.3 | Build `ICmsContentService` — the one service 6 controllers share (`WebsiteTypeDetail` + `Websitetype`) |
| 1.4 | Re-home the 28 used ViewModels into Application DTOs / presentation VM |
| 1.5 | Move the `Lang` cookie NRE out of views; wire `.resx` localization fully |

### Phase 2 — Public read-only portal 🟢 start here, no blockers

Port in this order — each is independently verifiable, all anonymous, all read-only.

| # | Source | Lines | Depends on |
|---|---|---|---|
| 2.1 | `HomeController` | 142 | `ICmsContentService` |
| 2.2 | `NewsController` | 51 | `ICmsContentService` (fix substring bug) |
| 2.3 | `OfficesController` | 25 | `ICmsContentService` (ID 12 hardcoded → make it data-driven) |
| 2.4 | `AgricultureLawController` | 22 | `ICmsContentService` |
| 2.5 | `contactController` | 15 | — |
| 2.6 | `FarmController` | 32 | `FarmStop` |
| 2.7 | `ImportingProcedureController` | 379 | 6 tables; collapse 3-way soft-delete filter |
| 2.8 | `ExportingProcedureController` | 366 | 6 tables; 4-way join |
| 2.9 | `dashBoardController` | 127 | 13 tables, 4 heavy aggregates |
| 2.10 | `ErrorController` | 16 | — |
| 2.11 | `_Layout.cshtml`, `_ViewStart`, `_ViewImports`, 10 active CSS + 12 JS | — | dedupe the 8 Bootstrap versions |
| 2.12 | Language switcher (legacy has `href=""` — never implemented) | — | new |

### Phase 3 — Authentication 🔴 gates Phases 4 & 5

| # | Task |
|---|---|
| 3.1 | Identify the real user table (there is none today — decide: reuse `Person`, or create `A__User_Login`) |
| 3.2 | Real cookie authentication + `[Authorize]` + role policies, replacing the `Program.cs` path allow-list |
| 3.3 | Hashed passwords (PBKDF2/Argon2), delete the 2 hardcoded pairs |
| 3.4 | Preserve `A__plant_Error_Save` logging (works; uses the sequence) |
| 3.5 | Resolve every redirect target that doesn't exist (`CheckGeneralPayment`, `Fees.cancelorder`) |

### Phase 4 — Fees / payment (Client) 🔴 highest risk

| # | Source | Lines | Notes |
|---|---|---|---|
| 4.1 | `CheckGeneralPaymentController` | 101 | Unblocks the `Fess` login. Do first. |
| 4.2 | `CheckInspectionPaymentController` | 100 | 95% duplicate of 4.1 — merge |
| 4.3 | `FeesController` | **1,239** | The core. 10 actions, 4 payment flows, bank gateway. Decompose into services. |
| 4.4 | `ResitController` | 118 | Bank callback — **must verify a signed/verified response**, not trust query params |
| 4.5 | `ResitPaymentController` | 116 | Same |
| 4.6 | `PaymentsExcelExporter` | — | Move out of the controller |
| 4.7 | Bank credentials | — | Move from `ViewModels/*.cs` into configuration |
| 4.8 | Fix rather than port | — | `GeneralPayment` returns the wrong view; `Fees/Index.cshtml` (262 lines) never rendered; `Save*Payment.cshtml` never returned |

### Phase 5 — Employers CMS

| # | Task |
|---|---|
| 5.1 | `DataEntryController` (486 lines) behind real authorization |
| 5.2 | `Delete` GET → POST + anti-forgery + authorization |
| 5.3 | Upload hardening: whitelist extensions, randomize filenames, block `.html`/`.pdf` (already present in `wwwroot/img/`) |

### Phase 6 — Android API ⏸ blocked

Requires the old Android API project folder, which has not been shared. Current `ISCC.Api.Android` is placeholder scaffolding with 3 `CS1998` warnings and **no migrated logic**.

### Phase 7 — IIS deployment

| # | Task |
|---|---|
| 7.1 | Publish profiles, app pool (`.NET CLR v4.0`, **No Managed Code**, Integrated pipeline) |
| 7.2 | HTTPS binding + certificate; keep `TrustServerCertificate` out of production |
| 7.3 | Connection string via IIS environment variables / config, never in source |
| 7.4 | Cutover runbook; keep legacy app running for parallel verification |

---

## 5. Dead code — delete, don't port

| Item | Type | Evidence |
|---|---|---|
| `NewsdeteilsController` (12) | Controller | Zero inbound links; misspelled |
| `ImportServicesController` (17) | Controller | Nav link commented out; superseded by `AgricultureLaw?ID=16` |
| `ExportServicesController` (16) | Controller | Nav link commented out; superseded by `AgricultureLaw?ID=15` |
| `AdvertisementsController` (13), `advListController` (12) | Controllers | Lorem-ipsum mocks |
| `Views/Error/Index.cshtml` | View | Body is 100% inside `@* *@` |
| `Views/Newsdeteils/`, `Views/Advertisements/`, `Views/advList/` | 3 views | Mocks |
| `Views/ImportServices/`, `Views/ExportServices/` | 2 views | Unreachable |
| `Views/Home/Privacy.cshtml` | View | Unlinked scaffold stub |
| `Views/dashBoard/Index.cshtml` | View | Unrouted; 60 s self-polling `$('#…').load(location.href)` |
| `Views/Fees/Index.cshtml` (262 lines) | View | `FeesController.Index` only ever redirects |
| `Views/Fees/GeneralPayment.cshtml` | View | `GeneralPayment()` returns `"InspectionPayment"` instead |
| `Views/Fees/SaveGeneralPayment.cshtml`, `SaveInspectionPayment.cshtml` | 2 views | No `return View(...)` anywhere |
| `Views/Shared/_ValidationScriptsPartial.cshtml` | View | References `~/lib/jquery-validation/…` — path doesn't exist |
| `Views/Error/Index.cshtml` | View | Fully commented out |
| 4 `rejection`-schema entities | Model | Zero references from app |
| `ViewModels/Class1.cs` | Class | Template leftover |
| `ViewModels/test.cs` | File | Empty |
| `EF/Class1.cs` | Class | Template leftover |
| Large commented blocks | Code | `ExportingProcedureController:285-364`, `ImportingProcedureController:286-350` |
| 8 vendored Bootstrap versions | Assets | 3.3.2 → 5.3.5 all present; only one is used |
| Duplicate `select2.min.js` in `_Layout` (L445, L447) + CDN RC (L451) | Assets | Loaded 3× |
| Two jQuery majors (3.7.1 in head, 3.4.1 at end) | Assets | 3.4.1 wins at runtime |

---

## 6. Open decisions

1. **Auth model** — no user table exists today. Reuse `Person`, or create `A__User_Login` with hashed passwords?
2. **Portal split** — confirm the Phase 2 assignment (public content → Client, `DataEntry` → Employers).
3. **`dbPrivilage` database** — `20260901_AddSuccessfulPaymentReportsToPrivilegeMenu.sql` writes to a *separate* database (`dbo.PR_Menu`, `dbo.PR_GroupModuleMenuPrivilage`). That looks like a real RBAC menu system the app doesn't currently use. Is it in scope?
4. **Bank integration** — is the Mastercard gateway still in use, or is there a replacement?