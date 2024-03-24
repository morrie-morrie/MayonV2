using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Mayon.Application.NCentral;
public class NCentralAPI
{
    private readonly HttpClient _client;
    private string _cachedAccessToken;
    private DateTime _accessTokenExpiry;

    public NCentralAPI(HttpClient client)
    {
        _client = client;
    }

    public static class TokenCache
    {
        private static string _token;
        private static DateTime _expiry;

        public static void SetToken(string token, int expiresIn)
        {
            _token = token;
            _expiry = DateTime.UtcNow.AddSeconds(expiresIn);
        }

        public static string GetToken()
        {
            if (string.IsNullOrEmpty(_token) || DateTime.UtcNow >= _expiry)
                return null;
            return _token;
        }
    }

    public async Task<string> GetNcentralAccessToken(string jwt)
    {
        // Check if a valid token is already cached
        if (!string.IsNullOrWhiteSpace(_cachedAccessToken) && DateTime.UtcNow < _accessTokenExpiry)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Token has been reused");
            Console.ResetColor();
            return _cachedAccessToken;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Token has been reauthenticated");
        Console.ResetColor();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        var content = new StringContent("", Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync("/api/auth/authenticate", content);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(data);

            // Extract the access token from the nested JSON structure
            string accessToken = tokenResponse.tokens.access.token;
            int tokenExpirySeconds = tokenResponse.tokens.access.expirySeconds; // Extract expirySeconds from the response

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                _cachedAccessToken = accessToken;
                _accessTokenExpiry = DateTime.UtcNow.AddSeconds(tokenExpirySeconds);
            }

            return accessToken;
        }
        else
        {
            string errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode}");
            Console.WriteLine($"Error Content: {errorResponse}");
            return null;
        }
    }

    public async Task<bool> ValidateAccessToken(string accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            Console.WriteLine("Access token is missing.");
            return false;
        }

        // Assuming there's a specific endpoint to validate the token
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        try
        {
            HttpResponseMessage response = await _client.GetAsync("/api/auth/validate"); // Replace with actual endpoint
            if (response.IsSuccessStatusCode)
            {
                // Token is valid
                return true;
            }
            else
            {
                // Token is not valid or other error occurred
                Console.WriteLine($"Token validation failed: {response.StatusCode}");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the request
            Console.WriteLine($"Error during token validation: {ex.Message}");
            return false;
        }
    }

    public async Task<List<Customer>> GetAllCustomers(string accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            Console.WriteLine("Access token is missing.");
            return null;
        }

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        int pageNumber = 1;
        int pageSize = 50; // Set an appropriate page size
        string sortBy = "customerName";
        string sortOrder = "ASC";
        List<Customer> allCustomers = new List<Customer>();

        while (true)
        {
            var requestUrl = $"/api/customers?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={sortBy}&sortOrder={sortOrder}";
            HttpResponseMessage response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NCCustomerResponse>(data);

                if (result?.Data != null)
                {
                    allCustomers.AddRange(result.Data);

                    if (allCustomers.Count >= result.TotalItems)
                    {
                        break; // Exit the loop if all items are fetched
                    }
                }
                else
                {
                    break; // No data in the response
                }
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error fetching customers: {response.StatusCode}");
                Console.WriteLine($"Error Content: {errorResponse}");
                return null; // Exit on error
            }

            pageNumber++; // Go to the next page
        }

        return allCustomers;
    }
}