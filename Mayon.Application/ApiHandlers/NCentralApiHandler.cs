using Mayon.Application.NCentral;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class NCentralApiHandler
{
    private static string _accessToken; // Static field to store accessToken

    public static async Task HandleNCentralApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        while (true)
        {
            //Console.Clear();
            int msChoice = GetUserChoiceForNCentralApi();
            if (msChoice == 99) break; // Exit to the main menu

            await ExecuteNCentralAPIChoice(msChoice, serviceProvider, configuration);
        }
    }

    private static int GetUserChoiceForNCentralApi()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Test / Authenticate");
        Console.WriteLine("2. Get NCentral Customers");
        Console.WriteLine("99. Exit");
        Console.Write("Enter your choice (1, 2 or 99.): ");

        if (int.TryParse(Console.ReadLine(), out int choice) && IsValidNCentralChoice(choice))
        {
            return choice;
        }

        Console.WriteLine("Invalid input. Please enter a valid number.");
        return 0; // Indicates an invalid choice
    }

    private static bool IsValidNCentralChoice(int choice)
    {
        int[] validChoices = { 1, 2, 99 };
        return validChoices.Contains(choice);
    }

    private static async Task ExecuteNCentralAPIChoice(int choice, ServiceProvider serviceProvider, IConfiguration configuration)
    {
        var api = serviceProvider.GetRequiredService<NCentralAPI>();
        string jwtToken = configuration["APIs:NCentral:jwt"];

        switch (choice)
        {
            case 1:
                if (string.IsNullOrWhiteSpace(jwtToken))
                {
                    Console.WriteLine("JWT token for NCentral API is not configured.");
                    return;
                }

                _accessToken = await api.GetNcentralAccessToken(jwtToken);
                if (!string.IsNullOrWhiteSpace(_accessToken))
                {
                    bool isValid = await api.ValidateAccessToken(_accessToken);
                    if (isValid)
                    {
                        Console.WriteLine($"Is Access Token Valid: {isValid}");
                        Console.WriteLine($"{_accessToken}");
                    }
                    else
                    {
                        Console.WriteLine("The access token is invalid.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to obtain an access token.");
                }
                break;

            case 2:
                // Check if accessToken is cached and valid; if not, fetch a new one
                if (string.IsNullOrWhiteSpace(_accessToken) || !await api.ValidateAccessToken(_accessToken))
                {
                    if (string.IsNullOrWhiteSpace(jwtToken))
                    {
                        Console.WriteLine("JWT token for NCentral API is not configured.");
                        return;
                    }

                    _accessToken = await api.GetNcentralAccessToken(jwtToken);
                    if (string.IsNullOrWhiteSpace(_accessToken))
                    {
                        Console.WriteLine("Failed to obtain an access token.");
                        return;
                    }
                }

                var allCustomers = await api.GetAllCustomers(_accessToken);
                if (allCustomers != null)
                {
                    foreach (var customer in allCustomers)
                    {
                        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.CustomerName}, City: {customer.City}");
                    }
                    Console.WriteLine($"Total Customers: {allCustomers.Count}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve customers.");
                }
                break;
        }
    }
}