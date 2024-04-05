using MediCenter.Core.Entities.Base;

namespace MediCenter.Core.Entities.Inherited.Services;

public class MedicalService : ServicesBase
{
    protected MedicalService()
    {
        
    }
    
    public MedicalService(Guid idPatient, Guid idDoctor, Guid idService, string? healthInsurance, DateTime startedAt,
        DateTime finishAt, string medicalServiceType)
    {
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        IdService = idService;
        HealthInsurance = healthInsurance ?? null;
        StartedAt = startedAt;
        FinishAt = finishAt;
        MedicalServiceType = medicalServiceType;
    }

    public Guid IdPatient { get; private set; }
    public Guid IdDoctor { get; private set; }
    public Guid IdService { get; private set; }
    public string? HealthInsurance { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public string MedicalServiceType { get; private set; }
    public Patient Patient { get; private set; }
    public Doctor Doctor { get; private set; }
    public Service Service { get; private set; }

    public void UpdateMedicalService(DateTime startedAt, DateTime finishAt)
    {
        StartedAt = startedAt;
        FinishAt = finishAt;
    }
}