using MediCenter.Core.Entities.Inherited;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public class DoctorConfiguration : UserBaseConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(d => d.Specialty)
            .HasMaxLength(30)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder
            .Property(d => d.Crm)
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .IsRequired();
    }
}
