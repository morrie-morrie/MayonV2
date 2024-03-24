using Mayon.Application.Entities.Microsoft.AzureAD;
using Mayon.Application.Entities.Microsoft.Infra.AzureAD;
using Mayon.Application.Services;

namespace Mayon.Application.Microsoft.Graph.Services;
public class MSGraphWriteDB
{
    public static void WriteMSTenantsToDB(IEnumerable<MSTenant> msTenants)
    {
        using var db = new AppDbContext();

        // Fetching all existing tenant IDs from the database
        var existingTenantIds = db.infraMsTenants.Select(t => t.MsTenantCustomerId).ToHashSet();

        foreach (var tenant in msTenants)
        {
            var infraTenant = new InfraMsTenants
            {
                MsTenantCustomerId = tenant.CustomerId,
                MsTenantDisplayName = tenant.DisplayName,
                MsTenantDefaultDomainName = tenant.DefaultDomainName,
                MsTenantContractType = tenant.ContractType,
                MSTenantDeletedDateTime = tenant.DeletedDateTime
            };

            if (existingTenantIds.Contains(infraTenant.MsTenantCustomerId))
            {
                // If tenant exists, update the fields
                var existingTenant = db.infraMsTenants.First(t => t.MsTenantCustomerId == infraTenant.MsTenantCustomerId);

                existingTenant.MsTenantDisplayName = infraTenant.MsTenantDisplayName;
                existingTenant.MsTenantDefaultDomainName = infraTenant.MsTenantDefaultDomainName;
                existingTenant.MsTenantContractType = infraTenant.MsTenantContractType;
                existingTenant.MSTenantDeletedDateTime = infraTenant.MSTenantDeletedDateTime;
            }
            else
            {
                // If tenant does not exist, add new tenant
                db.infraMsTenants.Add(infraTenant);
            }
        }

        // Check for tenants in the database that no longer exist
        var currentTenantIds = msTenants.Select(t => t.CustomerId).ToHashSet();
        var tenantsToRemove = db.infraMsTenants.Where(t => !currentTenantIds.Contains(t.MsTenantCustomerId)).ToList();

        db.infraMsTenants.RemoveRange(tenantsToRemove);

        db.SaveChanges();
    }
}