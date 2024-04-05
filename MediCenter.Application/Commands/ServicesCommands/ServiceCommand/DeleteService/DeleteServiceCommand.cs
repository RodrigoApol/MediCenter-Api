using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.DeleteService;

public record DeleteServiceCommand(Guid Id) : IRequest<Result>;