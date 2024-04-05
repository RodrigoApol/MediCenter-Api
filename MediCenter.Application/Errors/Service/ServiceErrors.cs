namespace MediCenter.Application.Errors.Service;

public static class ServiceErrors
{
    public static Error NotFound(Guid id) => new Error(
        "Service.NotFound", $"The Service with id '{id}' was not found");
}