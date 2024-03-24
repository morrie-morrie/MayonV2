using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Microsoft.Infra.Helper;
public class InfraFriendlySkus
{
    [MaxLength(10)]
    [Required]
    public int id { get; set; }

    [MaxLength(128)]
    [Required]
    public string MSSkuDisplayName { get; set; }

    [MaxLength(128)]
    [Required]
    public string MSSkuStringId { get; set; }

    [MaxLength(64)]
    [Required]
    public string MSSkuGUID { get; set; }

    [MaxLength(128)]
    [Required]
    public string MSSkuServicePlanName { get; set; }

    [MaxLength(64)]
    [Required]
    public string MSSkuServicePlanId { get; set; }

    [MaxLength(128)]
    [Required]
    public string MSSkuFriendlyName { get; set; }
}