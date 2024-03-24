using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;
using Mayon.Application.Duo.RestApi;
using Mayon.Application.Duo.RestApi.Helpers;
using Mayon.Application.ITGlue.Services.Endpoints;
using Mayon.Application.NCentral;
using Mayon.Application.Services;
using Mayon.Application.Services.Generic;
using Mayon.Application.Services.Interfaces;
using Mayon.Application.Webroot.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Serilog;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = ConfigureLogging();
        var serviceProvider = ConfigureServices();
        var configuration = serviceProvider.GetService<IConfiguration>();

        while (true)
        {
            int userSelection = GetUserChoice();
            if (userSelection == 99) break;

            await ExecuteChoice(userSelection, serviceProvider, configuration);
        }
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        var keyVaultUrl = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
        var tenantId = Environment.GetEnvironmentVariable("KV_TENANT_ID");
        var clientId = Environment.GetEnvironmentVariable("KV_CLIENT_ID");
        var thumbprint = Environment.GetEnvironmentVariable("KV_THUMBPRINT");

        var keyVaultService = new KeyVaultService(keyVaultUrl, tenantId, clientId, thumbprint);

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        // Add Key Vault to configuration if SecretClient is available
        if (keyVaultService.GetSecretClient() is SecretClient secretClient)
        {
            configurationBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        }

        var configuration = configurationBuilder.Build();
        services.AddSingleton<IConfiguration>(configuration);

        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddHttpClient();
        services.AddSingleton<HttpClientFactoryService>();

        // Use HttpClientConfigurationManager to configure clients
        HttpClientConfigurationManager.ConfigureClients(services, configuration);

        services.AddScoped<DuoDbQuery>();
        services.AddScoped<DuoAuth>();
        services.AddScoped<IDateService, DateService>();

        services.AddScoped<ProofpointApiService>(serviceProvider =>
        {
            var httpClientFactoryService = serviceProvider.GetRequiredService<HttpClientFactoryService>();
            var client = httpClientFactoryService.CreateClient("ProofpointClient");
            return new ProofpointApiService(client);
        });

        services.AddScoped<NCentralAPI>(serviceProvider =>
        {
            var httpClientFactoryService = serviceProvider.GetRequiredService<HttpClientFactoryService>();
            var client = httpClientFactoryService.CreateClient("NCentralClient");
            return new NCentralAPI(client);
        });

        //services.AddScoped<WebrootServices>(serviceProvider =>
        //{
        //    var httpClientFactoryService = serviceProvider.GetRequiredService<HttpClientFactoryService>();
        //    var client = httpClientFactoryService.CreateClient("WebrootClient");
        //    return new WebrootServices(client);
        //});

        RegisterITGlueService<ITGlueAPIOrganisations>(services, "ITGlueClient");
        RegisterITGlueService<ITGlueAPIConfigurations>(services, "ITGlueClient");
        RegisterITGlueService<ITGlueAPIDomains>(services, "ITGlueClient");
        RegisterITGlueService<ITGlueAPIUsers>(services, "ITGlueClient");

        RegisterITGlueService<WebrootServices>(services, "WebrootClient");

        services.AddMemoryCache();

        var serviceProvider = services.BuildServiceProvider();

        return services.BuildServiceProvider();
    }

    private static void RegisterITGlueService<TService>(IServiceCollection services, string clientName)
    where TService : class
    {
        services.AddScoped<TService>(serviceProvider =>
        {
            var httpClientFactoryService = serviceProvider.GetRequiredService<HttpClientFactoryService>();
            var client = httpClientFactoryService.CreateClient(clientName);
            return Activator.CreateInstance(typeof(TService), client) as TService;
        });
    }

    private static ILogger ConfigureLogging()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
    }

    private static int GetUserChoice()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select the API to call:");
            Console.WriteLine("1. DUO");
            Console.WriteLine("2. Microsoft");
            Console.WriteLine("3. ITGlue");
            Console.WriteLine("4. NCentral");
            Console.WriteLine("5. Webroot");
            Console.WriteLine("6. ProofPoint");
            Console.WriteLine("99. Exit");
            Console.Write("Enter your choice (1, 2, 3, 4, 5, or 99): ");

            if (int.TryParse(Console.ReadLine(), out int choice) && IsValidChoice(choice))
            {
                return choice;
            }

            Console.WriteLine("Invalid input. Please enter a number from the list.");
        }
    }

    private static bool IsValidChoice(int choice)
    {
        // Define valid choices. Could be an array or List if more complex.
        int[] validChoices = { 1, 2, 3, 4, 5, 6, 99 };
        return validChoices.Contains(choice);
    }

    private static async Task ExecuteChoice(int choice, ServiceProvider serviceProvider, IConfiguration configuration)
    {
        switch (choice)
        {
            case 1: // DUO
                await DuoApiHandler.HandleDuoApi(serviceProvider, configuration);
                break;

            case 2: // Microsoft
                await MicrosoftGraphApiHandler.HandleMicrosoftGraphApi(serviceProvider, configuration);
                break;

            case 3:
                await ITGlueApiHandler.HandleITGlueApi(serviceProvider, configuration);
                break;

            case 4:
                await NCentralApiHandler.HandleNCentralApi(serviceProvider, configuration);
                break;

            case 5:
                await WebrootApiHandler.HandleWebrootApi(serviceProvider, configuration);
                break;

            case 6:

                await ProofPointApiHandler.HandleProofPointApi(serviceProvider, configuration);

                break;
        }
    }
}