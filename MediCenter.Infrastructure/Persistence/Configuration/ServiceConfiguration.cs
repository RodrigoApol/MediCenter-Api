using MediCenter.Core.Entities.Inherited.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(s => s.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(s => s.Value)
            .IsRequired();

        builder
            .Property(s => s.Duration)
            .IsRequired();
    }
}