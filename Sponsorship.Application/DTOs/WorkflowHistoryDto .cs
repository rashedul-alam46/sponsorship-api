using System.ComponentModel.DataAnnotations;

namespace Sponsorship.Application.DTOs;

public class WorkflowHistoryReadDto
{

    public Guid WorkflowId { get; set; }


    public Guid SponsorshipId { get; set; }


    public string? Notes { get; set; }


    public Guid ActionBy { get; set; }
    public string? ActionByName { get; set; }

    public DateTime? ActionDate { get; set; }
}

public class WorkflowHistoryCreateDto
{

    [Required]
    public Guid WorkflowId { get; set; }

    [Required]
    public Guid SponsorshipId { get; set; }

    [Required]
    public string? Notes { get; set; }

    [Required]
    public Guid ActionBy { get; set; }

}

