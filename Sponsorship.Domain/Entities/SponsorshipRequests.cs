using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("sponsorship_requests")]
public class SponsorshipRequests
{
    [Key]
    [Column("sponsorship_id")]
    public Guid SponsorshipId { get; set; }

    [Required]
    [MaxLength(250)]
    [Column("request_title", TypeName = "varchar(250)")]
    public string RequestTitle { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    [Column("requestor_name", TypeName = "varchar(150)")]
    public string RequestorName { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    [Column("department", TypeName = "character(3)")]
    public string Department { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    [Column("sponsorship_type", TypeName = "character(3)")]
    public string SponsorshipType { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    [Column("event_organisation_name", TypeName = "varchar(250)")]
    public string EventOrganisationName { get; set; } = null!;

    [Required]
    [Column("event_date", TypeName = "date")]
    public DateTime EventDate { get; set; }

    [Required]
    [Column("requested_amount", TypeName = "numeric(18,2)")]
    public decimal RequestedAmount { get; set; }

    [Required]
    [Column("purpose", TypeName = "text")]
    public string Purpose { get; set; } = null!;

    [Column("expected_business_benefit", TypeName = "text")]
    public string? ExpectedBusinessBenefit { get; set; }

    [Column("remarks", TypeName = "text")]
    public string? Remarks { get; set; }

    [Required]
    [MaxLength(3)]
    [Column("status", TypeName = "character(3)")]
    public string Status { get; set; } = "PEN";

    [Required]
    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("updated_by")]
    public Guid? UpdatedBy { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;
}