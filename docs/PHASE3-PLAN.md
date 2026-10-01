# Phase 3 — Plan

Written after scanning `ISCC_PlantQuarantine`. Three findings changed the plan.

---

## Finding 1 — there is already a `net9.0` application in the legacy repo

`PlantQuarantine.NewMvc` is not part of the .NET Framework 4.8 estate. It is a modern
ASP.NET Core app:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <TargetFramework>net9.0</TargetFramework>
  <Nullable>enable</Nullable>
  <ImplicitUsings>enable</ImplicitUsings>
```

An earlier scan of this repo reported it as 4.8. That was wrong — the scan keyed on
`<TargetFrameworkVersion>`, which this project does not have.

It contains a partially-built feature in **exactly** the structure this solution wants:

| | |
|---|---|
| `Areas/Import/Controllers/` | 4 controllers |
| `Areas/Import/Data/` | `IImportCheckRequestService` + impl, `IImportCommitteeService` + impl |
| `Areas/Import/Models/` | view models |
| `Areas/Import/Views/` | 5 views |
| `Services/Auth/` | `IUserAuthenticationService` + impl, `AuthenticatedUser` |
| `Program.cs`, `Views/Shared/_Layout.cshtml` | wiring and layout |

34 files, 3,509 lines. The service layer already separates interface from
implementation and the controllers already use areas.

**This is the reference for Phase 3, not the .NET Framework 4.8 code.** The 4.8 `BLL`
has no service abstraction to port from — it is data-access-coupled code (298 of 305
files use `PlantQuar.DAL` directly). NewMvc already solved the part that would otherwise
have to be designed from scratch.

### What it still needs

- **Data access.** It uses raw `SqlConnection`/`SqlCommand` (21 commands, 10 connections,
  67 parameters), not EF Core. All of it has to move onto `PlantQuarantineDbContext` +
  `IUnitOfWork`.
- **The 4.8 BLL logic behind those queries.** NewMvc's services call stored procedures;
  the business rules live in the procs and in the 4.8 BLL, and have to be read out of
  both.
- **Shared infrastructure.** Error handling, the response envelope, localization, UI
  components and Hangfire all come from `ISCC.Shared.Web`, none of which NewMvc uses.

---

## Finding 2 — 131 stored procedures, 110 of them live

This corrects an earlier claim that the database has no stored procedures. It has 131.

```
procedures in DB          : 131
referenced in legacy C#   : 110
```

**A migration plan that only counts C# lines is wrong by a wide margin.** The real logic
lives partly in T-SQL, and none of it is visible from the C# side. The 4.8 BLL's 126,298
lines and the procedures' logic are two halves of the same system.

Heaviest: `List_ImCheckRequest_Data` (the Import list, called by NewMvc),
`Ex_CheckRequestList` and `Ex_CheckRequestList_New` (two versions of the Export list),
`CheckRequest_ComiteeResult`, `Ex_ALL_List` (10 call sites).

Note the duplicated pair `Ex_CheckRequestList` / `Ex_CheckRequestList_New` — the same
pattern as the four Station implementations, but in SQL rather than C#.

### Recommended approach

**Keep the procedures; do not rewrite them in LINQ.** They are working, tuned SQL against
321,469 rows in `Im_CheckRequest`, and rewriting them in EF Core would be slower and
riskier than the problem warrants. Reach them through EF Core:

```csharp
await _context.Set<ImCheckRequest>().FromSqlRaw(
    "EXEC List_ImCheckRequest_Data @lang, @outlet_User, ...", params).ToListAsync(ct);
```

This keeps a single place to change later if a procedure must move to LINQ, without
committing to that now.

The 21 unreferenced procedures are **not** dead. Four are called from other procedures,
and the `Im_Fumigation` family was created 2026-07-19 and modified as recently as
2026-09-23 — an in-flight feature, not abandoned code. `YourProcedureName` is scaffolding
someone left behind.

---

## Finding 3 — the database is being changed right now

```
procedures modified 2026-10 (1), 2026-09 (17), 2026-08 (3), 2026-07 (4)
tables modified     2026-09 (11), 2026-08 (5), 2026-07 (18)
```

34 tables and 25 procedures changed in the last three months, most of them for the
fumigation feature. Two consequences:

1. **The scaffold will drift.** `PlantQuarantineDbContext` is verified as of today. Every
   change to the live schema needs a re-scaffold, or the drift surfaces later as an
   `InvalidOperationException` on whichever screen nobody tested.
2. **A frozen migration target may not exist.** If the fumigation work is still landing,
   some of what gets ported may be superseded before the migration reaches it.

Worth settling with whoever owns the fumination work before Phase 4 starts.

---

## Proposed Phase 3

### 3.1 — Reference data (unblocks everything)

Port NewMvc's wiring and shared infrastructure first, then reference/lookup data.

- Add `ISCC.Application` / `ISCC.Infrastructure` slices following the NewMvc service shape
- Reference data: `A_SystemCode`, Company, Port National/International, Governorates
- Small, low risk, and every other feature's dropdowns depend on it

### 3.2 — Import list (`List_ImCheckRequest_Data`)

NewMvc's `ImportCheckRequestsController` + `ImportCheckRequestService` + views, rebuilt
onto EF Core with the stored procedure reached via `FromSqlRaw`.

The Import lifecycle is the core of the system and `Im_CheckRequest` is the largest table
by far. Porting the *list* rather than the whole lifecycle keeps the first real slice
small while exercising: stored-proc access, filtering, paging, the shared table and
select2 components, localization, and the response envelope.

### 3.3 — Import detail + committees

`Details.cshtml` (21 KB) and `ImportCommittees/Prepare.cshtml` (24 KB) are the two
largest views in NewMvc. They are where the real complexity is.

### Then

`docs/REPLAN-STEPS-3-4.md` has the full eight-phase ordering. This plan supersedes its
first three phases, because it is now anchored on real code rather than on folder names.

---

## Sizing, honestly

Phase 3 as scoped above is **weeks**, not days — 3,509 lines of NewMvc plus the BLL logic
behind each of its queries, and the two largest views in the repo.

The full migration remains a multi-quarter programme. What Phase 3 delivers is one
feature area, end to end, running against the live database, with the pattern proven. That
is the most that can be honestly claimed as a first milestone.
