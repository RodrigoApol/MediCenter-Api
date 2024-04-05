using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.UpdateMedicalService;

public record UpdateMedicalServiceCommand(
    Guid Id,
    DateTime StartedAt,
    DateTime FinishAt) : IRequest<Result>;
