using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.UpdateService;

public record UpdateServiceCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Value,
    int Duration) : IRequest<Result>;