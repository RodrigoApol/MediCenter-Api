namespace MediCenter.Application.Errors.Login;

public static class LoginError
{
    public static Error NotFound(string email)
        => new("User.NotFound", $"The user with email: {email} was not found");
}