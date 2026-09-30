namespace ISCC.Application.Cms;

/// <summary>
/// The CMS section identifiers held in <c>dbo.Websitetype.ID</c>.
/// </summary>
/// <remarks>
/// These are hard-coded magic numbers throughout the legacy controllers. They were
/// verified against live data in <c>PlantQuarantine_New</c>:
/// <code>
/// 1 AgricultureLaw   2 MinistryDecrees  3 PestLists      7 News
/// 8 Advertisment     9 Slider          10 Alerts        11 IntroductionOFMinistry
/// 12 Offces
/// </code>
/// </remarks>
public static class CmsSection
{
    public const int AgricultureLaw = 1;
    public const int MinistryDecrees = 2;
    public const int PestLists = 3;
    public const int News = 7;
    public const int Advertisment = 8;
    public const int Slider = 9;
    public const int Alerts = 10;
    public const int IntroductionOfMinistry = 11;
    public const int Offices = 12;
    public const int OpenFactoryProcedures = 13;
    public const int IntroVideos = 14;
    public const int EServicesExplainerExport = 15;
    public const int EServicesExplainerImport = 16;
}