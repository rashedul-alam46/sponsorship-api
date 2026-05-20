using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

public class WorkflowStatus
{
    [Key]
    [Required]
    [MaxLength(3)]
    [Column(TypeName = "character(3)")]
    public string StatusCode { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string StatusName { get; set; } = null!;
}