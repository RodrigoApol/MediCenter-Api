using MediatR;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.CreateService;

public record CreateServiceCommand(
    string Name,
    string Description,
    decimal Value,
    int Duration) : IRequest<Guid>;