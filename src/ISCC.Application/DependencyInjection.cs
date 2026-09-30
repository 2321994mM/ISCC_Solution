using Microsoft.Extensions.DependencyInjection;

namespace ISCC.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Intentionally empty for now.
        //
        // AutoMapper is deliberately NOT registered: the only profile mapped the
        // fabricated Client/Employer/Payment/Inspection/Certificate entities, which were
        // removed in Phase 0 because no such tables exist in PlantQuarantine_New.
        // Registering it with zero profiles also throws at startup. Dropping it clears
        // the NU1903 advisory (GHSA-rvv3-g6hj-g44x).
        //
        // FluentValidation is likewise deferred until real request DTOs exist.
        return services;
    }
}