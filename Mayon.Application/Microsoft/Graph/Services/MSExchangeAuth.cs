using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Entities.Microsoft.Auth;
using Mayon.Application.Microsoft.Graph.Helper;
using Newtonsoft.Json;
using RestSharp;

namespace Mayon.Application.Microsoft.Graph.Services;
public static class MSGraphExchangeAuth
{
    public static string GetExchangeAccessToken(string refreshToken, string tenantId)

    {
        AdminMsApiAuth? msAuthCreds = MSGraphHelper.GetMSAuthCreds();
        if (msAuthCreds == null)
        {
            throw new Exception("No MS Auth Creds found");
        }

        var options = new RestClientOptions("https://login.microsoftonline.com")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest($"/{tenantId}/oauth2/token", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("client_id", msAuthCreds.MsClientId);
        request.AddParameter("client_secret", msAuthCreds.MsClientSecret);
        request.AddParameter("grant_type", "refresh_token");
        request.AddParameter("refresh_token", msAuthCreds.MsRefreshToken);
        request.AddParameter("resource", "https://outlook.office365.com");

        RestResponse response = client.Execute(request);

        var token = JsonConvert.DeserializeObject<MSExchangeToken>(response?.Content ?? string.Empty);
        return token?.access_token ?? string.Empty;
    }
}