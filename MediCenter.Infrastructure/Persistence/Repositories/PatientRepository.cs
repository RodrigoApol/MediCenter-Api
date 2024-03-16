using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCenter.Infrastructure.Persistence.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly MediCenterDbContext _dbContext;

    public PatientRepository(MediCenterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Patient>> GetAllAsync()
    {
        return await _dbContext.Patients.ToListAsync();
    }

    public async Task<Patient?> GetByCpfAsync(string cpf)
    {
        return await _dbContext.Patients.SingleOrDefaultAsync(p => p.Cpf == cpf);
    }

    public async Task<Patient?> GetByPhoneAsync(string phone)
    {
        return await _dbContext.Patients.SingleOrDefaultAsync(p => p.Phone == phone);
    }

    public async Task AddAsync(Patient patient)
    {
        await _dbContext.AddAsync(patient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}