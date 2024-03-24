namespace Mayon.Application.Entities.Microsoft.AzureAD;

public record MsTenantRiskyUsers(
    string? odatacontext,
       IEnumerable<MsTenantRiskyUser> Value
    );

public record GeoCoordinates(
    double? latitude,
    double? longitude
);

public record Location(

    string? city,
    string? state,
    string? countryOrRegion,
    GeoCoordinates geoCoordinates
);

public record MsTenantRiskyUser(
    string? id,
    string? requestId,
    string? correlationId,
    string? riskType,
    string? riskEventType,
    string? riskState,
    string? riskLevel,
    string? riskDetail,
    string? source,
    string? detectionTimingType,
    string? activity,
    string? tokenIssuerType,
    string? ipAddress,
    DateTime? activityDateTime,
    DateTime? detectedDateTime,
    DateTime? lastUpdatedDateTime,
    string? userId,
    string? userDisplayName,
    string? userPrincipalName,
    string? additionalInfo,
    object resourceTenantId,
    string? homeTenantId,
    string? userType,
    string? crossTenantAccessType,
    Location location
);