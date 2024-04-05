using FluentValidation;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;
using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Application.Validators.ServicesValidators;

public class MedicalServiceValidator : AbstractValidator<CreateMedicalServiceCommand>
{
    public MedicalServiceValidator()
    {
        RuleFor(ms => ms.ServiceId)
            .NotEmpty()
            .NotNull()
            .WithMessage("IdService is required.");
        
        RuleFor(ms => ms.DoctorId)
            .NotEmpty()
            .NotNull()
            .WithMessage("IdDoctor is required.");
        
        RuleFor(ms => ms.PatientId)
            .NotEmpty()
            .NotNull()
            .WithMessage("IdPatient is required.");
        
        if (RuleFor(ms => ms.HealthInsurance) != null)
        {
            RuleFor(ms => ms.HealthInsurance)
                .MaximumLength(50)
                .WithMessage("HealthInsurance must have maximus 50 character.");
        }
    }
}