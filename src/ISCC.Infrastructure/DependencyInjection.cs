using ISCC.Application.Auth;
using ISCC.Application.Menu;
using ISCC.Application.ReferenceData;
using ISCC.Domain.Abstraction.IRepository;
using ISCC.Infrastructure.Auth;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Privilage;
using ISCC.Infrastructure.Menu;
using ISCC.Infrastructure.ReferenceData;
using ISCC.Infrastructure.Repositories;
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

        // dbPrivilage, the second database. Separate context rather than more DbSets on
        // PlantQuarantineDbContext: EF cannot join across two contexts, and the auth
        // tables must not share migrations with the 298 business tables.
        //
        // It was documented here as registered when it was not — the class existed and its
        // own XML comment claimed DI wiring, but nothing ever added it. Any service taking
        // PrivilageDbContext would have failed at startup.
        services.AddDbContext<PrivilageDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PrivilegeConnection")));

        // Application-layer feature services (CMS content, trade procedures, dashboard)
        // were removed along with the Phase 2 controllers they backed. Register each one
        // here when its controller is ported.
        //
        // Reference data (Phase 3.1) is live. It is the first ported feature and the
        // reference pattern for the rest: the contract sits in ISCC.Application under
        // <Feature>/ with Dtos/ beside it, the EF implementation sits here, and the
        // controller in the host consumes only the contract.
        services.AddScoped<IReferenceDataService, ReferenceDataService>();

        // Authentication (Phase 3.2). Spans both databases: PR_User from dbPrivilage,
        // Outlet from PlantQuarantine_New.
        services.Configure<AuthOptions>(configuration.GetSection(AuthOptions.SectionName));
        services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

        // Navigation (Phase 3.3). Read-only over dbPrivilage's RBAC tables. Replaces the
        // three legacy menu stored procedures and the per-node Html.Action fan-out that
        // called them, which cost one round trip per menu node on every page view.
        services.AddScoped<IMenuService, MenuService>();

        return services;
    }
}