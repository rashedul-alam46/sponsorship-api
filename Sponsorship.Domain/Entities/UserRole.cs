using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

public class UserRoles
{
    [Key]
    [Required]
    public int RoleId { get; set; }

    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string? RoleName { get; set; }

    [MaxLength(250)]
    [Column(TypeName = "varchar(250)")]
    public string? Description { get; set; }

    public bool? Active { get; set; }
}