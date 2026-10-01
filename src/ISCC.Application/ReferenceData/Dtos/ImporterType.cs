namespace ISCC.Application.ReferenceData.Dtos;

/// <summary>
/// The kinds of party that can be recorded as the importer on a check request.
/// </summary>
/// <remarks>
/// <para>
/// The importer is polymorphic: <c>Im_CheckRequest_Data</c> stores a single
/// <c>Importer_ID</c> alongside an <c>ImporterType_Id</c> that decides which of three
/// unrelated tables that id actually points at. There is no foreign key, so the database
/// cannot enforce the pairing and a wrong <c>ImporterType_Id</c> silently joins to the
/// wrong name.
/// </para>
/// <para>
/// The numeric values come from the legacy <c>CASE</c> expressions and must not be
/// renumbered. The same three values are hardcoded in the legacy T-SQL of
/// <c>List_ImCheckRequest_Data</c>, in <c>PlantQuar.BLL</c> and in
/// <c>PlantQuarantine.NewMvc</c>, so the numbers are effectively a data contract.
/// </para>
/// <para>
/// Declared here, in the application layer, because a caller composing an importer query
/// has to know the pairing. The three table names are not repeated here on purpose: the
/// service owns them.
/// </para>
/// </remarks>
public enum ImporterType
{
    /// <summary>A registered national company. Stored in <c>Company_National</c>.</summary>
    CompanyNational = 6,

    /// <summary>A public body or organization. Stored in <c>Public_Organization</c>.</summary>
    PublicOrganization = 7,

    /// <summary>An individual. Stored in <c>Person</c>.</summary>
    Person = 8
}
