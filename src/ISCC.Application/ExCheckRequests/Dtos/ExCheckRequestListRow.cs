namespace ISCC.Application.ExCheckRequests.Dtos;

/// <summary>
/// One row of the <c>dbo.Ex_List</c> view output.
/// </summary>
/// <remarks>
/// <para>
/// Property names mirror the view's column names <b>exactly</b>. EF Core's non-entity
/// <c>SqlQueryRaw&lt;T&gt;</c> matches result columns to properties case-insensitively but
/// not underscore-insensitively, so a "clean" name would silently receive no value. The
/// names are load-bearing, not cosmetic — the same rule the import screen's row applies.
/// </para>
/// <para>
/// <c>TotalCount</c> is added by the query (<c>COUNT_BIG(1) OVER ()</c>), not by the view.
/// The view's own columns are the first 28 properties, in view order, with types matching
/// the T-SQL: bigint → long, smallint → short, bit → bool, nullable where the join allows
/// nulls.
/// </para>
/// </remarks>
public class ExCheckRequestListRow
{
    public long? Outlet_User_ID { get; set; }
    public string? Outlet_User_Name { get; set; }
    public short? Center_ID { get; set; }
    public long Ex_CheckRequest_ID { get; set; }
    public string? ImCheckRequest_Number { get; set; }
    public DateTime? Creation_Date { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsActive { get; set; }
    public string? ExportCountryName { get; set; }
    public long Importer_ID { get; set; }
    public int ImporterType_Id { get; set; }
    public bool? IsPaid { get; set; }
    public long? Outlet_ID { get; set; }
    public string? ImporterTypeName { get; set; }
    public string? ImporterName { get; set; }
    public short? f { get; set; }
    public long g { get; set; }
    public long? Outlet_Examination_ID { get; set; }
    public string? Outlet_Examination_Name { get; set; }
    public long? Station_Examination_ID { get; set; }
    public long? Outlet_Genshi_ID { get; set; }
    public string? Outlet_Genshi_Name { get; set; }
    public long? Station_Genshi_ID { get; set; }
    public int? Closed_Request { get; set; }
    public int Final_Result_ID { get; set; }
    public string? Final_Result_Name { get; set; }
    public string? Station_Examination_Name { get; set; }
    public string? Station_Genshi_Name { get; set; }

    /// <summary>The un-paged row count, carried on every row by the query.</summary>
    public long TotalCount { get; set; }
}