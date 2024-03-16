using MediCenter.Core.Repositories.ServicesRepositories;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using MediCenter.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediCenter.Infrastructure.Module;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service
            .AddContext()
            .AddRepositories();
        
        return service;
    }
    private static IServiceCollection AddContext(this IServiceCollection service)
    {
        service.AddDbContext<MediCenterDbContext>(o => 
            o.UseInMemoryDatabase("MediCenter"));

        return service;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IPatientRepository, PatientRepository>();
        service.AddScoped<IDoctorRepository, DoctorRepository>();
        
        return service;
    }
}