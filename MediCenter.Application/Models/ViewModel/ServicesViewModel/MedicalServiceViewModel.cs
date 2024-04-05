namespace MediCenter.Application.Models.ViewModel.ServicesViewModel;

public record MedicalServiceViewModel(
    string ServiceName,
    string DoctorFullName,
    string PatientFullName,
    string? HealthInsurance,
    string StartedAt,
    string FinishAt,
    string MedicalServiceType);