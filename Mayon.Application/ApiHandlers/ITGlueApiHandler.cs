using Mayon.Application.ITGlue.Services.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayon.Application.ApiHandlers;

public static class ITGlueApiHandler
{
    public static async Task HandleITGlueApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        while (true)
        {
            //Console.Clear();
            int msChoice = GetUserChoiceForITGlueApi();
            if (msChoice == 99) break; // Exit to the main menu

            await ExecuteITGlueAPIChoice(msChoice, serviceProvider, configuration);
        }
    }

    private static int GetUserChoiceForITGlueApi()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Get ITGlue Customers");
        Console.WriteLine("2. Get Individual Customer");
        Console.WriteLine("3. Get All Configurations");
        Console.WriteLine("99. Exit");
        Console.Write("Enter your choice (1, 2 or 99.): ");

        if (int.TryParse(Console.ReadLine(), out int choice) && IsValidITGlueChoice(choice))
        {
            return choice;
        }

        Console.WriteLine("Invalid input. Please enter a valid number.");
        return 0; // Indicates an invalid choice
    }

    private static bool IsValidITGlueChoice(int choice)
    {
        int[] validChoices = { 1, 2, 3, 99 };
        return validChoices.Contains(choice);
    }

    private static async Task ExecuteITGlueAPIChoice(int choice, ServiceProvider serviceProvider, IConfiguration configuration)
    {
        try
        {
            var apiOrgs = serviceProvider.GetRequiredService<ITGlueAPIOrganisations>();
            var apiConfigs = serviceProvider.GetRequiredService<ITGlueAPIConfigurations>();
            var apiDomains = serviceProvider.GetRequiredService<ITGlueAPIDomains>();
            var apiUsers = serviceProvider.GetRequiredService<ITGlueAPIUsers>();

            switch (choice)
            {
                case 1:
                    var orgs = await apiOrgs.GetITGOrgsAsync();
                    // Add logic to process and display orgs
                    break;

                case 2:
                    Console.Write("Enter the Organization ID: ");
                    string orgId = Console.ReadLine();
                    var org = await apiOrgs.GetITGOrgAsync(orgId);
                    if (org != null)
                    {
                        // Display organization details
                        Console.WriteLine($"Organization Name: {org.Attributes.Name}");
                        // ... other details ...
                    }
                    else
                    {
                        Console.WriteLine("Organization not found or error occurred.");
                    }
                    break;

                case 3:
                    var configs = await apiConfigs.GetITGAllConfigsAsync();
                    if (configs != null)
                    {
                        Serilog.Log.Information("Configs found");
                        Serilog.Log.Information($"Number of Configs Found: {configs.Count()}");
                    }
                    else
                    {
                        Console.WriteLine("Configurations not found or error occurred.");
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Optionally log the exception or handle it as required
        }
    }
}