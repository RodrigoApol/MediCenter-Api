using MediCenter.Core.Entities.Inherited.Services;
using MediCenter.Core.Repositories.ServicesRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCenter.Infrastructure.Persistence.Repositories;

public class ServiceRepository(MediCenterDbContext dbContext) : IServiceRepository
{
    private readonly MediCenterDbContext _dbContext = dbContext;
    public async Task<List<Service>> GetAllAsync()
    {
        return await _dbContext.Services.ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Services.SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Service service)
    {
        await _dbContext.Services.AddAsync(service);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}