using MediCenter.Core.Entities.Base;
using MediCenter.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediCenter.Infrastructure.Persistence.Configuration;

public abstract class UserBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : UserBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Name)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(u => u.Surname)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(u => u.BirthDate)
            .IsRequired();

        builder
            .Property(u => u.Phone)
            .HasMaxLength(15)
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(u => u.Cpf)
            .HasMaxLength(15)
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder
            .Property(u => u.BloodType)
            .HasConversion(new EnumToStringConverter<BloodTypeEnum>())
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder
            .OwnsOne(u => u.Address,
                address =>
                {
                    address
                        .Property(a => a.State)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();

                    address
                        .Property(a => a.City)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();

                    address
                        .Property(a => a.Street)
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .IsRequired();

                    address
                        .Property(a => a.PostalCode)
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .IsRequired();
                });

    }
}