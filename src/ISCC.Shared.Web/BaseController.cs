using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace ISCC.Shared.Web;

/// <summary>
/// Base class for every UI-portal controller in this solution.
/// </summary>
/// <remarks>
/// <para>
/// Lives in a shared project rather than in one host so all portals inherit the same
/// behaviour. Before this, <c>BaseController</c> existed only inside the employers host,
/// which meant the client portal silently had no error logging and no localizer.
/// </para>
/// <para>
/// JSON endpoints should derive from <see cref="ApiControllerBase"/> instead.
/// </para>
/// </remarks>
public abstract class BaseController : Controller
{
    /// <summary>
    /// Localizer bound to the shared <c>ISCC.Shared.Localization</c> resource assembly.
    /// Uses the request's <c>Accept-Language</c> via <c>UseRequestLocalization</c>.
    /// </summary>
    protected IStringLocalizer L { get; }

    /// <summary>Creates the controller and injects its localizer.</summary>
    protected BaseController(IStringLocalizer<SharedResource> localizer)
    {
        L = localizer;
    }

    /// <summary>
    /// Resolves the scoped <see cref="PlantQuarantineDbContext"/> for the current request.
    /// </summary>
    protected PlantQuarantineDbContext Db =>
        HttpContext.RequestServices.GetRequiredService<PlantQuarantineDbContext>();

    /// <summary>
    /// Writes an error to the legacy log table <c>A__plant_Error_Save</c>.
    /// </summary>
    /// <remarks>
    /// Preserved from the legacy Capqwebsite controllers. The table has 15,328 live rows,
    /// so it is not dead schema and stays the system of record for application errors.
    /// <para>
    /// <c>Id</c> has no identity, default or trigger, so it must be supplied explicitly
    /// from the <c>A__plant_Error_Save_SEQ</c> sequence. <c>Date</c> uses local server
    /// time, matching legacy behaviour.
    /// </para>
    /// </remarks>
    protected void LogErrorToDb(string pageName, string functionName, string errorMessage, bool isWeb = true)
    {
        try
        {
            var db = Db;
            db.APlantErrorSaves.Add(new APlantErrorSave
            {
                Id = long.Parse(GetSequencing("long")),
                PageName = pageName,
                FunctionName = functionName,
                ErrorMessage = errorMessage,
                Date = DateTime.Now,
                UserIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                IsWeb = isWeb
            });
            db.SaveChanges();
        }
        catch (Exception)
        {
            // Never let error logging break the request pipeline.
        }
    }

    /// <summary>SQL sequence backing <c>A__plant_Error_Save.Id</c>.</summary>
    protected const string ErrorLogSequence = "A__plant_Error_Save_SEQ";

    /// <summary>
    /// Reads the next value from a SQL Server sequence. Mirrors the legacy
    /// <c>GetSequencing</c> helper.
    /// </summary>
    /// <param name="seqName">Sequence name, without the <c>dbo.</c> prefix.</param>
    /// <param name="type">One of <c>int</c>, <c>long</c>, <c>short</c>, <c>byte</c>.</param>
    protected string GetSequencing(string type = "int", string seqName = ErrorLogSequence)
    {
        var dbType = type switch
        {
            "byte" => System.Data.SqlDbType.TinyInt,
            "short" => System.Data.SqlDbType.SmallInt,
            "long" => System.Data.SqlDbType.BigInt,
            _ => System.Data.SqlDbType.Int
        };

        var parameter = new SqlParameter("@result", dbType)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        Db.Database.ExecuteSqlRaw("set @result = next value for dbo." + seqName, parameter);

        return parameter.Value?.ToString() ?? string.Empty;
    }

    /// <summary>The current request's culture code, for the bilingual components.</summary>
    protected string CurrentCulture => System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
}
