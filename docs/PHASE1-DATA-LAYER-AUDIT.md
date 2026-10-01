# Phase 1 — Data Layer Audit

Status: **complete**. One defect found and fixed; no re-scaffolding required.

Date: 2026-10-01

## Scope

Verify `PlantQuarantineDbContext` (the single DbContext, database-first) against:

- the live `PlantQuarantine_New` database
- the legacy EF6 EDMX (`PlantQuar.DAL/Model1.edmx`, 2,450 KB)
- legacy usage in `ISCC_PlantQuarantine` (273k lines)

## Method

Three independent passes, because the first two produced wrong answers:

1. **Textual** — parse `DbSet<>` declarations and `ToTable(...)` calls out of the
   684 KB context file.
2. **Live DB** — `sys.tables` / `sys.columns` / `sys.key_constraints`.
3. **Runtime** — build the model through EF Core against an unreachable connection
   string and let EF validate it. Entity keys, table names and view mappings are only
   authoritative once the model is materialised.

Passes 1 and 2 both reported defects that did not exist. See "Corrections" below.

## Result: coverage

| | |
|---|---|
| Live user tables | 298 |
| Live views | 14 |
| `DbSet<T>` properties | 311 |
| `modelBuilder.Entity<T>` blocks | 311 |
| Live tables not mapped | **1** — `sysdiagrams` (correctly excluded) |
| Mappings pointing at a non-existent table | **0** |
| Entities with a primary key | **295** |
| Keyless entities | **16** (14 views + 2 tables, both justified below) |

Mapping resolution: 288 explicit `ToTable`, 14 `ToView`, 9 by naming convention
(DbSet property name matches the table name exactly, which EF resolves correctly).

## Defect found and fixed

`PlantQuarantineDbContext.cs:6606`

```csharp
entity.ToTable("Im_choose_Constrain ");   // trailing space
```

Trailing space in a table name. It works only because SQL Server's default collation
ignores trailing spaces when comparing identifiers, so every query succeeds and the
bug is invisible — until the database is restored under a binary or case-sensitive
collation, at which point every read of this table fails at runtime.

Fixed to `entity.ToTable("Im_choose_Constrain");`. Verified: `Im_choose_Constrain`
has PK `PK_Im_Constrain_chooes` on `ID`, so the mapping is otherwise correct.

## Keyless tables — both correct, documented

EF resolves a key by convention (`Id` or `<TypeName>Id`) and only needs an explicit
`HasKey` when that fails, so the 94 explicit `HasKey` calls are the *exceptions*,
not the rule. 295 of 311 entities resolve a key.

Two keyless entities map to tables rather than views. Neither is a defect:

- **`Im_PermissionRequest_History`** — no primary key in the database. 5,044 rows.
  EF treats it as read-only, which is correct: the legacy app never writes to it.
  It appears only in two generated DAL files (`Im_PermissionRequest_History.cs`,
  `Model1.Context.cs`) and in zero application code.
- **`USER_TYPE`** — no primary key, **0 rows**, and referenced only by its own
  generated POCO and DbSet. Dead. Note its `Password` column is also plaintext;
  with 0 rows there is no exposure, but see Phase 2 before anyone re-populates it.

## Corrections to earlier findings

Recorded because both were reported and both were wrong:

- **"10 live tables have no mapping"** — false. All 9 real tables have entity
  classes and `DbSet` properties; they are mapped by naming convention rather than
  by an explicit `ToTable`, which a `ToTable`-only diff cannot see. `ItemCategories`
  (21 files) and `TreatmentMethods` (21 files) are both heavily used by the legacy
  app and both are correctly mapped.
- **"14 entities risk `InvalidOperationException: Cannot find table`"** — false.
  All 14 are views mapped with `ToView(...)` + `HasNoKey()`. A search for `ToTable`
  alone classifies them as unmapped.

## Live database state

Unchanged by this audit. The audit used `sys.*` catalog reads and one throwaway
console project pointed at an unreachable connection string; no connection ever
issued a DDL or DML statement.

- 298 tables
- 15,328 rows in `A__plant_Error_Save`
- 0 `HangFire*` tables

## Conclusion

Phase 1 needed no new entities, no re-scaffolding and no model changes beyond one
trailing space. The data layer is sound and can be treated as done.

The real constraint on this project is elsewhere: `dbPrivilage` is a **second
database** that is not in this DbContext at all, and it holds the real
authentication model (`PR_User`, 998 rows, all active, passwords stored in
plaintext). See `docs/PHASE2-AUTH-DESIGN.md`.

---

# Addendum — `dbPrivilage` mapped

`PlantQuarantineDbContext` covers only `PlantQuarantine_New`. The audit found a
second database holding the RBAC data, unreachable from the solution. It now has
its own context.

## `PrivilageDbContext` (`src/ISCC.Infrastructure/Data/Privilage/`)

A separate `DbContext`, not more `DbSet`s on `PlantQuarantineDbContext`. The two
databases have different lifecycles, and EF Core cannot express a join across two
contextes — the legacy `PlantQuarantine.NewMvc` app used two connection strings in
exactly this way.

Three tables mapped, hand-written rather than scaffolded:

| Entity | Table | Rows |
|---|---|---|
| `PrUser` | `PR_User` | 998 |
| `PrGroup` | `PR_Group` | 21 |
| `PrUserGroup` | `PR_UserGroup` | 134 |

Verified read-only against the live database: model materialises, keys resolve
(`Id` on all three), row counts match, the `PR_User` → `UserGroups` → `Group`
navigation loads with `Include`, and the nullable CRUD flags project correctly.

The remaining nine tables (`PR_Menu` 221, `PR_Module` 55, `PR_GroupModuleMenu` 194,
`PR_GroupModuleMenuPrivilage` 8,418, `PR_Admin`, `PR_Application`,
`PR_ApplicationCategory`, `PR_Mission`, `PR_Setting`) are deliberately **not**
mapped yet. They get mapped when privilege enforcement lands, in the feature area
that needs them.

## 🔴 The RBAC model enforces nothing

This is the most important finding in the audit, and it corrects an earlier
assumption that `dbPrivilage` carried a working permission system.

**`PR_UserGroup` — all five permission columns are NULL in all 134 rows.**

```
user=693 group=17 view=null add=null edit=null del=null print=null
memberships with at least one NULL flag: 134   <- every row
```

**`PR_GroupModuleMenuPrivilage` — 8,418 rows, and every flag is set to 1.**

```
CanView=1: 8417   CanAdd=1: 8417   CanEdit=1: 8415
CanDelete=1: 8415 CanPrint=1: 8417  all-null: 0   active: 8417/8418
```

So across 18 groups and 194 menu assignments there is not a single denial in the
table. Combined with the previous result, the effective model is:

> If you belong to a group, you may do everything that group may do — and every
> group may do everything.

The table *looks* like a permission system because it has 8,418 rows of flags. It
enforces nothing.

**This matches the code.** The audit found 6 `[Authorize]` attributes across 587
controllers and a `Session["UserId"]` null-check in `BaseController` — which is
exactly what an all-allow permission table produces. The legacy system is
de facto authenticate-only.

Consequence for the migration: **enforcing these flags would be a behaviour
change, not a port.** "Authenticate only" is the faithful reproduction. This
independently confirms the Phase 2 decision to port the existing behaviour as-is
rather than improve on it mid-migration.

