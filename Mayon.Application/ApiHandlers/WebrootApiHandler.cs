using Mayon.Application.Webroot.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

public static class WebrootApiHandler
{
    public static async Task HandleWebrootApi(ServiceProvider serviceProvider, IConfiguration configuration)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("Webroot API");
        Console.ResetColor();
        Console.WriteLine("-----------");
        Console.WriteLine();
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Getting Webroot Bearer Token");
            Console.ResetColor();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Not Implemented");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Log.Error("An error occurred while calling Webroot API: {ErrorMessage}", ex.Message);
        }
    }
}