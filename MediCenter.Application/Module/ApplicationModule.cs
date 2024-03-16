using MediCenter.Application.Commands.UsersCommands.Patient.CreatePatient;
using MediCenter.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace MediCenter.Application.Module;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service
            .AddMediator()
            .AddMapper();

        return service;
    }
    
    private static IServiceCollection AddMediator(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePatientCommand>());

        return service;
    }
    
    private static IServiceCollection AddMapper(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(DoctorProfile));

        return service;
    }
}