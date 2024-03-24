using Mayon.Application.Entities.ITGlue;
using Newtonsoft.Json;

namespace Mayon.Application.ITGlue.Services.Endpoints;
public class ITGlueAPIUsers
{
    private readonly HttpClient _client;

    public ITGlueAPIUsers(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ITGUserData>> GetITGUsersAsync()
    {
        Serilog.Log.Information("Calling ITGUsers API");

        try
        {
            HttpResponseMessage response = await _client.GetAsync("/users?page[size]=1000&sort=name");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var itgUserResponseWrapper = JsonConvert.DeserializeObject<ITGUserResponse>(content);

                Serilog.Log.Information($"\nDeserialized ITGUserReponsesWrapper:\n{content}");
                Serilog.Log.Information($"\nTotal User Count: {itgUserResponseWrapper.Data.Count}");

                return itgUserResponseWrapper.Data;
            }
            else
            {
                Serilog.Log.Error("Error fetching users: {0}", response.StatusCode);
                return Enumerable.Empty<ITGUserData>();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Error("Exception: {0}", ex.Message);
            return Enumerable.Empty<ITGUserData>();
        }
    }
}