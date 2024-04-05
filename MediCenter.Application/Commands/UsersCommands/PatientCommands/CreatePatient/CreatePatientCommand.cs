using MediatR;
using MediCenter.Core.Entities.ValueObjects;
using MediCenter.Core.Enums;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;

public record CreatePatientCommand(
    string Name,
    string Surname,
    DateTime BirthDate,
    string Phone,
    string Email,
    string Cpf,
    BloodTypeEnum BloodType,
    Address Address,
    double Weight,
    double Height) : IRequest<Guid>;