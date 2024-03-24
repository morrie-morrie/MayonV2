namespace Mayon.Application.Entities.Microsoft.AzureAD;

public record MSTenant(

    string? Id,
    string? DeletedDateTime,
    string? ContractType,
    string? CustomerId,
    string? DefaultDomainName,
    string? DisplayName
);

public record MSTenants(

    string? ODataContext,
    IEnumerable<MSTenant>? Value
    );