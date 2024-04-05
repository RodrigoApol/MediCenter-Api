using MediCenter.Core.Entities.Inherited;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public class PatientConfiguration : UserBaseConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Weight)
            .HasColumnType("numeric(6, 2)")
            .IsRequired();

        builder
            .Property(p => p.Height)
            .HasColumnType("numeric(3, 2)")
            .IsRequired();
    }
}