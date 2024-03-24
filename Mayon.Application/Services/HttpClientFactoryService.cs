public class HttpClientFactoryService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public HttpClient CreateClient(string clientName)
    {
        return _httpClientFactory.CreateClient(clientName);
    }
}