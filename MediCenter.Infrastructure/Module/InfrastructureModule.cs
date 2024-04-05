using MediCenter.Core.Repositories.ServicesRepositories;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using MediCenter.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediCenter.Infrastructure.Module;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service
            .AddContext(configuration)
            .AddRepositories();
        
        return service;
    }
    private static IServiceCollection AddContext(this IServiceCollection service,  IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MediCenterApi");
        
        service.AddDbContext<MediCenterDbContext>(o => 
            o.UseSqlServer(connectionString));

        return service;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IPatientRepository, PatientRepository>();
        service.AddScoped<IDoctorRepository, DoctorRepository>();
        service.AddScoped<IServiceRepository, ServiceRepository>();
        service.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();
        
        return service;
    }
}