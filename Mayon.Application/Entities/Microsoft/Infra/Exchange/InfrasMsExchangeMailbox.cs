using Mayon.Application.Entities.Microsoft.Infra.AzureAD;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayon.Application.Entities.Microsoft.Infra.Exchange;
public class InfraMsExchangeMailbox
{
    [Key]
    public string Id { get; set; }

    [Required]
    [ForeignKey("Tenant")]
    public string MsTenantCustomerId { get; set; } // Foreign key referencing MsTenantCustomerId in InfraMsTenants

    public virtual InfraMsTenants Tenant { get; set; } // Navigation property

    [MaxLength(200)]
    public string? ExternalDirectoryObjectId { get; set; }

    [MaxLength(200)]
    public string? UserPrincipalName { get; set; }

    [MaxLength(200)]
    public string? Alias { get; set; }

    [MaxLength(200)]
    public string? DisplayName { get; set; }

    public string? EmailAddresses { get; set; } // Stored as a comma-separated string

    [MaxLength(200)]
    public string? PrimarySmtpAddress { get; set; }

    [MaxLength(200)]
    public string? RecipientType { get; set; }

    [MaxLength(200)]
    public string? RecipientTypeDetails { get; set; }

    // Other properties as necessary
    // ...
}