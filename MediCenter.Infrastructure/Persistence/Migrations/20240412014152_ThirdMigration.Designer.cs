﻿// <auto-generated />
using System;
using MediCenter.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediCenter.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MediCenterDbContext))]
    [Migration("20240412014152_ThirdMigration")]
    partial class ThirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric(3, 2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric(6, 2)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Services.MedicalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinishAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HealthInsurance")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPatient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdService")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MedicalServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.HasIndex("IdService");

                    b.ToTable("MedicalServices");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Services.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Doctor", b =>
                {
                    b.OwnsOne("MediCenter.Core.Entities.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Patient", b =>
                {
                    b.OwnsOne("MediCenter.Core.Entities.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Services.MedicalService", b =>
                {
                    b.HasOne("MediCenter.Core.Entities.Inherited.Doctor", "Doctor")
                        .WithMany("MedicalServices")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MediCenter.Core.Entities.Inherited.Patient", "Patient")
                        .WithMany("MedicalServices")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MediCenter.Core.Entities.Inherited.Services.Service", "Service")
                        .WithMany("MedicalServices")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Doctor", b =>
                {
                    b.Navigation("MedicalServices");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Patient", b =>
                {
                    b.Navigation("MedicalServices");
                });

            modelBuilder.Entity("MediCenter.Core.Entities.Inherited.Services.Service", b =>
                {
                    b.Navigation("MedicalServices");
                });
#pragma warning restore 612, 618
        }
    }
}
