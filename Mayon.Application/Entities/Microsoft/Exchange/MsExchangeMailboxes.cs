namespace Mayon.Application.Entities.Microsoft.Exchange;

public record MsExchangeMailbox(
    string? odataid,
    string? odataeditLink,
    string? ObjectKey,
    string? ExternalDirectoryObjectId,
    string? UserPrincipalName,
    string? Alias,
    string? DisplayName,
    List<string> EmailAddresses,
    string? PrimarySmtpAddress,
    string? RecipientType,
    string? RecipientTypeDetails,
    string? Identity,
    string? Id,
    string? ExchangeVersion,
    string? Name,
    string? DistinguishedName,
    string? OrganizationId,
    string? Guid
);

public record MsExchangeMailboxes(
       string odatacontext,
       string odatanextLink,
       List<MsExchangeMailbox>? Value
   );