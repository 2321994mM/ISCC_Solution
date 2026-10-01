# Phase 3.1 — Reference data (done)

First ported feature. Establishes the pattern the rest of Phase 3 follows.

## What was built

| | |
|---|---|
| `ISCC.Application/ReferenceData/IReferenceDataService.cs` | contract |
| `ISCC.Application/ReferenceData/Dtos/ImporterType.cs` | the polymorphic importer pairing |
| `ISCC.Infrastructure/ReferenceData/ReferenceDataService.cs` | EF Core implementation |
| `Host/ISCC.Api.Application/Controllers/ReferenceDataController.cs` | 3 endpoints |
| `ISCC.Shared.Contracts/ApiControllerBase.cs` | added typed `ApiNotFound<T>` |

Endpoints, verified against the live database:

```
GET /api/reference-data/importers?outletId=&selectedImporterId=&search=
GET /api/reference-data/importers/{importerId}
GET /api/reference-data/import-final-results
```

Registered in `ISCC.Infrastructure/DependencyInjection.cs` as
`AddScoped<IReferenceDataService, ReferenceDataService>()`.

## The layering this establishes

The contract sits in `ISCC.Application/<Feature>/` with `Dtos/` beside it, the
implementation in `ISCC.Infrastructure`, and the controller consumes only the contract.
This is the arrangement in `src/ISCC.Domain/Abstraction/IService/README.md`, now with a
real feature in it rather than a rule on paper.

`ISCC.Application` gained a ProjectReference to `ISCC.Shared.Contracts` so the contract can
return `SelectOption` instead of declaring a second, near-identical option type.
`ISCC.Shared.Contracts` is a leaf project with no references of its own, so this is a
sideways reference and creates no cycle.

## Ported from `PlantQuarantine.NewMvc`

NewMvc's `ImportCheckRequestService` served these same two lookups from raw
`SqlConnection`/`SqlCommand`. Rewritten as LINQ. Everything below is measured, not assumed.

### The polymorphic importer

`Im_CheckRequest_Data` stores one `Importer_ID` plus an `ImporterType_Id` deciding which of
three unrelated tables it points at — no foreign key, so the database cannot enforce the
pairing. Legacy expressed this as three `LEFT JOIN`s and a `CASE` for the display name,
which cannot be written in LINQ.

Split into three translatable queries and merged in memory. That is not a compromise, it
is faster. On a two-character search against live data:

| Approach | Time | Rows |
|---|---|---|
| three split queries, `DISTINCT` applied | ~90 ms each, **~270 ms** | 107 |
| one combined `UNION` query | **1,953 ms** | 107 |
| row-level join, no `DISTINCT` | **2,739 ms** | 107 |

The split is worth ~7× over a combined query. `DISTINCT` is worth another ~10×, and is not
an optimisation: `Im_CheckRequest_Data` holds 321,549 rows and 9,739 distinct companies, so
a company with 300 requests appears 300 times.

`DISTINCT` has to go on the anonymous projection, not on `SelectOption` — EF cannot
translate a distinct over a projected class, having no equality contract to compare
instances on.

This is the first worked example of the rule in `docs/PHASE3-PLAN.md`: reference data is
LINQ, operational lists are stored procedures. Different kinds of problem.

### Where behaviour was deliberately changed

Three, each an improvement that does not change what a user sees:

1. **Language no longer comes from configuration.** NewMvc took an `_language` int from
   `Import:DefaultLanguage` in its constructor and returned one `Text` chosen by
   `_language == 1 ? Ar : En`. The page's language was fixed when the service was built,
   not when the response was written, so an English user with the default set to 1 got
   Arabic names. `SelectOption` is bilingual and resolves per request culture; no method
   here takes a language parameter.
2. **The "all" sentinel moved from the service to the controller.** NewMvc returned
   `"كل الشركات"` as the first row of the data, indistinguishable from a real importer, so
   a filter treating `0` as a real id would behave wrongly. It is now added in the
   controller, bilingual, from the localizer. Response shape is unchanged.
