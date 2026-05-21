using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("app_users")]
public class AppUsers
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("email", TypeName = "varchar(250)")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("first_name", TypeName = "varchar(100)")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("last_name", TypeName = "varchar(100)")]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("password_hash", TypeName = "varchar(500)")]
    public string? PasswordHash { get; set; }

    [Column("pass_set_on")]
    public DateTime? PassSetOn { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("is_active", TypeName = "boolean")]
    public bool? IsActive { get; set; }


    [Required]
    [Column("role_id", TypeName = "character(3)")]
    public int RoleId { get; set; } = 0;
}