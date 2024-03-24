using Mayon.Application.Webroot.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

public class HttpClientConfigurationManager
{
    public static void ConfigureClients(IServiceCollection services, IConfiguration configuration)
    {
        // Configure ProofpointClient
        services.AddHttpClient("ProofpointClient", client =>
        {
            client.BaseAddress = new Uri("https://us5.proofpointessentials.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-User", configuration["APIs:ProofPoint:Username"]);
            client.DefaultRequestHeaders.Add("X-Password", configuration["APIs:ProofPoint:Password"]);
        });

        services.AddHttpClient("NCentralClient", client =>
         {
             client.BaseAddress = new Uri(configuration["APIs:NCentral:baseUrl"]);
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         });

        services.AddHttpClient("ITGlueClient", client =>
        {
            client.BaseAddress = new Uri("https://api.itglue.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("x-api-key", configuration["APIs:ITGlue:Token"]);
        });

        //services.AddHttpClient("WebrootClient", client =>
        //{
        //    client.BaseAddress = new Uri(configuration["APIs:Webroot:baseUrl"]);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    // How can I get the token from the WebrootServices?
        //    Task<IdentityModel.Client.TokenResponse> token = GetWebrootBearerTokenAsync();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //});
    }
}