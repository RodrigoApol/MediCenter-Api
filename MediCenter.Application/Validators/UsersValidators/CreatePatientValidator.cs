using FluentValidation;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;

namespace MediCenter.Application.Validators.UsersValidators;

public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Name must have maximus 50 character.");

        RuleFor(p => p.Surname)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Surname must have maximus 50 character.");

        RuleFor(p => p.BirthDate)
            .NotEmpty()
            .NotNull()
            .LessThan(DateTime.Now)
            .WithMessage("BirthDate cannot be less than the current date.");

        RuleFor(p => p.Phone)
            .NotEmpty()
            .NotNull()
            .MaximumLength(15)
            .WithMessage("Phone must have maximus 15 character.");

        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Email must have maximus 50 character.");
        
        RuleFor(p => p.Cpf)
            .NotEmpty()
            .NotNull()
            .MaximumLength(15)
            .WithMessage("Cpf must have maximus 15 character.");

        RuleFor(p => p.BloodType)
            .IsInEnum()
            .NotEmpty()
            .NotNull()
            .WithMessage("Blood Type Invalid");
        
        RuleFor(p => p.Weight)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(20.0)
            .WithMessage("Weight cannot be less than 20.0Kg");

        RuleFor(p => p.Height)
            .NotEmpty()
            .NotNull()
            .WithMessage("Height is required");
    }
}