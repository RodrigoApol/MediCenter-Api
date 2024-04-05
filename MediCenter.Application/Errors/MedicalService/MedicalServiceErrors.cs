namespace MediCenter.Application.Errors.MedicalService;

public static class MedicalServiceErrors
{
    public static Error NotFound(Guid id) => new(
        "MedicalService.NotFound", $"The Medical Service with id '{id}' was not found");
}