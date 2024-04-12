using MediatR;
using MediCenter.Core.Entities.ValueObjects;
using MediCenter.Core.Enums;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;

public record CreateDoctorCommand(
    string Name,
    string Surname,
    DateTime BirthDate,
    string Phone,
    string Email,
    string Password,
    string Cpf,
    BloodTypeEnum BloodType,
    Address Address,
    string Specialty,
    string Crm) : IRequest<Guid>;