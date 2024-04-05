using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Core.Entities.ValueObjects;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatientAddress;

public record UpdatePatientAddressCommand(
    Guid Id,
    Address Address
) : IRequest<Result>;