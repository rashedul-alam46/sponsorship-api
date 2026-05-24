using System.ComponentModel.DataAnnotations;

namespace Sponsorship.Application.DTOs;

public class SponsorshipTypeReadDto
{

    public string TypeCode { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class SponsorshipTypeCreateDto
{

    [Required]
    [MaxLength(3)]
    public string TypeCode { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string TypeName { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class SponsorshipTypeUpdateDto
{
    [Required]
    [MaxLength(3)]
    public string TypeCode { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string TypeName { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
