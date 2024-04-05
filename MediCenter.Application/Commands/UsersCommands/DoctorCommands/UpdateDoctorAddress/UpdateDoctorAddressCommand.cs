using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Core.Entities.ValueObjects;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctorAddress;

public record UpdateDoctorAddressCommand(Guid Id, Address Address) : IRequest<Result>;