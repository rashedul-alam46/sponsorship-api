using System.ComponentModel.DataAnnotations;


namespace Sponsorship.Application.DTOs;

public class SignInDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(250, ErrorMessage = "Email max length is 250")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password must be at least 3 characters long")]
    public string Password { get; set; } = string.Empty;

}

public class SignInResponseDto
{
    // Tokens
    public string? AccessToken { get; set; } = string.Empty;
    public string? RefreshToken { get; set; } = string.Empty;
    public DateTime? ExpiresAt { get; set; }

    // User info
    public Guid? UserId { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int RoleId { get; set; } = 0;
}

public class SignInUserDto
{

    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid? TenantId { get; set; }
    public int RoleId { get; set; }
    public string StatusCode { get; set; }
    public string? PasswordHash { get; set; }
}

public class ChangePasswordDto
{
    [Required(ErrorMessage = "UserId is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Current password is required")]
    public string CurrentPassword { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string NewPassword { get; set; }

    [Required]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}

public class ChangeEmailDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(200, ErrorMessage = "Email max length is 200")]
    public string Email { get; set; }
}