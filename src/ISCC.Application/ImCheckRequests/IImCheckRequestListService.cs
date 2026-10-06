using ISCC.Application.ImCheckRequests.Dtos;
using ISCC.Shared.Contracts;

namespace ISCC.Application.ImCheckRequests;

/// <summary>
/// The "طلبات الفحص الحالية - وارد" screen: search the outlet's import inspection
/// requests and the two dropdowns that filter them.
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>List_Im_checkRequestsBLL</c> + <c>Company_NationalBLL</c>
/// (company dropdown) + <c>Im_FinalResult_DataBLL</c> (final-result dropdown). The heavy
/// list query stays a stored procedure — <c>List_ImCheckRequest_Data</c> — reached through
/// raw SQL, because it is tuned T-SQL over a 321k-row table. The dropdowns are expressed
/// as LINQ over the same context, mirroring <see cref="ISCC.Application.ReferenceData.IReferenceDataService"/>.
/// </para>
/// </remarks>
public interface IImCheckRequestListService
{
    /// <summary>
    /// Runs the paged import-request search against <c>List_ImCheckRequest_Data</c>.
    /// Page size is always 25; the procedure ignores anything else.
    /// </summary>
    Task<ImCheckRequestListResult> SearchAsync(ImCheckRequestListQuery query, CancellationToken ct);

    /// <summary>
    /// Distinct importers referenced by this outlet's import requests, for the company
    /// filter. Bilingual by request culture, like every dropdown in this solution.
    /// </summary>
    /// <remarks>
    /// Counts every distinct (importer, type) pair the outlet has ever submitted. Calls of
    /// this screen are rare and the result is cached by the browser page, so returning the
    /// full list (rather than a capped autocomplete) is the legacy behaviour and stays it.
    /// </remarks>
    Task<IReadOnlyList<SelectOption>> GetCompaniesAsync(long outletId, CancellationToken ct);

    /// <summary>
    /// Final results for the quarantine-status filter (selectApproveId 6/7). Only options
    /// matching the chosen status are returned, exactly like the legacy chain that filled
    /// this dropdown only while a working/not-working status was selected.
    /// </summary>
    /// <param name="selectApproveId">The selected request status; 6 = working, 7 = not working.</param>
    Task<IReadOnlyList<SelectOption>> GetFinalResultOptionsAsync(int selectApproveId, CancellationToken ct);
}