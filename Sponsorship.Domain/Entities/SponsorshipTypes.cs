using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

public class SponsorshipType
{
    [Key]
    [Required]
    [MaxLength(3)]
    [Column(TypeName = "character(3)")]
    public string TypeCode { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string TypeName { get; set; } = null!;

    [MaxLength(250)]
    [Column(TypeName = "varchar(250)")]
    public string? Description { get; set; }

    [Column(TypeName = "boolean")]
    public bool IsActive { get; set; } = true;
}