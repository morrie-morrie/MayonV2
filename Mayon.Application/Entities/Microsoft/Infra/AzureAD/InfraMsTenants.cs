using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Microsoft.Infra.AzureAD;
public class InfraMsTenants
{
    [MaxLength(64)]
    [Required]
    [Key]
    public string? MsTenantCustomerId { get; set; }

    [MaxLength(64)]
    [Required]
    public string? MsTenantDisplayName { get; set; }

    [MaxLength(64)]
    public string? MsTenantDefaultDomainName { get; set; }

    [MaxLength(64)]
    public string? MsTenantContractType { get; set; }

    [MaxLength(64)]
    public string? MSTenantDeletedDateTime { get; set; }
}