using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("departments")]
public class Departments
{
    [Key]
    [Required]
    [MaxLength(3)]
    [Column("dep_code", TypeName = "character(3)")]
    public string DepCode { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Column("dep_name", TypeName = "varchar(100)")]
    public string DepName { get; set; } = null!;

    [MaxLength(250)]
    [Column("description", TypeName = "varchar(250)")]
    public string? Description { get; set; }

    [Column("is_active", TypeName = "boolean")]
    public bool IsActive { get; set; } = true;
}