# ISCC Migration Plan — Legacy `Capqwebsite` → Clean Architecture (.NET 9)

Analysis date: 2026-09-30
Legacy source: `C:\Users\Nabila\source\repos\ISCC_Capqwebsite`
Target: `C:\Users\Nabila\source\repos\ISCC_Solution`

Every number in this document was produced by reading the legacy source, not estimated.

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

| Location | Credential |
|---|---|
| `LoginController.cs:33` | `admin` / `admin@123` — plaintext, role `Administrator` |
| `LoginController.cs:49` | `Fess` / `Fess@123888` — plaintext, role `PaymentOnly` |
| `ViewModels/ResponseAcquirerCode.cs`, `Method_Bank.cs` | Mastercard gateway URL + **Base64 Basic-auth credentials**, hardcoded |
| `Capqwebsite/appsettings.json`, `EF/Node.txt` | SQL Server `User=new;Password=123` |

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