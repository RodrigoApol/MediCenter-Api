using FluentValidation;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;

namespace MediCenter.Application.Validators.UsersValidators;

public class CreateDoctorValidator :  AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorValidator()
    {
        RuleFor(d => d.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Name must have maximus 50 character.");

        RuleFor(d => d.Surname)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Surname must have maximus 50 character.");

        RuleFor(d => d.BirthDate)
            .NotEmpty()
            .NotNull()
            .LessThan(DateTime.Now)
            .WithMessage("BirthDate cannot be less than the current date.");

        RuleFor(d => d.Phone)
            .NotEmpty()
            .NotNull()
            .MaximumLength(15)
            .WithMessage("Phone must have maximus 15 character.");

        RuleFor(d => d.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Email must have maximus 50 character.");
        
        RuleFor(d => d.Cpf)
            .NotEmpty()
            .NotNull()
            .MaximumLength(15)
            .WithMessage("Cpf must have maximus 15 character.");

        RuleFor(d => d.BloodType)
            .IsInEnum()
            .NotEmpty()
            .NotNull()
            .WithMessage("Blood Type Invalid");
        
        RuleFor(d => d.Specialty)
            .NotEmpty()
            .NotNull()
            .MaximumLength(30)
            .WithMessage("Specialty must have maximus 30 character.");

        RuleFor(d => d.Crm)
            .NotEmpty()
            .NotNull()
            .MaximumLength(10)
            .WithMessage("CRM must have maximus 10 character.");
    }
}