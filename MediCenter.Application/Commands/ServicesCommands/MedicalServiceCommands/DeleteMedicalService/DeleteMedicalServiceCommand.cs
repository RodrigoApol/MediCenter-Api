using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.DeleteMedicalService;

public record DeleteMedicalServiceCommand(Guid Id) : IRequest<Result>;