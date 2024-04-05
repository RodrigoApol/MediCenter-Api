namespace MediCenter.Application.Errors.Patient;

public static class PatientErrors
{
    public static Error NotFoundWithId(Guid id) => new(
        "Patient.NotFound", $"The Patient with id '{id} was not found");

    public static Error NotFoundWithCpf(string cpf) => new(
        "Patient.NotFound", $"The Patient with cpf '{cpf} was not found");
    
    public static Error NotFoundWithPhone(string phone) => new(
        "Patient.NotFound", $"The Patient with phone '{phone} was not found");
}