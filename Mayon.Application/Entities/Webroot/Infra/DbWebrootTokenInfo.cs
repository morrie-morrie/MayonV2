using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Webroot.Infra;
public class DbWebrootTokenInfo
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string AccessToken { get; set; }

    [Required]
    [MaxLength(8)]
    public string TokenType { get; set; }

    [Required]
    public int ExpiresIn { get; set; }

    [Required]
    [MaxLength(64)]
    public string RefreshToken { get; set; }

    [Required]
    [MaxLength(256)]
    public string Scope { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}