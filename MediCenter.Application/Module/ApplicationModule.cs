using FluentValidation;
using FluentValidation.AspNetCore;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;
using MediCenter.Application.Profiles;
using MediCenter.Application.Validators.UsersValidators;
using MediCenter.Core.Entities.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MediCenter.Application.Module;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service
            .AddMediator()
            .AddMapper()
            .AddValidators();

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

    private static IServiceCollection AddValidators(this IServiceCollection service)
    {
        service.AddValidatorsFromAssemblyContaining<CreateDoctorCommand>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        return service;
    }
}