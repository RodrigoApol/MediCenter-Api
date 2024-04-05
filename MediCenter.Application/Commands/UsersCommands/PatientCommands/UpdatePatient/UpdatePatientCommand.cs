using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Core.Enums;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatient;

public record UpdatePatientCommand(
    Guid Id,
    string Name,
    string Surname,
    DateTime BirthDate,
    string Phone,
    string Email,
    string Cpf,
    BloodTypeEnum BloodType,
    double Weight,
    double Height) : IRequest<Result>;