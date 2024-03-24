using System.Text.Json.Serialization;

namespace Mayon.Application.Entities.Duo;
public record DuoCustomerResponse
{
    [JsonPropertyName("Account_id")]
    public string? AccountId { get; set; }

    [JsonPropertyName("Api_hostname")]
    public string? ApiHostName { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}

public record DuoCustomerReponses
{
    [JsonPropertyName("Response")]
    public List<DuoCustomerResponse>? Response { get; set; }

    [JsonPropertyName("Stat")]
    public string? Stat { get; set; }
}