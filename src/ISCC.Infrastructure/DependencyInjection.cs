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
        services.AddDbContext<ISCCDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ISCCDbContext).Assembly.FullName)));

        // The real, DB-first scaffolded context (311 tables). Registered separately from
        // ISCCDbContext so the connection string always comes from configuration.
        services.AddDbContext<PlantQuarantineDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IInspectionService, InspectionService>();
        services.AddScoped<IEmployerService, EmployerService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
