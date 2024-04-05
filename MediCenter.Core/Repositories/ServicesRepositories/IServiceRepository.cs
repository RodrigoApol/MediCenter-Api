using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Core.Repositories.ServicesRepositories;

public interface IServiceRepository
{
    Task<List<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(Guid id);
    Task AddAsync(Service service);
    Task SaveChangesAsync();
}