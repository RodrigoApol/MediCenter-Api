using FluentValidation;
using MediCenter.Application.Commands.ServicesCommands.ServiceCommand.CreateService;
using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Application.Validators.ServicesValidators;

public class ServiceValidator : AbstractValidator<CreateServiceCommand>
{
    public ServiceValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Name must have maximus 50 character.");

        RuleFor(s => s.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(500)
            .WithMessage("Description must have maximus 500 character.");

        RuleFor(s => s.Duration)
            .NotEmpty()
            .NotNull()
            .LessThan(30)
            .WithMessage("The minimum consultation time is 30 minute");

        RuleFor(s => s.Value)
            .NotEmpty()
            .NotNull()
            .WithMessage("Value is required");
    }
}