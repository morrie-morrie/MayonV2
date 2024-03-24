using Mayon.Application.Entities.ITGlue;
using Newtonsoft.Json;

namespace Mayon.Application.ITGlue.Services.Endpoints;
public class ITGlueAPIConfigurations
{
    private readonly HttpClient _client;

    public ITGlueAPIConfigurations(HttpClient client)
    {
        _client = client;
    }

    public async Task<IReadOnlyList<ITGConfigData>> GetITGConfigsAsync(string orgId)
    {
        Serilog.Log.Information("Calling ITGOrgs API");

        try
        {
            var endPointUrl = ($"/organizations/{orgId}/relationships/configurations?page[size]=1000&sort=name");
            HttpResponseMessage response = await _client.GetAsync(endPointUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var itgConfigurationResponse = JsonConvert.DeserializeObject<ITGConfigResponsesWrapper>(content);

                return itgConfigurationResponse.Data;
            }
            else
            {
                Serilog.Log.Error("Error fetching Configuration: {0}", response.StatusCode);
                return Enumerable.Empty<ITGConfigData>().ToList().AsReadOnly();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return Enumerable.Empty<ITGConfigData>().ToList().AsReadOnly();
        }
    }

    public async Task<IEnumerable<ITGConfigData>> GetITGAllConfigsAsync()
    {
        Serilog.Log.Information("\nCalling ITGlue API");

        try
        {
            var endPointUrl = ($"/configurations?&sort=name");

            Serilog.Log.Debug($"Calling {endPointUrl}");
            HttpResponseMessage response = await _client.GetAsync(endPointUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var itgConfigurationResponse = JsonConvert.DeserializeObject<ITGConfigResponsesWrapper>(content);

                Serilog.Log.Information($"\nTotal Configuration Count: {itgConfigurationResponse.Data.Count()}");
                foreach (var configData in itgConfigurationResponse.Data)
                {
                    var attributes = configData.Attributes;
                    Serilog.Log.Information($"\nCustomer: {attributes.OrganizationName}\nConfiguration Name: {attributes.Name}\nType: {attributes.ConfigurationTypeName}");
                }

                return itgConfigurationResponse.Data;
            }
            else
            {
                Serilog.Log.Error("Error fetching Configuration: {0}", response.StatusCode);
                return Enumerable.Empty<ITGConfigData>();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return Enumerable.Empty<ITGConfigData>();
        }
    }

    //public async Task<ITGConfigData> GetITGConfigAsync(string configId)
    //{
    //    Serilog.Log.Information("\nCalling ITGlue API");

    //    try
    //    {
    //        var endPointUrl = ($"/configurations/{configId}");

    //        Serilog.Log.Debug($"Calling {endPointUrl}");
    //        HttpResponseMessage response = await _client.GetAsync(endPointUrl);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            string content = await response.Content.ReadAsStringAsync();
    //            var itgConfigurationResponse = JsonConvert.DeserializeObject<ITGConfigResponsesWrapper>(content);

    //            Serilog.Log.Information($"\nConfiguration Name: {itgConfigurationResponse.Data.Attributes.Name}\nType: {itgConfigurationResponse.Data.Attributes.ConfigurationTypeName}");
    //            return itgConfigurationResponse.Data;
    //        }
    //        else
    //        {
    //            Serilog.Log.Error("Error fetching Configuration: {0}", response.StatusCode);
    //            return null;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Serilog.Log.Error("Exception: {0}", ex.Message);
    //        return null;
    //    }
    //}
}