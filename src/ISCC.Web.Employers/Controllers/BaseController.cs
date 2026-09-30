using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace ISCC.Web.Employers.Controllers;

/// <summary>
/// Base controller for all portal controllers.
/// Provides localization and shared error logging so controllers don't repeat boilerplate.
/// </summary>
public abstract class BaseController : Controller
{
    private readonly IStringLocalizer _localizer;

    protected IStringLocalizer L => _localizer;

    protected BaseController(IStringLocalizer<BaseController> localizer)
    {
        _localizer = localizer;
    }

    /// <summary>
    /// Saves an error to the shared error log table (A__plant_Error_Save).
    /// Mirrors the behaviour of the legacy Capqwebsite controllers.
    /// </summary>
    protected void LogErrorToDb(string pageName, string functionName, string errorMessage, bool isWeb = true)
    {
        try
        {
            var context = HttpContext.RequestServices.GetRequiredService<Infrastructure.Data.PlantQuarantineDbContext>();
            var log = new Infrastructure.Data.Generated.APlantErrorSave
            {
                PageName = pageName,
                FunctionName = functionName,
                ErrorMessage = errorMessage,
                Date = DateTime.Now,
                UserIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                IsWeb = isWeb
            };
            context.APlantErrorSaves.Add(log);
            context.SaveChanges();
        }
        catch (Exception)
        {
            // Never let error logging break the request pipeline
        }
    }

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

        var context = HttpContext.RequestServices.GetRequiredService<Infrastructure.Data.PlantQuarantineDbContext>();
        context.Database.ExecuteSqlRaw("set @result = next value for dbo." + seqName, parameter);

        return parameter.Value?.ToString() ?? string.Empty;
    }
}