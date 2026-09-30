# Abstraction/IService

Reserved for **domain** service abstractions — operations that express real business rules
and belong to the domain model (for example pricing rules, eligibility rules, or state
transitions that more than one use case needs to share).

## Why this folder is currently empty

The application service contracts — `ICmsContentService`, `IReferenceDataService`,
`ITradeProcedureService`, `IDashboardService` — deliberately live in **`ISCC.Application`**
(`src/ISCC.Application/Cms/`, `ReferenceData/`, `TradeProcedures/`, `Dashboard/`) rather than
here, and should not be moved.

They all return Application-layer DTOs:

```csharp
using ISCC.Application.Cms.Dtos;
Task<List<CmsContentItemDto>> GetBySectionAsync(...);
```

Relocating them to `ISCC.Domain` would force `ISCC.Domain` to reference `ISCC.Application`,
but `ISCC.Application` already references `ISCC.Domain`. That is a circular project
reference, and it will not build.

The dependency direction is deliberate and must stay one-way:

```
ISCC.Domain  <--  ISCC.Application  <--  ISCC.Infrastructure  <--  Host projects
(no project references of its own)
```

Moving the DTOs down into `ISCC.Domain` as well would make the move legal, but it would be
the wrong fix: those DTOs are read models shaped for a specific query, not domain entities,
and the Domain layer would then be modelling the database rather than the business.

`Abstraction/IRepository` next door holds the persistence contracts (`IRepository<T>` and
`IUnitOfWork`), which have no such dependency problem because they deal only in
`TEntity`-shaped types.