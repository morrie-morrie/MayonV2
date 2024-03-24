using Newtonsoft.Json;

namespace Mayon.Application.Entities.ITGlue;
public record ITGConfigResponsesWrapper(
    [JsonProperty("data")] IReadOnlyList<ITGConfigData> Data,
    [JsonProperty("meta")] Meta Meta,
    [JsonProperty("links")] Links Links
);

public record AdaptersResources(
    [JsonProperty("data")] IReadOnlyList<object> Data
);

public record ITGConfigAttribs(
    [JsonProperty("organization-id")] int OrganizationId,
    [JsonProperty("organization-name")] string OrganizationName,
    [JsonProperty("resource-url")] string ResourceUrl,
    [JsonProperty("restricted")] bool Restricted,
    [JsonProperty("psa-integration")] object PsaIntegration,
    [JsonProperty("my-glue")] bool MyGlue,
    [JsonProperty("name")] string Name,
    [JsonProperty("hostname")] string Hostname,
    [JsonProperty("primary-ip")] string PrimaryIp,
    [JsonProperty("mac-address")] string MacAddress,
    [JsonProperty("default-gateway")] string DefaultGateway,
    [JsonProperty("serial-number")] string SerialNumber,
    [JsonProperty("asset-tag")] object AssetTag,
    [JsonProperty("position")] string Position,
    [JsonProperty("installed-by")] string InstalledBy,
    [JsonProperty("purchased-by")] string PurchasedBy,
    [JsonProperty("notes")] string Notes,
    [JsonProperty("operating-system-notes")] object OperatingSystemNotes,
    [JsonProperty("warranty-expires-at")] object WarrantyExpiresAt,
    [JsonProperty("installed-at")] string InstalledAt,
    [JsonProperty("purchased-at")] string PurchasedAt,
    [JsonProperty("created-at")] DateTime CreatedAt,
    [JsonProperty("updated-at")] DateTime UpdatedAt,
    [JsonProperty("organization-short-name")] string OrganizationShortName,
    [JsonProperty("configuration-type-id")] int ConfigurationTypeId,
    [JsonProperty("configuration-type-name")] string ConfigurationTypeName,
    [JsonProperty("configuration-type-kind")] string ConfigurationTypeKind,
    [JsonProperty("configuration-status-id")] int? ConfigurationStatusId,
    [JsonProperty("configuration-status-name")] string ConfigurationStatusName,
    [JsonProperty("manufacturer-id")] int? ManufacturerId,
    [JsonProperty("manufacturer-name")] string ManufacturerName,
    [JsonProperty("model-id")] int? ModelId,
    [JsonProperty("operating-system-id")] int? OperatingSystemId,
    [JsonProperty("operating-system-name")] string OperatingSystemName,
    [JsonProperty("location-id")] int? LocationId,
    [JsonProperty("location-name")] string LocationName,
    [JsonProperty("contact-id")] int? ContactId,
    [JsonProperty("archived")] bool Archived,
    [JsonProperty("model-name")] string ModelName,
    [JsonProperty("contact-name")] string ContactName
);

public record ITGConfigData(
    [JsonProperty("id")] string Id,
    [JsonProperty("type")] string Type,
    [JsonProperty("attributes")] ITGConfigAttribs Attributes,
    [JsonProperty("relationships")] Relationships Relationships
);

public record Filters(

);

public record Links(
    [JsonProperty("self")] string Self,
    [JsonProperty("first")] string First,
    [JsonProperty("prev")] object Prev,
    [JsonProperty("next")] object Next,
    [JsonProperty("last")] string Last
);

public record Meta(
    [JsonProperty("current-page")] int CurrentPage,
    [JsonProperty("next-page")] object NextPage,
    [JsonProperty("prev-page")] object PrevPage,
    [JsonProperty("total-pages")] int TotalPages,
    [JsonProperty("total-count")] int TotalCount,
    [JsonProperty("filters")] Filters Filters
);

public record Relationships(
    [JsonProperty("adapters-resources")] AdaptersResources AdaptersResources
);