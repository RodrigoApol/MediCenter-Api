using MediCenter.Core.Entities.Base;

namespace MediCenter.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(UserBase user);
    string ComputeSha256Hash(string password);
}