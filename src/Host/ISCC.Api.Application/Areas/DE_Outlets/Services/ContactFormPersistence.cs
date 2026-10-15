using ISCC.Api.Application.Areas.DE_Outlets.Models;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Api.Application.Areas.DE_Outlets.Services;

internal static class ContactFormPersistence
{
    public static async Task<bool> SyncAsync(
        PlantQuarantineDbContext db,
        long ownerId,
        int ownerType,
        IReadOnlyCollection<ContactInputModel>? submittedContacts,
        short userId,
        ModelStateDictionary modelState,
        CancellationToken cancellationToken)
    {
        var existingContacts = await db.HagrContacts
            .Where(contact => contact.ContactOwnerId == ownerId &&
                              contact.OutlitAdmin == ownerType &&
                              contact.IsActive &&
                              contact.UserDeletionId == null)
            .ToListAsync(cancellationToken);

        var submitted = (submittedContacts ?? Array.Empty<ContactInputModel>())
            .Where(contact => contact.Id.HasValue ||
                              contact.ContactTypeId.HasValue ||
                              !string.IsNullOrWhiteSpace(contact.Value))
            .ToList();

        if (submitted.Any(contact => !contact.ContactTypeId.HasValue || string.IsNullOrWhiteSpace(contact.Value)))
        {
            modelState.AddModelError(string.Empty, "أكمل نوع وقيمة وسيلة الاتصال أو احذف السطر الفارغ.");
        }

        if (submitted.Any(contact => contact.Value?.Trim().Length > 150))
        {
            modelState.AddModelError(string.Empty, "قيمة وسيلة الاتصال لا يمكن أن تتجاوز 150 حرفًا.");
        }

        var submittedIds = submitted.Where(contact => contact.Id.HasValue).Select(contact => contact.Id!.Value).ToList();
        if (submittedIds.Count != submittedIds.Distinct().Count() ||
            submittedIds.Any(id => existingContacts.All(existing => existing.Id != id)))
        {
            modelState.AddModelError(string.Empty, "تعذر التحقق من وسائل الاتصال المرسلة.");
        }

        var contactTypeIds = submitted
            .Where(contact => contact.ContactTypeId.HasValue)
            .Select(contact => contact.ContactTypeId!.Value)
            .Distinct()
            .ToList();
        var validContactTypeIds = await db.ContactTypes
            .Where(type => type.IsActive && contactTypeIds.Contains(type.Id))
            .Select(type => type.Id)
            .ToListAsync(cancellationToken);

        if (contactTypeIds.Except(validContactTypeIds).Any())
        {
            modelState.AddModelError(string.Empty, "اختر نوع اتصال متاحًا من القائمة.");
        }

        if (!modelState.IsValid)
        {
            return false;
        }

        var retainedIds = new HashSet<int>();
        foreach (var input in submitted)
        {
            if (input.Id is int contactId)
            {
                var existing = existingContacts.Single(contact => contact.Id == contactId);
                existing.ContactTypeId = input.ContactTypeId!.Value;
                existing.Value = input.Value!.Trim();
                existing.UserUpdationId = userId;
                existing.UserUpdationDate = DateTime.Now;
                retainedIds.Add(contactId);
                continue;
            }

            // Keep NEXT VALUE FOR in the top-level query. SingleAsync composes a
            // subquery on SQL Server, where sequence expressions are not allowed.
            var sequenceValues = await db.Database
                .SqlQueryRaw<int>("SELECT NEXT VALUE FOR dbo.HagrContact_SEQ AS value")
                .ToListAsync(cancellationToken);
            var id = sequenceValues.Single();

            db.HagrContacts.Add(new HagrContact
            {
                Id = id,
                ContactOwnerId = ownerId,
                OutlitAdmin = ownerType,
                ContactTypeId = input.ContactTypeId!.Value,
                Value = input.Value!.Trim(),
                IsActive = true,
                UserCreationId = userId,
                UserCreationDate = DateTime.Now,
            });
        }

        foreach (var removed in existingContacts.Where(contact => !retainedIds.Contains(contact.Id)))
        {
            removed.IsActive = false;
            removed.UserDeletionId = userId;
            removed.UserDeletionDate = DateTime.Now;
        }

        return true;
    }
}
