using MediatR;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;

public record CreateMedicalServiceCommand : IRequest<Guid>
{
    public Guid IdService { get; set; }
    public Guid IdPatient { get; set; }
    public Guid IdDoctor { get; set; }
    public string? HealthInsurance { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime FinishAt { get; set; }
    public string MedicalServiceType { get; set; } = string.Empty;
}