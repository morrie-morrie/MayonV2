﻿// <auto-generated />
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mayon.Application.Migrations;
[DbContext(typeof(AppDbContext))]
[Migration("20230617105705_Adding")]
partial class Adding
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.7")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("Mayon.Application.Entities.Duo.Infra.AdminMsApiAuth", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("MsClientId")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsClientSecret")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsRefreshToken")
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnType("nvarchar(1024)");

                b.Property<string>("MsTenantId")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.HasKey("Id");

                b.ToTable("adminMsApiAuths");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Duo.Infra.DuoApiAuth", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("ApiHostname")
                    .IsRequired()
                    .HasMaxLength(96)
                    .HasColumnType("nvarchar(96)");

                b.Property<string>("IntegrationKey")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("SecretKey")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.HasKey("Id");

                b.ToTable("DuoApiAuths");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Duo.Infra.DuoCustomers", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasMaxLength(32)
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("DuoAccountId")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar(32)");

                b.Property<string>("DuoApiHostname")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("DuoCustomerName")
                    .IsRequired()
                    .HasMaxLength(96)
                    .HasColumnType("nvarchar(96)");

                b.HasKey("Id");

                b.ToTable("DuoCustomers");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Microsoft.Infra.AzureAD.InfraMsTenants", b =>
            {
                b.Property<string>("MsTenantCustomerId")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MSTenantDeletedDateTime")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantContractType")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantDefaultDomainName")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantDisplayName")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.HasKey("MsTenantCustomerId");

                b.ToTable("infraMsTenants");
            });
#pragma warning restore 612, 618
    }
}
