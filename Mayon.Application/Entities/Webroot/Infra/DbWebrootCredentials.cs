using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.Webroot.Infra;
public class DbWebrootCredentials
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(64)]
    public string Username { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }  // Renamed from "Password"

    [Required]
    public byte[] PasswordSalt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    [Required]
    [MaxLength(64)]
    public string ClientId { get; set; }

    [Required]
    [MaxLength(32)]
    public byte[] ClientSecretHash { get; set; }  // Now this is the hashed client secret

    [MaxLength(32)]
    public string GSMKeyCode { get; set; }
}