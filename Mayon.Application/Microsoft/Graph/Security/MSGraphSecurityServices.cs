using Mayon.Application.Entities.Microsoft.Security;
using Mayon.Application.Microsoft.Graph.Services;

namespace Mayon.Application.Microsoft.Graph.Security;
public class MSGraphSecurityServices
{
    private const string baseGraph = "https://graph.microsoft.com";

    public static IEnumerable<MsTenantCAPolicy> GetMSTenantsCAPolicy(string tenantId)
    {
        var token = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId);
        var msTenantCAPolicies = MSGraphAPI.ExecuteAndDeserialize<MsTenantCAPolicies>(baseGraph, $"/beta/identity/conditionalAccess/policies", token);
        return msTenantCAPolicies.Value;
    }
}