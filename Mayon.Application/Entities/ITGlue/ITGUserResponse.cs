using Newtonsoft.Json;

namespace Mayon.Application.Entities.ITGlue;
public record ITGUserResponse(
    [property: JsonProperty("data")] IReadOnlyList<ITGUserData> Data,
    [property: JsonProperty("meta")] Meta Meta,
    [property: JsonProperty("links")] Links Links
);

public record ITGUserAttributes(
        [property: JsonProperty("first-name")] string FirstName,
        [property: JsonProperty("last-name")] string LastName,
        [property: JsonProperty("name")] string Name,
        [property: JsonProperty("role-name")] string RoleName,
        [property: JsonProperty("email")] string? Email,
        [property: JsonProperty("invitation-sent-at")] DateTime? InvitationSentAt,
        [property: JsonProperty("invitation-accepted-at")] DateTime? InvitationAcceptedAt,
        [property: JsonProperty("current-sign-in-at")] DateTime? CurrentSignInAt,
        [property: JsonProperty("current-sign-in-ip")] string CurrentSignInIp,
        [property: JsonProperty("last-sign-in-at")] DateTime? LastSignInAt,
        [property: JsonProperty("last-sign-in-ip")] string LastSignInIp,
        [property: JsonProperty("reputation")] int? Reputation,
        [property: JsonProperty("created-at")] DateTime? CreatedAt,
        [property: JsonProperty("updated-at")] DateTime? UpdatedAt,
        [property: JsonProperty("my-glue-account-id")] string MyGlueAccountId,
        [property: JsonProperty("salesforce-id")] string SalesforceId,
        [property: JsonProperty("avatar")] string Avatar,
        [property: JsonProperty("my-glue")] bool? MyGlue,
        [property: JsonProperty("role-id")] int? RoleId
    );

public record ITGUserData(
    [property: JsonProperty("id")] string Id,
    [property: JsonProperty("type")] string Type,
    [property: JsonProperty("attributes")] ITGUserAttributes Attributes
);

public record ITGUserLinks(
    [property: JsonProperty("self")] string Self,
    [property: JsonProperty("first")] string First,
    [property: JsonProperty("prev")] object Prev,
    [property: JsonProperty("next")] object Next,
    [property: JsonProperty("last")] string Last
);

public record ITGUserMeta(
    [property: JsonProperty("current-page")] int? CurrentPage,
    [property: JsonProperty("next-page")] object NextPage,
    [property: JsonProperty("prev-page")] object PrevPage,
    [property: JsonProperty("total-pages")] int? TotalPages,
    [property: JsonProperty("total-count")] int? TotalCount
);