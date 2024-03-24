using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Entities.Microsoft.Auth;
using Mayon.Application.Entities.Microsoft.AzureAD;
using Mayon.Application.Entities.Microsoft.Security;
using Mayon.Application.Microsoft.Graph.AzureAD;
using Mayon.Application.Microsoft.Graph.Helper;
using Mayon.Application.Microsoft.Graph.Security;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace Mayon.Application.Microsoft.Graph.Services;
public class MSGraphAPI
{
    public static string GetToken(string tenantId)
    {
        Log.Information($"Getting MS Graph Rest Token for {tenantId}");
        AdminMsApiAuth? msAuthCreds = MSGraphHelper.GetMSAuthCreds();
        if (msAuthCreds == null)
        {
            throw new Exception("No MS Auth Creds found");
        }

        var options = new RestClientOptions("https://login.microsoftonline.com")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest($"{tenantId}/oauth2/v2.0/token", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("client_id", $"{msAuthCreds.MsClientId}");
        request.AddParameter("client_secret", $"{msAuthCreds.MsClientSecret}");
        request.AddParameter("scope", "https://graph.microsoft.com/.default");
        request.AddParameter("grant_type", "client_credentials");
        RestResponse response = client.Execute(request);

        var token = JsonConvert.DeserializeObject<MSPartnerToken>(response?.Content ?? string.Empty);
        return token?.access_token ?? string.Empty;
    }

    public static string GetTPMSGraphRestToken()
    {
        AdminMsApiAuth? adminMsApiAuth = MSGraphHelper.GetMSAuthCreds();
        return GetToken(adminMsApiAuth.MsTenantId);
    }

    public static string GetTenantsMSGraphRestToken(string tenantId)
    {
        return GetToken(tenantId);
    }

    public static RestClient CreateRestClient(string baseUrl)
    {
        var options = new RestClientOptions($"{baseUrl}")
        {
            MaxTimeout = -1,
        };
        return new RestClient(options);
    }

    public static RestResponse ExecuteRequest(RestClient client, RestRequest request, string token)
    {
        request.AddHeader("Authorization", $"Bearer {token}");
        return client.Execute(request);
    }

    public static T ExecuteAndDeserialize<T>(string baseUrl, string url, string token)
    {
        var client = CreateRestClient(baseUrl);
        var request = new RestRequest(url, Method.Get);
        var response = ExecuteRequest(client, request, token);
        if (response.Content != null)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        else
        {
            throw new Exception("Response content is null");
        }
    }

    public static void ProcessAllMSTenantsOrganisations()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();
        MSGraphWriteDB.WriteMSTenantsToDB(msTenants);
        List<MsTenantOrganisation> allMsTenantOrganisations = new List<MsTenantOrganisation>();

        foreach (MSTenant tenant in msTenants)
        {
            IEnumerable<MsTenantOrganisation> msTenantOrganisations = MSGraphADServices.GetMSTenantsOrganisations(tenant.CustomerId);
            if (msTenantOrganisations != null)
            {
                foreach (MsTenantOrganisation msTenantOrganisation in msTenantOrganisations)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"TenantName: {msTenantOrganisation.displayName}");
                    Console.ResetColor();
                    Console.WriteLine($"TenantDomain: {msTenantOrganisation.verifiedDomains[0].name}");
                    foreach (var domain in msTenantOrganisation.verifiedDomains)
                    {
                        Console.WriteLine($"TenantDomain: {domain.name}");
                        Console.WriteLine($"Capabilties: {domain.capabilities}");
                    }
                    Console.WriteLine($"TenantCountry: {msTenantOrganisation.defaultUsageLocation}");
                    Console.WriteLine($"Is ADConnect Sync Enabled: {msTenantOrganisation.onPremisesSyncEnabled}");
                    Console.WriteLine($"Last ADConnect Sync: {msTenantOrganisation.onPremisesLastSyncDateTime}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no organisations");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }

    public static void ProcessAllMSTenantsUsers()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();
        foreach (MSTenant tenant in msTenants)
        {
            IEnumerable<MsTenantUser> msTenantUsers = MSGraphADServices.GetMSTenantsUsers(tenant.CustomerId);
            if (msTenantUsers != null && msTenantUsers.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"TenantName: {tenant.DisplayName}");
                Console.ResetColor();

                foreach (MsTenantUser msTenantUser in msTenantUsers)
                {
                    Console.WriteLine($"Users Displayname: {msTenantUser.displayName}");
                    Console.WriteLine($"Users Id: {msTenantUser.id}");
                    Console.WriteLine($"Users UserPrincipalName: {msTenantUser.userPrincipalName}");
                    Console.WriteLine($"Users Mail: {msTenantUser.mail}");
                    Console.WriteLine($"First Name: {msTenantUser.givenName}");
                    Console.WriteLine($"Last Name: {msTenantUser.surname}");
                    Console.WriteLine($"Job Title: {msTenantUser.jobTitle}");
                    Console.WriteLine($"Mobile Phone: {msTenantUser.mobilePhone}");
                    Console.WriteLine($"Office Location: {msTenantUser.officeLocation}");
                    Console.WriteLine($"Preferred Language: {msTenantUser.preferredLanguage}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no users");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }

    public static void ProcessAllMSTenantsLicenses()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();

        foreach (MSTenant tenant in msTenants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TenantName: {tenant.DisplayName}");
            Console.ResetColor();

            IEnumerable<MsTenantLicense> msTenantLicenses = MSGraphADServices.GetMSTenantsLicenses(tenant.CustomerId);
            if (msTenantLicenses != null)
            {
                foreach (MsTenantLicense msTenantLicense in msTenantLicenses)
                {
                    Console.WriteLine($"License Part Number: {msTenantLicense.skuPartNumber}");
                    Console.WriteLine($"License ID: {msTenantLicense.skuId}");
                    Console.WriteLine($"Licenses Bought: {msTenantLicense.prepaidUnits.enabled}");
                    Console.WriteLine($"Licenses Used: {msTenantLicense.consumedUnits}");
                    Console.WriteLine($"License Capabilities: {msTenantLicense.capabilityStatus}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no organisations");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }

    public static void ProcessAllMSTenantsRiskyUsers()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();
        foreach (MSTenant tenant in msTenants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TenantName: {tenant.DisplayName}");
            Console.ResetColor();

            IEnumerable<MsTenantRiskyUser> msTenantRiskyUsers = MSGraphADServices.GetMSTenantsRiskyUsers(tenant.CustomerId);
            if (msTenantRiskyUsers != null && msTenantRiskyUsers.Any())
            {
                foreach (MsTenantRiskyUser msTenantRiskyUser in msTenantRiskyUsers)
                {
                    Console.WriteLine($"Risky User: {msTenantRiskyUser.userDisplayName}");
                    Console.WriteLine($"User Principal: {msTenantRiskyUser.userPrincipalName}");
                    Console.WriteLine($"IP Address: {msTenantRiskyUser.ipAddress}");
                    Console.WriteLine($"Source: {msTenantRiskyUser.source}");
                    Console.WriteLine($"Activity: {msTenantRiskyUser.activity}");
                    Console.WriteLine($"Activity Timing Type: {msTenantRiskyUser.detectionTimingType}");
                    Console.WriteLine($"Risk Type: {msTenantRiskyUser.riskType}");
                    Console.WriteLine($"Risk Event Type: {msTenantRiskyUser.riskEventType}");
                    Console.WriteLine($"Risk Level: {msTenantRiskyUser.riskLevel}");
                    Console.WriteLine($"Risk State: {msTenantRiskyUser.riskState}");
                    Console.WriteLine($"Risk Detail: {msTenantRiskyUser.riskDetail}");
                    Console.WriteLine($"Additional Info: {msTenantRiskyUser.additionalInfo}");
                    Console.WriteLine($"Activity Time: {msTenantRiskyUser.activityDateTime}");
                    Console.WriteLine($"Detected Time: {msTenantRiskyUser.detectedDateTime}");
                    Console.WriteLine($"Last Updated: {msTenantRiskyUser.lastUpdatedDateTime}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no Risky Users");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }

    public static void ProcessAllMSTenantsCAPolicies()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();
        foreach (MSTenant tenant in msTenants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TenantName: {tenant.DisplayName}");
            Console.ResetColor();

            IEnumerable<MsTenantCAPolicy> msTenantCAPolicies = MSGraphSecurityServices.GetMSTenantsCAPolicy(tenant.CustomerId);
            if (msTenantCAPolicies != null && msTenantCAPolicies.Any())
            {
                foreach (MsTenantCAPolicy msTenantCAPolicy in msTenantCAPolicies)
                {
                    Console.WriteLine($"Policy Name: {msTenantCAPolicy.displayName}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no Conditional Access Policies");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}