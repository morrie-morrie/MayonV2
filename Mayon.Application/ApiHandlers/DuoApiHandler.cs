using Mayon.Application.Duo.RestApi;
using Mayon.Application.Duo.RestApi.Helpers;
using Mayon.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayon.Application.ApiHandlers;

public static class DuoApiHandler
{
    public static async Task HandleDuoApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("DUO API");
        Console.ResetColor();
        Console.WriteLine("-------");
        Console.WriteLine();

        // Resolve the necessary dependencies from the service provider
        var dateService = serviceProvider.GetService<IDateService>();
        var duoDbQuery = serviceProvider.GetService<DuoDbQuery>();

        // Ensure dependencies are not null
        if (dateService == null || duoDbQuery == null)
        {
            Console.WriteLine("Required services are not registered.");
            return;
        }

        // Create an instance of DuoAuth
        var duoAuth = new DuoAuth(dateService);

        // Call the method using the instance
        duoAuth.GetAuthHeadersForAllCustomers(configuration);
    }
}