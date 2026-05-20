using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("workflow_status")]
public class WorkflowStatus
{
    [Key]
    [Required]
    [MaxLength(3)]
    [Column("status_code", TypeName = "character(3)")]
    public string StatusCode { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Column("status_name", TypeName = "varchar(50)")]
    public string StatusName { get; set; } = null!;
}