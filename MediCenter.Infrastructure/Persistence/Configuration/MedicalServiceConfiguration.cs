using MediCenter.Core.Entities.Inherited.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public class MedicalServiceConfiguration : IEntityTypeConfiguration<MedicalService>
{
    public void Configure(EntityTypeBuilder<MedicalService> builder)
    {
        builder
            .HasKey(ms => ms.Id);

        builder
            .HasOne(ms => ms.Doctor)
            .WithMany()
            .HasForeignKey(ms => ms.IdDoctor)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ms => ms.Patient)
            .WithMany()
            .HasForeignKey(ms => ms.IdPatient)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ms => ms.Service)
            .WithMany()
            .HasForeignKey(ms => ms.IdService)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(ms => ms.HealthInsurance)
            .HasMaxLength(50);
    }
}