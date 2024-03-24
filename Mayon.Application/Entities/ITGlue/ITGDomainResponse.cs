using Newtonsoft.Json;

namespace Mayon.Application.Entities.ITGlue;
public record ITGDomainResponse(
  [property: JsonProperty("data")] IReadOnlyList<ITGDomainData> Data
);

public record ITGDomainAttributes(
    [property: JsonProperty("organization-id")] int OrganizationId,
    [property: JsonProperty("organization-name")] string OrganizationName,
    [property: JsonProperty("resource-url")] string ResourceUrl,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("screenshot")] string Screenshot,
    [property: JsonProperty("registrar-name")] string RegistrarName,
    [property: JsonProperty("notes")] object Notes,
    [property: JsonProperty("expires-on")] DateTimeOffset? ExpiresOn,
    [property: JsonProperty("updated-at")] DateTimeOffset? UpdatedAt
);

public record ITGDomainData(
    [property: JsonProperty("id")] string Id,
    [property: JsonProperty("type")] string Type,
    [property: JsonProperty("attributes")] ITGDomainAttributes Attributes
);