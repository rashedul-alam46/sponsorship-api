using System.ComponentModel.DataAnnotations;

namespace Sponsorship.Application.DTOs;

public class AppUserReadDto
{

    public Guid UserId { get; set; }


    public string Email { get; set; }


    public string FirstName { get; set; }


    public string LastName { get; set; }


    public int RoleId { get; set; }
    public string RoleName { get; set; }
}

public class AppUserCreateDto
{


    [Required]
    [MaxLength(250)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int RoleId { get; set; }





}

public class AppUserUpdateDto
{

    [Required]
    [MaxLength(250)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int RoleId { get; set; }


}


