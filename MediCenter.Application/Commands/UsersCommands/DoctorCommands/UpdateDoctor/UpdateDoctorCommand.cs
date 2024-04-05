using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Core.Enums;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctor;

public record UpdateDoctorCommand(
    Guid Id,
    string Name,
    string Surname,
    DateTime BirthDate,
    string Phone,
    string Email,
    string Cpf,
    BloodTypeEnum BloodType,
    string Specialty,
    string Crm) : IRequest<Result>;