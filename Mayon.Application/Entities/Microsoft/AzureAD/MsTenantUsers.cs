namespace Mayon.Application.Entities.Microsoft.AzureAD;

public record MsTenantUsers(
    string? odatacontext,
    IEnumerable<MsTenantUser>? Value
    );
public record MsTenantUser(
    IEnumerable<string>? businessPhones,
    string? displayName,
    string? givenName,
    string? jobTitle,
    string? mail,
    string? mobilePhone,
    string? officeLocation,
    string? preferredLanguage,
    string? surname,
    string? userPrincipalName,
    string? id
);