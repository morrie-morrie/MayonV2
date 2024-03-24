namespace Mayon.Application.Entities.Microsoft.AzureAD;

public record MsTenantOrganisations(

    string odatacontext,
    IEnumerable<MsTenantOrganisation> Value
);

public record MsTenantOrganisation(
        string id,
        string? deletedDateTime,
        string[]? businessPhones,
        string? city,
        string? country,
        string countryLetterCode,
        DateTime createdDateTime,
        string? defaultUsageLocation,
        string displayName,
        string? isMultipleDataLocationsForServicesEnabled,
        string[]? marketingNotificationEmails,
        string? onPremisesLastSyncDateTime,
        string? onPremisesSyncEnabled,
        string? partnerTenantType,
        string? postalCode,
        string preferredLanguage,
        string[]? securityComplianceNotificationMails,
        string[]? securityComplianceNotificationPhones,
        string? state,
        string? street,
        string[]? technicalNotificationMails,
        string tenantType,
        Directorysizequota directorySizeQuota,
        Assignedplan[] assignedPlans,
        Privacyprofile privacyProfile,
        Provisionedplan[] provisionedPlans,
        Verifieddomain[] verifiedDomains
    );

public record Directorysizequota(
       int used,
       int total
    );

public record Privacyprofile(
          string? contactEmail,
          string? statementUrl
       );

public record Assignedplan(
        DateTime assignedDateTime,
        string? capabilityStatus,
        string? service,
        string? servicePlanId
);

public record Provisionedplan(
    string? capabilityStatus,
    string? provisioningStatus,
    string? service
);

public record Verifieddomain(
    string? capabilities,
    bool isDefault,
    bool isInitial,
    string? name,
    string? type
);