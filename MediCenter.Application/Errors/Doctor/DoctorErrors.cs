namespace MediCenter.Application.Errors.Doctor;

public static class DoctorErrors
{
    public static Error NotFound(Guid id) => new(
        "Doctor.NotFound", $"The Doctor with '{id}' was not found");
}