using ISCC.Application.Cms;
using ISCC.Application.ReferenceData;
using ISCC.Application.TradeProcedures;
using ISCC.Domain.Interfaces;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Repositories;
using ISCC.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISCC.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Single context for the whole solution. PlantQuarantineDbContext is the
        // database-first scaffold of PlantQuarantine_New (311 tables, 14 views) and is
        // a verified superset of the legacy AgricultureDBContext (300 tables, 11 views).
        services.AddDbContext<PlantQuarantineDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICmsContentService, CmsContentService>();
        services.AddScoped<IReferenceDataService, ReferenceDataService>();
        services.AddScoped<ITradeProcedureService, TradeProcedureService>();

        return services;
    }
}