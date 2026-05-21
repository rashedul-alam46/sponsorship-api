using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sponsorship.Domain.Entities;

[Table("workflow_histories")]
public class WorkflowHistories
{
    [Key]
    [Column("workflow_id")]
    public Guid WorkflowId { get; set; }

    [Required]
    [Column("sponsorship_id")]
    public Guid SponsorshipId { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }

    [Required]
    [Column("action_by")]
    public Guid ActionBy { get; set; }

    [Column("action_date")]
    public DateTime? ActionDate { get; set; }
}