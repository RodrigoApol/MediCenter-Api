using MediCenter.Core.Entities.Inherited;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public class PatientConfiguration : UserBaseConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Weight)
            .IsRequired();

        builder
            .Property(p => p.Height)
            .IsRequired();
    }
}