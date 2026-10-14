using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ISCC.Application.ImCommitteeFinalResult.Dtos;

namespace ISCC.Application.ImCommitteeFinalResult;

/// <summary>
/// Contract for the "نتيجة لجان الوارد" (ImCommittee_Final_Result) page.
/// Ported from the legacy <c>ImCommittee_Final_Result_API</c> / <c>ImCommittee_Final_ResultBLL</c>.
/// </summary>
public interface IImCommitteeFinalResultService
{
    /// <summary>The composite page payload (header, lots, committees, visa, final result).</summary>
    Task<ImCommittee_Final_ResultDTO?> GetAsync(
        long requestId,
        long itemShortNameId,
        long lotsItemShortNameId,
        long committeeTypeLstId,
        CancellationToken cancellationToken);

    /// <summary>Item short-name dropdown for the current request.</summary>
    Task<IReadOnlyList<CustomOptionLongId>> GetItemShortNamesAsync(long requestId, CancellationToken cancellationToken);

    /// <summary>Lot dropdown for one item short name on the current request.</summary>
    Task<IReadOnlyList<CustomOptionLongId>> GetLotsAsync(long requestId, long itemShortNameId, CancellationToken cancellationToken);

    /// <summary>
    /// Saves a lot's quarantine result. Every previous result row for the same lot has its
    /// <c>IsStatusCommittee</c> flag cleared; the new row is inserted and a log row written.
    /// </summary>
    Task SaveLotResultAsync(long requestId, Im_CheckRequest_Items_Lot_ResultDTO lotResult, CancellationToken cancellationToken);

    /// <summary>Saves the final result row and writes the matching log entry.</summary>
    Task SaveFinalResultAsync(long requestId, Im_CheckRequest_Final_ResultDTO finalResult, CancellationToken cancellationToken);

    /// <summary>Saves the visa row and writes the matching log entry.</summary>
    Task SaveVisaAsync(long requestId, Im_CheckRequest_VisaDTO visa, CancellationToken cancellationToken);

    /// <summary>One visa row (used to describe the visa description after selection).</summary>
    Task<Im_Visa_DataDTO?> GetVisaDataAsync(int visaId, CancellationToken cancellationToken);

    /// <summary>Lot result-status dropdown ("Name / يوجد اجراء آخر" pairs, plus the constant first row).</summary>
    Task<IReadOnlyList<CustomOption>> GetLotStatusesAsync(CancellationToken cancellationToken);

    /// <summary>Soft-deletes a committee's non-admin employee row and writes a log row.</summary>
    Task<bool> DeleteCommitteeEmployeeAsync(long requestId, long committeeId, long employeeId, short userId, CancellationToken cancellationToken);

    /// <summary>Sets the committee-accepted flag on a single lot-result row.</summary>
    Task<bool> SetLotResultStatusAsync(long statusId, bool status, CancellationToken cancellationToken);
}
