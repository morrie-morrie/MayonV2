using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Duo.Infra;
public class DuoCustomers
{
    [MaxLength(32)]
    [Required]
    public int Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string? DuoAccountId { get; set; }

    [MaxLength(64)]
    [Required]
    public string? DuoApiHostname { get; set; }

    [MaxLength(96)]
    [Required]
    public string? DuoCustomerName { get; set; }
}