using Mayon.Application.Entities.ITGlue;
using Newtonsoft.Json;

namespace Mayon.Application.ITGlue.Services.Endpoints;
public class ITGlueAPIDomains
{
    private readonly HttpClient _client;

    public ITGlueAPIDomains(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ITGDomainData>> GetITGDomainsAsync(string orgId)
    {
        Serilog.Log.Information("Calling ITGDomains API");

        try
        {
            HttpResponseMessage response = await _client.GetAsync($"/organizations/{orgId}/relationships/domains?page[size]=1000&sort=name");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var itgDomainsResponse = JsonConvert.DeserializeObject<ITGDomainResponse>(content);

                Serilog.Log.Information($"Total Configuration Count: {itgDomainsResponse.Data.Count}");

                return itgDomainsResponse.Data;
            }
            else
            {
                Serilog.Log.Error("Error fetching Domains: {0}", response.StatusCode);
                return Enumerable.Empty<ITGDomainData>();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return Enumerable.Empty<ITGDomainData>();
        }
    }
}