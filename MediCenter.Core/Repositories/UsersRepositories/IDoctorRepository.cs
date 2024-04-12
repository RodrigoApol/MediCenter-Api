using MediCenter.Core.Entities.Inherited;

namespace MediCenter.Core.Repositories.UsersRepositories;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllAsync();
    Task<Doctor?> GetByIdAsync(Guid id);
    Task<Doctor?> GetByEmailAndPasswordAsync(string email, string passwordHash);
    Task AddAsync(Doctor doctor);
    Task SaveChangesAsync();
}