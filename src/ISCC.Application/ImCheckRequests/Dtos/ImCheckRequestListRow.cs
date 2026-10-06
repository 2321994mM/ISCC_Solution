namespace ISCC.Application.ImCheckRequests.Dtos;

/// <summary>
/// One row of <c>List_ImCheckRequest_Data</c> output.
/// </summary>
/// <remarks>
/// <para>
/// Property names mirror the procedure's column aliases <b>exactly</b> (including
/// underscores). EF Core's non-entity <c>SqlQueryRaw&lt;T&gt;</c> matches result columns to
/// properties case-insensitively but not underscore-insensitively, so a "clean" name like
/// <c>ImCheckRequestId</c> would silently receive no value while the underscore column goes
/// unmapped. The alias names are load-bearing, not cosmetic.
/// </para>
/// <para>
/// Types follow the T-SQL: bigint → long, bit → bool, nullable where the join allows nulls.
/// </para>
/// </remarks>
public class ImCheckRequestListRow
{
    public long row_number { get; set; }
    public long TotalCount { get; set; }
    public long Im_CheckRequest_ID { get; set; }
    public long? Im_CheckRequest_Final_Result_ID { get; set; }
    public string? ImCheckRequest_Number { get; set; }
    public long? Outlet_ID { get; set; }
    public DateTime? Creation_Date { get; set; }
    public bool? IsAccepted { get; set; }
    public string? ExportCountryName { get; set; }
    public long Importer_ID { get; set; }
    public int ImporterType_Id { get; set; }
    public string? ImporterTypeName { get; set; }
    public bool? Closed_Request { get; set; }
    public int? Im_Final_Result_ID { get; set; }
    public string? Name_Final_Result { get; set; }
    public string? ImporterName { get; set; }
}