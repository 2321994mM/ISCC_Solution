using ISCC.Application.ImCheckRequestDetails.Dtos;

namespace ISCC.Application.ImCheckRequestDetails;

/// <summary>
/// The import check-request details screen
/// (<c>Im_CheckRequests/Im_CheckRequestDetails</c>).
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>Im_CheckRequestDetailsBLL</c> and the JSON controller
/// <c>Im_CheckRequests_APIController</c>. The legacy screen called a single API endpoint that
/// returned the whole <c>ImRequestDetailsDTO</c>; the same payload is assembled here directly
/// with EF Core. Three write actions (save refuse reasons, accept/reject the request, edit an
/// item's fees) and the refuse-reason dropdown complete the page.
/// </para>
/// </remarks>
public interface IImCheckRequestDetailsService
{
    /// <summary>
    /// Loads the whole page payload for one request number. Returns <c>null</c> when no request
    /// with that number exists (the legacy screen rendered an empty page).
    /// </summary>
    /// <param name="imCheckRequestNumber">The request number (<c>CheckRequest_Number</c>).</param>
    /// <param name="outletId">The outlet the caller came from; used to resolve the outlet name.</param>
    Task<ImRequestDetailsDto?> GetAsync(
        string imCheckRequestNumber,
        int? outletId,
        CancellationToken cancellationToken);

    /// <summary>
    /// The refuse-reason dropdown. <paramref name="refuse"/> = 1 returns the reasons that stop
    /// the request (system code 84); otherwise the reasons that do not stop it (system code 83).
    /// </summary>
    Task<IReadOnlyList<RefuseReasonOptionDto>> GetRefuseReasonsAsync(
        int refuse,
        CancellationToken cancellationToken);

    /// <summary>Saves the selected refuse reasons for the request and returns the request id.</summary>
    Task<long> SaveReasonsAsync(ReasonsListReqIdDto dto, CancellationToken cancellationToken);

    /// <summary>Accepts or rejects the request (sets IsAccepted / IsAccepted_Date / IsActive).</summary>
    Task AcceptRequestAsync(ImCheckRequestDto dto, CancellationToken cancellationToken);

    /// <summary>Updates the fees of one imported item.</summary>
    Task SaveItemFeesAsync(ItemFeesDto item, CancellationToken cancellationToken);
}
