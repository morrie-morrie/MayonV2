using Mayon.Application.Entities.Microsoft.AzureAD;
using Mayon.Application.Entities.Microsoft.Exchange;
using Mayon.Application.Microsoft.Graph.AzureAD;
using Mayon.Application.Microsoft.Graph.Services;
using Serilog;

namespace Mayon.Application.Microsoft.Graph.ExchangeOnline;

internal static class MSGraphExchServices
{
    private const string baseExchangeGraph = "https://outlook.office365.com";

    public static List<MsExchangeMailbox> GetMSExchangeMailboxes(string tenantId)
    {
        Log.Logger.Information("Getting MS Exchange Mailboxes for tenantId: {tenantId}", tenantId);
        var tenantToken = MSGraphAPI.GetTenantsMSGraphRestToken(tenantId);
        var exchangeAccessToken = MSGraphExchangeAuth.GetExchangeAccessToken(tenantToken, tenantId);
        if (exchangeAccessToken == null || string.IsNullOrEmpty(exchangeAccessToken.ToString()))
        {
            Log.Logger.Warning("exchangeAccessToken is null");
            return new List<MsExchangeMailbox>();
        }
        var msExchangeMailboxes = MSGraphAPI.ExecuteAndDeserialize<MsExchangeMailboxes>(baseExchangeGraph, $"/adminapi/beta/{tenantId}/mailbox", exchangeAccessToken);
        return msExchangeMailboxes?.Value ?? new List<MsExchangeMailbox>();
    }

    public static void ProcessAllMSExchangeMailboxes()
    {
        IEnumerable<MSTenant> msTenants = MSGraphADServices.GetMSTenants();

        foreach (MSTenant tenant in msTenants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TenantName: {tenant.DisplayName}");
            Console.ResetColor();

            List<MsExchangeMailbox> msExchangeMailboxes = GetMSExchangeMailboxes(tenant.CustomerId);
            if (msExchangeMailboxes != null && msExchangeMailboxes.Count >= 1)
            {
                var mailboxCount = msExchangeMailboxes.Count;

                foreach (MsExchangeMailbox msExchangeMailbox in msExchangeMailboxes)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Display Name: {msExchangeMailbox.DisplayName}");
                    Console.ResetColor();
                    Console.WriteLine($"Mailbox Type: {msExchangeMailbox.RecipientType}");
                    Console.WriteLine($"Primary Email Address: {msExchangeMailbox.PrimarySmtpAddress}");
                    foreach (string alias in msExchangeMailbox.EmailAddresses.Where(a => a.StartsWith("smtp:")))
                    {
                        Console.WriteLine($"Aliases: {alias}");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine($"Total Number of Mailboxes: {mailboxCount}");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Tenant:{tenant.DisplayName} has no Exchange Mailboxes.");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}