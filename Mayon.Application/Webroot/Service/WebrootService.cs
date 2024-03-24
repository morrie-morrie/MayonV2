using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Mayon.Application.Webroot.Service;
public class WebrootServices
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public WebrootServices(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public async Task<TokenResponse> GetWebrootBearerTokenAsync()
    {
        var tokenEndpoint = "https://unityapi.webrootcloudav.com/auth/token";
        var userName = _configuration["APIs:Webroot:UserName"];
        var password = _configuration["APIs:Webroot:Password"];
        var clientId = _configuration["APIs:Webroot:ClientID"];
        var clientSecret = _configuration["APIs:Webroot:ClientSecret"];

        try
        {
            var response = await _client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = tokenEndpoint,
                UserName = userName,
                Password = password,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = "*" // Adjust according to actual required scope
            });

            return response;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error getting Webroot Bearer Token");
            throw;
        }
    }

    public async Task<string> GetWebrootOrgs(IConfiguration configuration)
    {
        Log.Debug("Getting Webroot Orgs");

        string siteCodeUrl = configuration["APIs:Webroot:Sitecodeurl"];
        HttpResponseMessage response = await _client.GetAsync($"{siteCodeUrl}/sites");
        string responseString = await response.Content.ReadAsStringAsync();
        Log.Debug("Response Data: {Data}", responseString);
        return responseString;
    }
}