using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCenter.Infrastructure.Persistence.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly MediCenterDbContext _dbContext;

    public DoctorRepository(MediCenterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Doctors.SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}