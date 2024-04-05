using FluentValidation;
using FluentValidation.Validators;
using MediCenter.Core.Entities.ValueObjects;

namespace MediCenter.Application.Validators.UsersValidators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.State)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("State must have maximus 50 character.");

        RuleFor(a => a.City)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("City must have maximus 50 character.");

        RuleFor(a => a.Street)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .WithMessage("Street must have maximus 50 character.");

        RuleFor(a => a.PostalCode)
            .NotEmpty()
            .NotNull()
            .MaximumLength(10)
            .WithMessage("PostalCode must have maximus 10 character.");
    }
}