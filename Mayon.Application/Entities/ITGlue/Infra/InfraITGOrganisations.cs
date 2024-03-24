using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mayon.Application.Entities.ITGlue.Infra;
public class InfraITGOrganisations
{
    [MaxLength(16)]
    [Required]
    [Key]
    public int Id { get; set; }

    [MaxLength(16)]
    [Required]
    public int OrgId { get; set; }

    [MaxLength(128)]
    [Required]
    public string Name { get; set; }

    [MaxLength(256)]
    public string? alert { get; set; }

    [MaxLength(1024)]
    [AllowNull]
    public string? description { get; set; }

    [MaxLength(16)]
    public int? OrganizationTypeId { get; set; }

    [MaxLength(64)]
    public string? OrganizationTypeName { get; set; }

    [MaxLength(16)]
    public int? OrganizationStatusId { get; set; }

    [MaxLength(64)]
    public string? OrganizationStatusName { get; set; }

    [MaxLength(8)]
    [Required]
    public bool primary { get; set; }

    [MaxLength(1024)]
    public string? QuickNotes { get; set; }

    [MaxLength(32)]
    public string? ShortName { get; set; }

    [MaxLength(32)]
    public DateTime CreatedAt { get; set; }

    [MaxLength(32)]
    public DateTime UpdatedAt { get; set; }
}