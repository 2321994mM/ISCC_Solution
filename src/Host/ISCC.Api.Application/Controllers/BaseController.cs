using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

/// <summary>
/// Base controller for all portal controllers.
/// Provides localization and the legacy database error logging so controllers
/// don't repeat that boilerplate.
/// </summary>
public abstract class BaseController : Controller
{
    /// <summary>
    /// Localizer bound to the shared ISCC.Shared.Localization resource assembly.
    /// </summary>
    protected IStringLocalizer L { get; }

    protected BaseController(IStringLocalizer<SharedResource> localizer)
    {
        L = localizer;
    }

    /// <summary>
    /// Resolves the scoped <see cref="PlantQuarantineDbContext"/> for the current request.
    /// </summary>
    protected PlantQuarantineDbContext Db => HttpContext.RequestServices.GetRequiredService<PlantQuarantineDbContext>();

    /// <summary>
    /// Saves an error to the shared error log table (A__plant_Error_Save).
    /// Mirrors the behaviour of the legacy Capqwebsite controllers.
    /// </summary>
    /// <remarks>
    /// A__plant_Error_Save.Id has no identity/default/trigger, so it must be supplied
    /// explicitly from the A__plant_Error_Save_SEQ sequence.
    /// </remarks>
    protected void LogErrorToDb(string pageName, string functionName, string errorMessage, bool isWeb = true)
    {
        try
        {
            Db.APlantErrorSaves.Add(new APlantErrorSave
            {
                Id = long.Parse(GetSequencing(ErrorLogSequence, "long")),
                PageName = pageName,
                FunctionName = functionName,
                ErrorMessage = errorMessage,
                Date = DateTime.Now,
                UserIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                IsWeb = isWeb
            });
            Db.SaveChanges();
        }
        catch (Exception)
        {
            // Never let error logging break the request pipeline
        }
    }

    /// <summary>
    /// SQL sequence backing the A__plant_Error_Save.Id column.
    /// </summary>
    protected const string ErrorLogSequence = "A__plant_Error_Save_SEQ";

    /// <summary>
    /// Reads the next value from a SQL Server sequence (mirrors legacy GetSequencing).
    /// </summary>
    protected string GetSequencing(string seqName, string type = "int")
    {
        var dbType = type switch
        {
            "byte" => System.Data.SqlDbType.TinyInt,
            "short" => System.Data.SqlDbType.SmallInt,
            "long" => System.Data.SqlDbType.BigInt,
            _ => System.Data.SqlDbType.Int
        };

        var parameter = new Microsoft.Data.SqlClient.SqlParameter("@result", dbType)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        Db.Database.ExecuteSqlRaw("set @result = next value for dbo." + seqName, parameter);

        return parameter.Value?.ToString() ?? string.Empty;
    }
}
