using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Entities.ITGlue.Infra;
using Mayon.Application.Entities.Microsoft.Infra.AzureAD;
using Mayon.Application.Entities.Microsoft.Infra.Exchange;
using Mayon.Application.Entities.Microsoft.Infra.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mayon.Application.Services;
public class AppDbContext : DbContext
{
    public DbSet<DuoCustomers> DuoCustomers { get; set; }

    public DbSet<AdminMsApiAuth> adminMsApiAuths { get; set; }
    public DbSet<InfraMsTenants> infraMsTenants { get; set; }
    public DbSet<InfraMsExchangeMailbox> InfraMsExchangeMailboxes { get; set; } // Added DbSet for InfraMsExchangeMailbox
    public DbSet<InfraFriendlySkus> InfraFriendlySkus { get; set; }
    public DbSet<InfraITGApiAuth> ITGApiAuths { get; set; }
    public DbSet<InfraITGOrganisations> ITGOrganisations { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigService.Configuration.GetConnectionString("Default"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define the foreign key relationship in the model builder if not using data annotations
        modelBuilder.Entity<InfraMsExchangeMailbox>()
                    .HasOne(m => m.Tenant)
                    .WithMany()
                    .HasForeignKey(m => m.MsTenantCustomerId);
    }
}