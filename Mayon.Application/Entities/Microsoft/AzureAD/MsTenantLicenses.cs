namespace Mayon.Application.Entities.Microsoft.AzureAD;

public record MsTenantLicenses(
    string odatacontext,
    IEnumerable<MsTenantLicense> Value
    );

public record PrepaidUnits(
    int enabled,
    int suspended,
    int warning
    );

public record ServicePlan(
    string? servicePlanId,
    string? servicePlanName,
    string? provisioningStatus,
    string? appliesTo
    );

public record MsTenantLicense(
    string? capabilityStatus,
    int consumedUnits,
    string? id,
    string? skuId,
    string? skuPartNumber,
    string? appliesTo,
    PrepaidUnits prepaidUnits,
    IEnumerable<ServicePlan> servicePlans,
    string? MSSkuFriendlyName
    );