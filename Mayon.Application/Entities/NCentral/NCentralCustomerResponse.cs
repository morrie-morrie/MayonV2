using System.Text.Json.Serialization;

public class NCCustomerResponse
{
    [JsonPropertyName("data")]
    public List<Customer> Data { get; set; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; set; }
}

public class Customer
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    [JsonPropertyName("isSystem")]
    public bool IsSystem { get; set; }

    [JsonPropertyName("isServiceOrg")]
    public bool IsServiceOrg { get; set; }

    [JsonPropertyName("parentId")]
    public int ParentId { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("stateProv")]
    public string State { get; set; }

    [JsonPropertyName("county")]
    public string County { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("contactEmail")]
    public string ContactEmail { get; set; }
}