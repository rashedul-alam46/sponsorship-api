using System.ComponentModel.DataAnnotations;

namespace LibraryGrid.Application.DTOs;

public class CategoryReadDto
{
    public Guid CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

public class CategoryCreateDto
{
    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }
}

public class CategoryUpdateDto
{
    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

}
