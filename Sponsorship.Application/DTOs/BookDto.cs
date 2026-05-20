using System.ComponentModel.DataAnnotations;

namespace LibraryGrid.Application.DTOs;

public class BookReadDto
{
    public Guid BookId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? AuthorName { get; set; }

    public string? CategoryName { get; set; }

    public string? PublisherName { get; set; }
    public DateTime? PublishedAt { get; set; }

    public string? Isbn { get; set; }

    public decimal? Price { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}

public class BookCreateDto
{
    [Required]
    [StringLength(150)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? PublisherId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? PublishedAt { get; set; }

    [StringLength(20)]
    public string? Isbn { get; set; }

    [Range(0, 9999.99)]
    public decimal? Price { get; set; }

}

public class BookUpdateDto
{
    [Required]
    [StringLength(150)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? PublisherId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? PublishedAt { get; set; }

    [StringLength(20)]
    public string? Isbn { get; set; }

    [Range(0, 9999.99)]
    public decimal? Price { get; set; }
}
