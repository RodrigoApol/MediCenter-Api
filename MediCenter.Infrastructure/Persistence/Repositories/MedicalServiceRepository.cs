using MediCenter.Core.Entities.Inherited.Services;
using MediCenter.Core.Repositories.ServicesRepositories;
using MediCenter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCenter.Infrastructure.Persistence.Repositories;

public class MedicalServiceRepository : IMedicalServiceRepository
{
    private readonly MediCenterDbContext _dbContext;

    public MedicalServiceRepository(MediCenterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<MedicalService>> GetAllAsync()
    {
        return await _dbContext.MedicalServices.ToListAsync();
    }

    public async Task<MedicalService?> GetByIdAsync(Guid id)
    {
        return await _dbContext.MedicalServices
            .Include(m => m.Service.Name)
            .Include(m => m.Doctor.Name)
            .Include(m => m.Patient.Name)
            .SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(MedicalService medicalService)
    {
        var doctor = await _dbContext.Doctors.SingleOrDefaultAsync(d => d.Id == medicalService.IdDoctor)
                     ?? throw new ArgumentException("Doctor is null");
        var patient = await _dbContext.Patients.SingleOrDefaultAsync(p => p.Id == medicalService.IdPatient)
                      ?? throw new ArgumentException("Patient is null");
        var service = await _dbContext.Services.SingleOrDefaultAsync(s => s.Id == medicalService.IdService)
                      ?? throw new ArgumentException("Service is null");

        await _dbContext.MedicalServices.AddAsync(medicalService);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}