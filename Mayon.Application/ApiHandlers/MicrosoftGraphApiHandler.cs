using Mayon.Application.Entities.Microsoft.AzureAD;
using Mayon.Application.Microsoft.Graph.AzureAD;
using Mayon.Application.Microsoft.Graph.ExchangeOnline;
using Mayon.Application.Microsoft.Graph.Helper;
using Mayon.Application.Microsoft.Graph.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

public static class MicrosoftGraphApiHandler
{
    public static async Task HandleMicrosoftGraphApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        while (true)
        {
            Console.Clear();
            int msChoice = GetUserChoiceForMicrosoftGraphApi();
            if (msChoice == 99) break; // Exit to the main menu

            await ExecuteMicrosoftGraphChoice(msChoice, serviceProvider);
        }
    }

    private static int GetUserChoiceForMicrosoftGraphApi()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Show all tenants");
        Console.WriteLine("2. Display tenants by DisplayName");
        Console.WriteLine("3. Process all tenant organizations");
        Console.WriteLine("4. Process all tenant users");
        Console.WriteLine("5. Process all tenant licenses");
        Console.WriteLine("6. Process all Risky Users");
        Console.WriteLine("7. Get Exchange Tokens");
        Console.WriteLine("8. Get Conditional Access Policies");
        Console.WriteLine("9. Get the Friendly SKU List from Microsoft");
        Console.WriteLine("10. Testing MS Key Vault");
        Console.WriteLine("99. Exit");
        Console.Write("Enter your choice (1, 2, 3, 4, 5, 6, 7, 8, 9, 10 or 99.): ");

        if (int.TryParse(Console.ReadLine(), out int choice) && IsValidMicrosoftGraphChoice(choice))
        {
            return choice;
        }

        Console.WriteLine("Invalid input. Please enter a valid number.");
        return 0; // Indicates an invalid choice
    }

    private static bool IsValidMicrosoftGraphChoice(int choice)
    {
        int[] validChoices = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 99 };
        return validChoices.Contains(choice);
    }

    private static async Task ExecuteMicrosoftGraphChoice(int choice, ServiceProvider serviceProvider)
    {
        IEnumerable<MSTenant> tenants = MSGraphADServices.GetMSTenants();
        MSGraphWriteDB.WriteMSTenantsToDB(tenants);

        switch (choice)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Tenants:");
                Console.WriteLine();

                foreach (MSTenant tenant in tenants)
                {
                    Console.WriteLine($"DisplayName: {tenant.DisplayName}");
                    Console.WriteLine($"CustomerId: {tenant.CustomerId}");
                    Console.WriteLine($"DefaultDomainName: {tenant.DefaultDomainName}");
                    Console.WriteLine($"Id: {tenant.Id}");
                    Console.WriteLine($"ContractType: {tenant.ContractType}");

                    Console.WriteLine();
                }
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 2:
                Console.Clear();
                Console.Write("Enter part of the Tenant DisplayName: ");
                string displayNamePart = Console.ReadLine();

                List<MSTenant> matchingTenants = tenants.Where(t => t.DisplayName.Contains(displayNamePart, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchingTenants.Count > 0)
                {
                    Console.WriteLine("Matching Tenants:");
                    foreach (MSTenant tenant in matchingTenants)
                    {
                        Console.WriteLine($"DisplayName: {tenant.DisplayName}");
                        Console.WriteLine($"CustomerId: {tenant.CustomerId}");
                        Console.WriteLine($"DefaultDomainName: {tenant.DefaultDomainName}");
                        Console.WriteLine($"Id: {tenant.Id}");
                        Console.WriteLine($"ContractType: {tenant.ContractType}");

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No matching tenants found.");
                }
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 3:
                Console.Clear();
                Log.Information("Processing all tenant organizations:");
                Log.Information("");
                MSGraphAPI.ProcessAllMSTenantsOrganisations();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 4:
                Console.Clear();
                Console.WriteLine("Processing all tenant Users:");
                Console.WriteLine();
                MSGraphAPI.ProcessAllMSTenantsUsers();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 5:
                Console.Clear();
                Console.WriteLine("Processing all tenant Licenses:");
                Console.WriteLine();
                MSGraphAPI.ProcessAllMSTenantsLicenses();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 6:
                Console.Clear();
                Console.WriteLine("Proessing Risky Users:");
                Console.WriteLine();
                MSGraphAPI.ProcessAllMSTenantsRiskyUsers();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 7:
                Console.Clear();
                Console.WriteLine("Getting Exchange Tokens:");
                Console.WriteLine();
                MSGraphExchServices.ProcessAllMSExchangeMailboxes();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 8:
                Console.Clear();
                Console.WriteLine("Getting Conditional Access Policies:");
                Console.WriteLine();
                MSGraphAPI.ProcessAllMSTenantsCAPolicies();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 9:
                Console.Clear();
                Console.WriteLine("Get the Friendly SKU List from Microsoft:");
                Console.WriteLine();
                MSSkuHelper.GetMSSkuFriendlyName();
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;

            case 10:
                Console.Clear();
                Console.WriteLine("Testing Keyvault");
                Console.WriteLine();
                var keyVaultUrl = "https://kvmorrie.vault.azure.net/";
                var tenantId = "1d646cbb-7546-41d0-994a-af1ac99504ea"; // Azure AD Tenant ID
                var clientId = "94c6fdef-4580-49ee-86a1-fadb4434b8f1"; // Azure AD Application (Client) ID
                var thumbprint = "02AA40A83D489CB998A5CE98634FCAAD632DB6B3";
                var keyVaultService = new KeyVaultService(keyVaultUrl, tenantId, clientId, thumbprint);

                try
                {
                    await keyVaultService.SetSecretAsync("MySecret", "secretValue");
                    string secretValue = await keyVaultService.GetSecretAsync("MySecret");
                    string testing = await keyVaultService.GetSecretAsync("Testing");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Secret Value: " + secretValue);
                    Console.WriteLine("Testing Value: " + testing);
                    Console.ResetColor();
                }
                catch (Azure.RequestFailedException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    // You can also log additional details from the exception as needed.
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user input before returning to the menu
                break;
        }
    }
}