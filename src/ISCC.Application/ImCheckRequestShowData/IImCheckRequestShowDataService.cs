using ISCC.Application.ImCheckRequestShowData.Dtos;

namespace ISCC.Application.ImCheckRequestShowData;

/// <summary>
/// The import inspection-request status board
/// (<c>Im_CheckRequests/Im_CheckRequest_ShowData</c>, menu 165 — "موقف طلبات الفحص الواردة").
/// </summary>
/// <remarks>
/// Ported from the legacy <c>Im_CheckRequest_ShowDataBLL</c>, which returned the rows produced
/// by the stored procedure <c>Pro_Im_CheckRequest_ShowData</c> through an API endpoint. The
/// procedure is reproduced here directly with EF Core.
/// </remarks>
public interface IImCheckRequestShowDataService
{
    /// <summary>
    /// One row per outlet: how many of its requests are total / accepted / rejected /
    /// not-yet-reviewed, and how many reached a closed final result.
    /// </summary>
    /// <param name="isArabic">
    /// Selects the language of <see cref="ImCheckRequestShowDataDto.outlet_Name"/>. The legacy
    /// procedure always returned the Arabic name; the bilingual portal now picks by culture.
    /// </param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    Task<IReadOnlyList<ImCheckRequestShowDataDto>> GetAllAsync(
        bool isArabic, CancellationToken cancellationToken);
}
