using Mayon.Application.Entities.Microsoft.AzureAD;
using Mayon.Application.Microsoft.Graph.Services;
using System.Collections.Concurrent;

namespace Mayon.Application.Microsoft.Graph.AzureAD;
public static class TokenCache
{
    private static readonly ConcurrentDictionary<string, (string token, DateTime expiry)> _cache = new ConcurrentDictionary<string, (string, DateTime)>();

    public static string GetToken(string tenantId)
    {
        if (_cache.TryGetValue(tenantId, out var cachedToken) && cachedToken.expiry > DateTime.UtcNow)
        {
            return cachedToken.token;
        }

        var newToken = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId); // Assume this is the synchronous method to get a token
        var expiryTime = DateTime.UtcNow.AddHours(1); // Assuming token is valid for 1 hour
        _cache[tenantId] = (newToken, expiryTime);

        return newToken;
    }
}

public static class MSGraphADServices
{
    private const string baseGraph = "https://graph.microsoft.com";

    public static IEnumerable<MSTenant> GetMSTenants()
    {
        var token = MSGraphAPI.GetTPMSGraphRestToken();
        var msTenants = MSGraphAPI.ExecuteAndDeserialize<MSTenants>(baseGraph, "/beta/contracts?top=999", token);
        return msTenants?.Value ?? new List<MSTenant>();
    }

    public static IEnumerable<MsTenantLicense> GetMSTenantsLicenses(string tenantId)
    {
        var token = TokenCache.GetToken(tenantId); // Synchronous call
        var msTenantLicenses = MSGraphAPI.ExecuteAndDeserialize<MsTenantLicenses>(baseGraph, $"/beta/subscribedSkus", token);
        return msTenantLicenses.Value;
    }

    public static IEnumerable<MsTenantOrganisation> GetMSTenantsOrganisations(string tenantId)
    {
        var token = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId);
        var msTenantOrganisations = MSGraphAPI.ExecuteAndDeserialize<MsTenantOrganisations>(baseGraph, "/beta/organization", token);
        return msTenantOrganisations.Value;
    }

    public static IEnumerable<MsTenantRiskyUser> GetMSTenantsRiskyUsers(string tenantId)
    {
        var token = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId);
        var msTenantRiskyUsers = MSGraphAPI.ExecuteAndDeserialize<MsTenantRiskyUsers>(baseGraph, $"/beta/riskDetections", token);
        return msTenantRiskyUsers.Value;
    }

    public static IEnumerable<MsTenantUser> GetMSTenantsUsers(string tenantId)
    {
        var token = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId);
        var msTenantUsers = MSGraphAPI.ExecuteAndDeserialize<MsTenantUsers>(baseGraph, $"/v1.0/Users?$Top=999", token);
        return msTenantUsers.Value;
    }
}