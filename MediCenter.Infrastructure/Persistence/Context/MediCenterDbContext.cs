using System.Reflection;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Entities.Inherited.Services;
using Microsoft.EntityFrameworkCore;

namespace MediCenter.Infrastructure.Persistence.Context;

public class MediCenterDbContext : DbContext
{
    public MediCenterDbContext(DbContextOptions<MediCenterDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<MedicalService> MedicalServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()));
    }
}