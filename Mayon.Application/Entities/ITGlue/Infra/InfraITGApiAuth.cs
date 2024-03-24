using System.ComponentModel.DataAnnotations;

namespace Mayon.Application.Entities.ITGlue.Infra;
public class InfraITGApiAuth
{
    [Key]
    public int Id { get; set; }

    [MaxLength(128)]
    public string ITGToken { get; set; }
}