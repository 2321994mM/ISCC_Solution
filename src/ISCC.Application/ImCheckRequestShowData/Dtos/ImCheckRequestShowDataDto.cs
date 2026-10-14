namespace ISCC.Application.ImCheckRequestShowData.Dtos;

/// <summary>
/// One row of "موقف طلبات الفحص الواردة" — the per-outlet tally of import inspection
/// requests (<c>Im_CheckRequests/Im_CheckRequest_ShowData</c>, menu 165).
/// </summary>
/// <remarks>
/// <para>
/// Ported property-for-property from the legacy
/// <c>PlantQuar.DTO.DTO.Import.CheckRequests.Im_CheckRequest_ShowDataDTO</c>. The legacy
/// spelling (snake_case and the <c>CheckRequest_Count_*</c> / <c>Closed_Request_*</c> names)
/// is kept so the ported view can be compared with the legacy view line by line.
/// </para>
/// <para>
/// The columns mirror the select list of the stored procedure
/// <c>Pro_Im_CheckRequest_ShowData</c>, which this port replaces with EF Core.
/// </para>
/// </remarks>
public class ImCheckRequestShowDataDto
{
    /// <summary>
    /// The outlet id, or <c>0</c> for requests not yet routed to an outlet — the legacy
    /// procedure returned the string <c>'0'</c> for a <c>NULL</c> outlet.
    /// </summary>
    public long? outlet_ID { get; set; }

    /// <summary>
    /// The outlet name in the request's language, or <c>null</c> when the request was not
    /// routed to an outlet (the view substitutes a localized placeholder).
    /// </summary>
    public string? outlet_Name { get; set; }

    /// <summary>Every request of the outlet (<c>count(cc.ID)</c>).</summary>
    public int? CheckRequest_Count_all { get; set; }

    /// <summary>Requests accepted at the committee (<c>IsAccepted = 1</c>).</summary>
    public int? CheckRequest_Count_true { get; set; }

    /// <summary>Requests rejected at the committee (<c>IsAccepted = 0</c>).</summary>
    public int? CheckRequest_Count_false { get; set; }

    /// <summary>Requests not yet reviewed (<c>IsAccepted IS NULL</c>).</summary>
    public int? CheckRequest_Count_nulls { get; set; }

    /// <summary>Requests whose final result is closed (<c>Im_Final_Result.Status = 1</c>).</summary>
    public int? Closed_Request_true { get; set; }

    /// <summary>Requests that took a completion visa (<c>Status = 0</c>).</summary>
    public int? Closed_Request_false { get; set; }

    /// <summary>Requests that never reached a final result (<c>Status IS NULL</c>).</summary>
    public int? Closed_Request_nulls { get; set; }
}
