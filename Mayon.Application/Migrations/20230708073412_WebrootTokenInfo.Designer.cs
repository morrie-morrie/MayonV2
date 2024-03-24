﻿// <auto-generated />
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

#nullable disable

namespace Mayon.Application.Migrations;
[DbContext(typeof(AppDbContext))]
[Migration("20230708073412_WebrootTokenInfo")]
partial class WebrootTokenInfo
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.8")
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

        modelBuilder.Entity("Mayon.Application.Entities.ITGlue.Infra.InfraITGApiAuth", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("ITGToken")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.HasKey("Id");

                b.ToTable("ITGApiAuths");
            });

        modelBuilder.Entity("Mayon.Application.Entities.ITGlue.Infra.InfraITGOrganisations", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasMaxLength(16)
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<DateTime>("CreatedAt")
                    .HasMaxLength(32)
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<int>("OrgId")
                    .HasMaxLength(16)
                    .HasColumnType("int");

                b.Property<int?>("OrganizationStatusId")
                    .HasMaxLength(16)
                    .HasColumnType("int");

                b.Property<string>("OrganizationStatusName")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<int?>("OrganizationTypeId")
                    .HasMaxLength(16)
                    .HasColumnType("int");

                b.Property<string>("OrganizationTypeName")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("QuickNotes")
                    .HasMaxLength(1024)
                    .HasColumnType("nvarchar(1024)");

                b.Property<string>("ShortName")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar(32)");

                b.Property<DateTime>("UpdatedAt")
                    .HasMaxLength(32)
                    .HasColumnType("datetime2");

                b.Property<string>("alert")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("description")
                    .HasMaxLength(1024)
                    .HasColumnType("nvarchar(1024)");

                b.Property<bool>("primary")
                    .HasMaxLength(8)
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("ITGOrganisations");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Microsoft.Infra.AzureAD.InfraMsTenants", b =>
            {
                b.Property<string>("MsTenantCustomerId")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MSTenantDeletedDateTime")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantContractType")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantDefaultDomainName")
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MsTenantDisplayName")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.HasKey("MsTenantCustomerId");

                b.ToTable("infraMsTenants");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Microsoft.Infra.Helper.InfraFriendlySkus", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasMaxLength(10)
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                b.Property<string>("MSSkuDisplayName")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("MSSkuFriendlyName")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("MSSkuGUID")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MSSkuServicePlanId")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("MSSkuServicePlanName")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("MSSkuStringId")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.HasKey("id");

                b.ToTable("InfraFriendlySkus");
            });

        modelBuilder.Entity("Mayon.Application.Entities.Webroot.Infra.DbWebrootTokenInfo", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasMaxLength(8)
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("AccessToken")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<DateTime>("CreatedAt")
                    .HasMaxLength(32)
                    .HasColumnType("datetime2");

                b.Property<int>("ExpiresIn")
                    .HasMaxLength(5)
                    .HasColumnType("int");

                b.Property<string>("RefreshToken")
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnType("nvarchar(64)");

                b.Property<string>("Scope")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("TokenType")
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnType("nvarchar(8)");

                b.Property<DateTime>("UpdatedAt")
                    .HasMaxLength(32)
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("WebrootTokenInfo");
            });
#pragma warning restore 612, 618
    }
}