namespace MediCenter.Application.Errors;

public sealed record Error(string StatusCode, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}