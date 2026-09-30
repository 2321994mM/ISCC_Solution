using ISCC.Application.TradeProcedures;
using ISCC.Application.TradeProcedures.Dtos;
using ISCC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Services;

public class TradeProcedureService : ITradeProcedureService
{
    private readonly PlantQuarantineDbContext _context;

    public TradeProcedureService(PlantQuarantineDbContext context)
    {
        _context = context;
    }

    // =================================================================
    // IMPORT
    // =================================================================

    public async Task<List<CountryOptionDto>> GetImportCountriesAsync(CancellationToken cancellationToken = default)
    {
        // Import filters all three joined tables three ways: IsActive == true AND
        // UserDeletionDate IS NULL AND UserDeletionId IS NULL.
        return await (
            from im in _context.ImInitiators.AsNoTracking()
            join c in _context.Countries.AsNoTracking() on im.CountryId equals c.Id
            join intext in _context.ImConstrainInitiatorTexts.AsNoTracking() on im.Id equals intext.ImInitiatorId
            where im.IsActive
                  && im.UserDeletionDate == null && im.UserDeletionId == null
                  && c.IsActive
                  && c.UserDeletionDate == null && c.UserDeletionId == null
                  && intext.IsActive
                  && intext.UserDeletionDate == null && intext.UserDeletionId == null
            // The legacy projection called this field IDInitiator but assigned c.Id, the
            // *country* id, and the drop-down used it as the country value. The
            // misleading name is dropped here; the value is unchanged.
            select new CountryOptionDto
            {
                Id = c.Id,
                NameAr = c.ArName,
                NameEn = c.EnName,
            })
            .Distinct()
            .OrderBy(x => x.NameAr)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ItemOptionDto>> GetImportItemsAsync(long countryId, CancellationToken cancellationToken = default)
    {
        if (countryId <= 0)
            return new List<ItemOptionDto>();

        // Parity note: the legacy query inner-joined Im_Constrain_Initiator_Texts but
        // applied NO filter to it. The join is therefore not merely redundant — it still
        // removes initiators that have no requirement text row at all, whether or not
        // that text is active. Removing the join would surface extra varieties, so it is
        // kept, and the unfiltered state is deliberate.
        return await (
            from i in _context.ItemShortNames.AsNoTracking()
            join im in _context.ImInitiators.AsNoTracking() on i.Id equals im.ItemShortNameId
            join intext in _context.ImConstrainInitiatorTexts.AsNoTracking() on im.Id equals intext.ImInitiatorId
            where im.CountryId == countryId
                  && im.IsActive
                  && im.UserDeletionDate == null && im.UserDeletionId == null
                  && i.ShortNameAr != null
                  && i.UserDeletionDate == null && i.UserDeletionId == null
            select new ItemOptionDto
            {
                Id = i.Id,
                // Import composes "parent item / variety". Export shows the variety alone.
                NameAr = i.Item!.NameAr + "/" + i.ShortNameAr,
                NameEn = i.Item.NameEn + "/" + i.ShortNameEn,
            })
            .Distinct()
            .OrderBy(x => x.NameAr)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ImportConstraintDto>> GetImportConstraintsAsync(
        long countryId, long itemId, CancellationToken cancellationToken = default)
    {
        return await (
            from im in _context.ImInitiators.AsNoTracking()
            join c in _context.Countries.AsNoTracking() on im.CountryId equals c.Id
            join intext in _context.ImConstrainInitiatorTexts.AsNoTracking() on im.Id equals intext.ImInitiatorId
            where im.CountryId == countryId
                  && im.ItemShortNameId == itemId
                  && im.IsActive
                  && im.UserDeletionDate == null && im.UserDeletionId == null
                  && c.IsActive
                  && c.UserDeletionDate == null && c.UserDeletionId == null
                  && intext.IsActive
                  && intext.UserDeletionDate == null && intext.UserDeletionId == null
            select new ImportConstraintDto
            {
                InitiatorRowId = im.Id,
                InitiatorNameAr = c.ArName,
                InitiatorNameEn = c.EnName,
                ItemName = im.ItemShortName!.Item!.NameAr,
                CountryId = im.CountryId,
                ItemShortNameId = im.ItemShortNameId,
                ItemId = im.ItemShortName.ItemId,
                ShortNameAr = im.ItemShortName.ShortNameAr,
                // Reached through the ConstrainText navigation, which targets
                // Im_CountryConstrain_Texts (there is no Im_Constrain_Texts table).
                ConstrainTextAr = intext.ConstrainText!.ConstrainTextAr,
                ConstrainTextEn = intext.ConstrainText.ConstrainTextEn,
                InSideCertificateAr = intext.ConstrainText.InSideCertificateAr,
                InSideCertificateEn = intext.ConstrainText.InSideCertificateEn,
            })
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    // =================================================================
    // EXPORT
    // =================================================================

    public async Task<List<CountryOptionDto>> GetExportCountriesAsync(CancellationToken cancellationToken = default)
    {
        // Export filters only UserDeletionId IS NULL — it never checks UserDeletionDate,
        // unlike import. A row soft-deleted with a date but no id would therefore still
        // appear here. Preserved verbatim; flagged for review.
        return await (
            from c in _context.Countries.AsNoTracking()
            join ecc in _context.ExCountryConstrains.AsNoTracking() on c.Id equals ecc.ImportCountryId
            where c.IsActive
                  && c.UserDeletionDate == null && c.UserDeletionId == null
                  && ecc.IsActive == true
                  && ecc.UserDeletionId == null
            select new CountryOptionDto
            {
                Id = c.Id,
                NameAr = c.ArName,
                NameEn = c.EnName,
            })
            .Distinct()
            .OrderBy(x => x.NameAr)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ItemOptionDto>> GetExportItemsAsync(long countryId, CancellationToken cancellationToken = default)
    {
        if (countryId <= 0)
            return new List<ItemOptionDto>();

        // Parity note: the legacy query filtered Ex_CountryConstrains but applied no
        // filter at all to Item_ShortNames — not even the IsActive/soft-delete checks that
        // import performs. Deleted or deactivated varieties can still be listed.
        // Preserved verbatim; flagged for review.
        return await (
            from i in _context.ItemShortNames.AsNoTracking()
            join ecc in _context.ExCountryConstrains.AsNoTracking() on i.Id equals ecc.ItemShortNameId
            where ecc.ImportCountryId == countryId
                  && ecc.IsActive == true
                  && ecc.UserDeletionId == null
                  && i.ShortNameAr != null
            select new ItemOptionDto
            {
                Id = i.Id,
                // Export shows the bare variety name; import prefixes the parent item.
                NameAr = i.ShortNameAr,
                NameEn = i.ShortNameEn,
            })
            .Distinct()
            .OrderBy(x => x.NameAr)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ExportConstraintDto>> GetExportConstraintsAsync(
        long countryId, long itemId, CancellationToken cancellationToken = default)
    {
        // Parity note: the legacy query never filtered the Countries table it joined, so a
        // soft-deleted country still yields its requirements. Preserved; flagged.
        return await (
            from ecc in _context.ExCountryConstrains.AsNoTracking()
            join c in _context.Countries.AsNoTracking() on ecc.ImportCountryId equals c.Id
            join exCTxt in _context.ExCountryConstrainTexts.AsNoTracking() on ecc.Id equals exCTxt.CountryConstrainId
            join exTxt in _context.ExConstrainTexts.AsNoTracking() on exCTxt.ExConstrainTextId equals exTxt.Id
            where ecc.ImportCountryId == countryId
                  && ecc.ItemShortNameId == itemId
                  && ecc.IsActive == true
                  && ecc.UserDeletionId == null
                  && exCTxt.IsActive
                  && exCTxt.UserDeletionId == null
                  && exTxt.IsActive
                  && exTxt.UserDeletionId == null
            select new ExportConstraintDto
            {
                CountryName = c.ArName,
                ItemName = ecc.ItemShortName!.Item!.NameAr,
                ShortNameAr = ecc.ItemShortName.ShortNameAr,
                ConstrainTextAr = exTxt.ConstrainTextAr,
                ConstrainTextEn = exTxt.ConstrainTextEn,
                InSideCertificateAr = exTxt.InSideCertificateAr,
                InSideCertificateEn = exTxt.InSideCertificateEn,
                ItemId = ecc.ItemShortName.Item!.Id,
            })
            .ToListAsync(cancellationToken);
    }
}
