using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.DeletePatient;

public record DeletePatientCommand(Guid Id) : IRequest<Result>;