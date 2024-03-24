namespace Mayon.Blazor.Services;

public static class ServiceCollectionExtensions // Renamed to reflect purpose
{
    public static void AddITGlueService<TService>(this IServiceCollection services, string clientName) where TService : class
    {
        services.AddScoped<TService>(serviceProvider =>
        {
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(clientName);
            return (TService)Activator.CreateInstance(typeof(TService), client);
        });
    }

    public static void AddWebrootService<TService>(this IServiceCollection services, string clientName) where TService : class
    {
        services.AddScoped<TService>(serviceProvider =>
        {
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(clientName);
            return (TService)Activator.CreateInstance(typeof(TService), client);
        });
    }
}