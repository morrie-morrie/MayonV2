using Newtonsoft.Json;

public class ProofpointApiService
{
    private readonly HttpClient _client;

    public ProofpointApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task GetOrganizationData(string domain)
    {
        HttpResponseMessage response = await _client.GetAsync($"api/v1/orgs/{domain}");
        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
            var organizationData = JsonConvert.DeserializeObject<dynamic>(responseData);
            Console.WriteLine(organizationData);
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }
    }
}