3. **Those two labels are localized instead of hardcoded Arabic.** `"كل الشركات"` and
   `"كل مواقف الحجر"` were Arabic literals shown to every user, including English ones.
   Now `AllCompanies` and `AllFinalResults` in `SharedResource.resx` / `.Ar.resx`. The
   Arabic values are the legacy strings verbatim.

Behaviour preserved as-is: the two-character minimum search (a performance boundary — the
query touches `Im_CheckRequest_Data`, so it is not merely a UI nicety), `TOP (100)`, the
inner join to `Im_CheckRequest` for outlet scoping, and returning only importers that are
referenced by a check request rather than a full master list.

### One behaviour change that is visible, and why

Ordering follows the request culture instead of always `ORDER BY Ar_Name`. Because
`TOP (100)` is applied *after* sorting, the 100 importers returned now differ by culture
for the same search term — an English search and an Arabic search return different sets,
not just a different order.

This is why `selectedImporterId` exists. A filter pointing at a company that falls outside
the current culture's top 100 still renders, because the selection is always included
regardless of the search. The mitigation was already in the legacy design; it is now load-
bearing.

## Performance

| Endpoint | Cold | Warm median | Rows |
|---|---|---|---|
| `importers?search=Green` | 2,341 ms | **267 ms** | 101 |
| `importers?search=National` | — | 223 ms | 101 |
| `importers?search=الشركة` (AR) | — | 207 ms | 101 |
| `import-final-results` | — | < 10 ms | 8 |

### Recommended index — NOT applied, and not verified

`Im_CheckRequest_Data` has three indexes: the clustered `PK_Im_CheckRequest_Data (ID)`,
`IX_ImCheckRequestData_Request (Im_CheckRequest_ID)`, and a DTA-generated
`_dta_index_Im_CheckRequest_Data_15_948406648__K2_K4_3_13 (Importer_ID, ExportCountry_Id)`.

No index leads on `ImporterType_Id`, which is the predicate this query filters on. The
likely fix:

```sql
CREATE NONCLUSTERED INDEX IX_ImCheckRequestData_ImporterType_Importer
    ON Im_CheckRequest_Data (ImporterType_Id, Importer_ID);
```

**This has not been applied and the improvement has not been measured.** The live database
stays untouched, so this needs the database owner's decision and a measurement on a copy.
The 2.3 s cold cost is the part an index would most plausibly remove.

## Live-data problems found, not code problems

`Im_Final_Result` has 7 active rows, and the `En_Name` of four of them is `"1"`, `"2"` or
`"2323"`. That is test data in the production table. Flagged for the data owner; the code
returns it faithfully. Row 1 reads `2323` in both languages.

## Live database untouched

Re-verified after running the endpoints. Only `SELECT`s were issued.

```
tables                    = 298    (unchanged)
A__plant_Error_Save       = 15,328 (unchanged)
Im_CheckRequest           = 321,469 (unchanged)
Im_PermissionRequest_Hist = 5,044  (unchanged)
HangFire tables           = 0      (unchanged)
indexes on Im_CheckRequest_Data = 3 (unchanged — none added)
```

## Noted in passing

`Company_National.Name_Ar` is `Arabic_CI_AS` while system catalog columns are
`Latin1_General_CI_AS_KS_WS`, so ad-hoc metadata queries concatenating the two fail with
collation conflict 451 unless `COLLATE DATABASE_DEFAULT` is applied. This affects only
scripting against `sys.*`; EF queries are unaffected because each column is compared under
its own collation. Not a schema defect, but it will bite anyone writing inspection scripts.

## Next

Phase 3.2 — the Import list, via `List_ImCheckRequest_Data`. The stored procedure returns
everything and the legacy service pages in memory, so paging happens in the application
after a 321,469-row scan. Porting it as-is would reproduce that. Worth deciding what the
procedure actually needs to return before wiring it up.
