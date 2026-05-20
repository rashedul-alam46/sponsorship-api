using System.ComponentModel.DataAnnotations;

namespace LibraryGrid.Application.DTOs;

public class PublisherReadDto
{
    public Guid PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? CountryName { get; set; }
    public string? Zip { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PublisherCreateDto
{
    [Required]
    [StringLength(100)]
    public string PublisherName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Phone]
    [StringLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? Address1 { get; set; }

    [StringLength(100)]
    public string? Address2 { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(2)]
    public string? Country { get; set; }

    [StringLength(50)]
    public string? Zip { get; set; }

}

public class PublisherUpdateDto
{
    [Required]
    [StringLength(100)]
    public string PublisherName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Phone]
    [StringLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? Address1 { get; set; }

    [StringLength(100)]
    public string? Address2 { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(2)]
    public string? Country { get; set; }

    [StringLength(50)]
    public string? Zip { get; set; }
}