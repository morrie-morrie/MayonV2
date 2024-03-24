using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ProofPointApiHandler
{
    public static async Task HandleProofPointApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("ProofPoint API");
        Console.ResetColor();
        Console.WriteLine("-----------");
        Console.WriteLine();

        var api = serviceProvider.GetRequiredService<ProofpointApiService>();
        await api.GetOrganizationData("techno.com.au");
    }
}