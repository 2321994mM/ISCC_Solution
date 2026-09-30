namespace ISCC.Web.Employers.ViewModels;

/// <summary>
/// Base class for all portal view models.
/// View models live in the presentation (web) layer per Clean Architecture.
/// </summary>
public abstract class BaseViewModel
{
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
}