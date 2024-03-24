using Newtonsoft.Json;

namespace Mayon.Application.Entities.ITGlue;
public record ITGOrgResponsesWrapper(

    [property: JsonProperty("data")] IReadOnlyList<ITGOrgData> Data
);

public record ITGOrgData(

    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("type")] string? Type,
    [property: JsonProperty("attributes")] ITGOrgsAttributes Attributes
);

public record ITGOrgsAttributes(
    [property: JsonProperty("name")] string? Name,
    [property: JsonProperty("alert")] string? Alert,
    [property: JsonProperty("description")] string? Description,
    [property: JsonProperty("organization-type-id")] int? OrganizationTypeId,
    [property: JsonProperty("organization-type-name")] string? OrganizationTypeName,
    [property: JsonProperty("organization-status-id")] int? OrganizationStatusId,
    [property: JsonProperty("organization-status-name")] string? OrganizationStatusName,
    [property: JsonProperty("primary")] bool Primary,
    [property: JsonProperty("quick-notes")] string? QuickNotes,
    [property: JsonProperty("short-name")] string? ShortName,
    [property: JsonProperty("created-at")] DateTime CreatedAt,
    [property: JsonProperty("updated-at")] DateTime UpdatedAt,
    [property: JsonProperty("parent-id")] object ParentId
);