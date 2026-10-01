# Replan — Steps 3 and 4 (services, controllers)

Supersedes the "all services, then all controllers" sequencing in the original four-step
plan. Steps 1 and 2 are done and verified; this covers what remains.

## What the measurements changed

The case for bottom-up was "discover the shape of the system as you go". The audit
already did that, in one pass. So the main argument for breadth-first no longer
applies, and three findings now argue against it.

**1. The BLL is not a service layer — it is data-access-coupled code.**

```
BLL files with 'using PlantQuar.DAL' : 298 of 305
BLL files with 'using PlantQuar.UOW' : 305 of 305
BLL files with 'using PlantQuar.WEB' : 12
```

Every BLL class reaches through the unit of work straight onto EF6 entities. There is no
abstraction to port, so "all services" means porting 126,298 lines of LINQ-over-entities
where the business rules are interleaved with the queries. Those rules can only be
validated by something calling them.

**2. Duplication inside the BLL is far worse than in the controllers.**

```
duplicated BLL class names : 69 across 139 files
```

139 of 305 files — 46% — collide on class name. The controller figure was 33 names across
67 files. Four parallel station implementations:

| BLL folder | Files | Lines |
|---|---|---|
| `Station1` | 14 | 3,428 |
| `Stations` | 14 | 3,089 |
| `Station_Pages` | 9 | 2,839 |
| `ST_Station` (WEB) | 14 | 2,660 |
| **total** | **51** | **~12,000** |

Three parallel export-check-request implementations:

| BLL folder | Files | Lines |
|---|---|---|
| `Export_CheckRequest` | 12 | 11,259 |
| `Export_CheckRequest_New` | 2 | 3,288 |
| `Pallet_Export_CheckRequest` | 4 | 3,408 |
| **total** | **18** | **~18,000** |

Roughly 30,000 lines across seven folders exist only as parallel variants. Porting "all"
means porting all of them. Deciding which is canonical is a per-feature decision, and
breadth-first has no natural moment to make it.

**3. The BLL is one flat folder.** All 305 files sit under `BLL/` with no partitioning
(`IBLL` holds a single 13-line file). The feature areas exist only as WEB `Areas/`
folders. So there is no existing service boundary to migrate to — one has to be chosen
per feature, which is a decision that belongs next to the feature's code, not in a
batch.

## Proposed sequencing

Steps 3 and 4 are kept, but interleaved: each phase takes one feature area through BLL
and controllers together, so every phase ends with something running.

Ordered by business value and risk, **not** by size — the biggest area is deliberately
last.

| # | Area | BLL lines | WEB | Why here |
|---|---|---|---|---|
| 1 | Reference data (SystemCodes, Company) | ~3,700 | `CO_Company` | Low risk, unblocks every other area's dropdowns |
| 2 | Farm | 8,952 | `FA_Farm` | Self-contained, real data, exercises the full stack once |
| 3 | **Import lifecycle** | 17,463 | `Im_CheckRequests` | The core. `Im_CheckRequest` holds 321,469 live rows |
| 4 | Export lifecycle | 17,955 | `Export_CheckRequest*` | Core, but 3 variants to reconcile first |
| 5 | Committee workflow | 7,516 | `Committees` | Largest WEB area (10,539 lines); complex workflow |
| 6 | Station | ~6,356 | 4 areas | Only after picking canonical among 4 implementations |
| 7 | DataEntry | 38,473 | `DE_*` | 30% of the BLL, 112 files, but overwhelmingly CRUD |
| 8 | Fees / payment | — | `StationPayment*` | Real money; last, and reviewed hardest |

### Rules that apply to every phase

- **Duplicates die at the point of decision.** When a phase touches `Stations`, the
  canonical implementation is chosen and the other three are recorded as dead in
  `MIGRATION-PLAN.md`. They are never ported "just in case".
- **A phase is not done until it runs.** Booting the host and exercising the feature,
  which is how the four real bugs in the shared foundation were found.
- **Fees are never batch-ported.** Phase 8 gets line-by-line review.

## Honest sizing

Steps 1 and 2 took one session and found one defect. Steps 3 and 4 are a different
proposition: ~126,000 lines of BLL and 587 controllers, against a system with 273,000
lines total. Deduplicating first would remove an estimated 30,000 BLL lines and 12
files of literal `Controllers - Copy`.

This is a multi-quarter programme. Phase 3's first slice (reference data) is the honest
first milestone, not a complete feature.
