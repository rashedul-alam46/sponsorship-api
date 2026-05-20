using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("user_roles")]
public class UserRoles
{
    [Key]
    [Required]
    [Column("role_id")]
    public int RoleId { get; set; }

    [MaxLength(50)]
    [Column("role_name", TypeName = "varchar(50)")]
    public string? RoleName { get; set; }

    [MaxLength(250)]
    [Column("description", TypeName = "varchar(250)")]
    public string? Description { get; set; }

    [Column("is_active", TypeName = "boolean")]
    public bool? Active { get; set; }
}