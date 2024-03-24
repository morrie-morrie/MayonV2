using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Duo.Infra;
public class AdminMsApiAuth
{
    [Key]
    public int Id { get; set; }

    [MaxLength(64)]
    public string MsTenantId { get; set; }

    [MaxLength(64)]
    public string MsClientId { get; set; }

    [MaxLength(64)]
    public string MsClientSecret { get; set; }

    [MaxLength(1024)]
    public string MsRefreshToken { get; set; }
}