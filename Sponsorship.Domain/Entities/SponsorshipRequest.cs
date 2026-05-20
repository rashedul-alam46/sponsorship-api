using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

public class SponsorshipRequests
{
    [Key]
    public Guid SponsorshipId { get; set; }

    [Required]
    [MaxLength(250)]
    [Column(TypeName = "varchar(250)")]
    public string RequestTitle { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    [Column(TypeName = "varchar(150)")]
    public string RequestorName { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    [Column(TypeName = "character(3)")]
    public string Department { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    [Column(TypeName = "character(3)")]
    public string SponsorshipType { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    [Column(TypeName = "varchar(250)")]
    public string EventOrganisationName { get; set; } = null!;

    [Required]
    [Column(TypeName = "date")]
    public DateTime EventDate { get; set; }

    [Required]
    [Column(TypeName = "numeric(18,2)")]
    public decimal RequestedAmount { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Purpose { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? ExpectedBusinessBenefit { get; set; }

    [Column(TypeName = "text")]
    public string? Remarks { get; set; }

    [Required]
    [MaxLength(3)]
    [Column(TypeName = "character(3)")]
    public string Status { get; set; } = "PEN";

    [Required]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }
}