using Mayon.Application.Entities.ITGlue;
using Newtonsoft.Json;

namespace Mayon.Application.ITGlue.Services.Endpoints;
public class ITGlueAPIOrganisations
{
    private readonly HttpClient _client;

    public ITGlueAPIOrganisations(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ITGOrgData>> GetITGOrgsAsync()
    {
        Serilog.Log.Information("Calling ITGOrgs API");

        try
        {
            HttpResponseMessage response = await _client.GetAsync("/organizations?page[size]=1000&sort=name");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                // Deserialize using the ITGOrgsResponse wrapper class
                var itgOrgsResponseWrapper = JsonConvert.DeserializeObject<ITGOrgResponsesWrapper>(content);

                Serilog.Log.Information($"\nDeserialized ITGOrgReponsesWrapper:\n{content}");
                Serilog.Log.Information($"\nTotal Organization Count: {itgOrgsResponseWrapper.Data.Count}");

                return itgOrgsResponseWrapper.Data;
            }
            else
            {
                Serilog.Log.Error("Error fetching organizations: {0}", response.StatusCode);
                return Enumerable.Empty<ITGOrgData>();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return Enumerable.Empty<ITGOrgData>();
        }
    }

    public async Task<ITGOrgData> GetITGOrgAsync(string orgId)
    {
        Serilog.Log.Information($"Calling ITGlue API for Organization ID: {orgId}");

        try
        {
            HttpResponseMessage response = await _client.GetAsync($"/organizations/{orgId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var itgOrgResponseWrapper = JsonConvert.DeserializeObject<ITGOrgResponsesWrapper>(content);

                // Assuming the first entry in the Data list corresponds to the organization data
                var organizationData = itgOrgResponseWrapper.Data.FirstOrDefault();

                // Log for debugging purposes
                Serilog.Log.Information($"Organization Name: {organizationData?.Attributes.Name}");

                return organizationData;
            }
            else
            {
                Serilog.Log.Error("Error fetching organization: {0}", response.StatusCode);
                return null;
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return null;
        }
    }
}