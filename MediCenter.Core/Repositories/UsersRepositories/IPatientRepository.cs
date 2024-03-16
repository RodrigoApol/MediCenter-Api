using MediCenter.Core.Entities.Inherited;

namespace MediCenter.Core.Repositories.UsersRepositories;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllAsync();
    Task<Patient?> GetByCpfAsync(string cpf);
    Task<Patient?> GetByPhoneAsync(string phone);
    Task AddAsync(Patient patient);
    Task SaveChangesAsync();
}