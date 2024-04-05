using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Core.Repositories.ServicesRepositories;

public interface IMedicalServiceRepository
{
    Task<List<MedicalService>> GetAllAsync();
    Task<MedicalService?> GetByIdAsync(Guid id);
    Task AddAsync(MedicalService medicalService);
    Task SaveChangesAsync();
}