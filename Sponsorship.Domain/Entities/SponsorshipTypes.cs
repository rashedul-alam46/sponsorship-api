using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("sponsorship_types")]
public class SponsorshipTypes
{
    [Key]
    [Required]
    [MaxLength(3)]
    [Column("type_code", TypeName = "character(3)")]
    public string TypeCode { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Column("type_name", TypeName = "varchar(100)")]
    public string TypeName { get; set; } = null!;

    [MaxLength(250)]
    [Column("description", TypeName = "varchar(250)")]
    public string? Description { get; set; }

    [Column("is_active", TypeName = "boolean")]
    public bool IsActive { get; set; } = true;
}