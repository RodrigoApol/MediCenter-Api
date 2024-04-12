using FluentValidation;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;
using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Application.Validators.ServicesValidators;

public class MedicalServiceValidator : AbstractValidator<CreateMedicalServiceCommand>
{
    public MedicalServiceValidator()
    {
        RuleFor(ms => ms.IdService)
            .NotEmpty()
            .NotNull()
            .WithMessage("IdService is required.");
        
        RuleFor(ms => ms.IdDoctor)
            .NotEmpty()
            .NotNull()
            .WithMessage("IdDoctor is required.");
        
        RuleFor(ms => ms.IdPatient)
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