namespace Mayon.Application.Entities.Microsoft.Security;

public record MsTenantCAPolicies(

    string? odatacontext,
    IEnumerable<MsTenantCAPolicy>? Value
    );

public record MsTenantCAPolicy(

    string? id,
    string? templateId,
    string? displayName,
    DateTime? createdDateTime,
    DateTime? modifiedDateTime,
    string? state,
    object sessionControls,
    Conditions conditions,
    Grantcontrols grantControls
);

public record Conditions(

    object userRiskLevels,
    object signInRiskLevels,
    object clientAppTypes,
    object platforms,
    object locations,
    object times,
    object deviceStates,
    object devices,
    object clientApplications,
    Applications applications,
    Users users
);

public record Applications(

    object includeApplications,
    object excludeApplications,
    object includeUserActions,
    object includeAuthenticationContextClassReferences,
    object applicationFilter
);

public record Users(

    object includeUsers,
    object excludeUsers,
    object includeGroups,
    object excludeGroups,
    object includeRoles,
    object excludeRoles,
    object includeGuestsOrExternalUsers,
    object excludeGuestsOrExternalUsers
);

public record Grantcontrols(

    string _operator,
    object builtInControls,
    object customAuthenticationFactors,
    object termsOfUse,
    string? authenticationStrengthodatacontext,
    object authenticationStrength
);