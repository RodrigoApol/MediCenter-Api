using MediCenter.Core.Entities.Inherited;

namespace MediCenter.Core.Repositories.UsersRepositories;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllAsync();
    Task<Patient?> GetByIdAsync(Guid id);
    Task<Patient?> GetByCpfAsync(string cpf);
    Task<Patient?> GetByPhoneAsync(string phone);
    Task<Patient?> GetByEmailAndPasswordAsync(string email, string passwordHash);
    Task AddAsync(Patient patient);
    Task SaveChangesAsync();
}