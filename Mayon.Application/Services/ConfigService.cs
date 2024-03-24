using Microsoft.Extensions.Configuration;

namespace Mayon.Application.Services;
public static class ConfigService
{
    public static IConfiguration Configuration { get; set; }

    static ConfigService()
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
}