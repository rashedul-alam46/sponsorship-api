using System.ComponentModel.DataAnnotations;

namespace Sponsorship.Application.DTOs;

public class SponsorshipRequestReadDto
{
    public Guid SponsorshipId { get; set; }
    public string RequestTitle { get; set; }

    public string RequestorName { get; set; }
    public string DepartmentCode { get; set; }
    public string DepartmentName { get; set; }

    public string SponsorshipType { get; set; }
    public string SponsorshipTypeName { get; set; }

    public string EventOrganisationName { get; set; }
    public DateTime EventDate { get; set; }
    public decimal RequestedAmount { get; set; }
    public string Purpose { get; set; }
    public string? ExpectedBusinessBenefit { get; set; }
    public string? Remarks { get; set; }

    public string StatusCode { get; set; }
    public string StatusName { get; set; }
}

public class SponsorshipRequestCreateDto
{


    [Required]
    [MaxLength(250)]
    public string RequestTitle { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    public string RequestorName { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    public string Department { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    public string SponsorshipType { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string EventOrganisationName { get; set; } = null!;

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public decimal RequestedAmount { get; set; }

    [Required]
    public string Purpose { get; set; } = null!;

    public string? ExpectedBusinessBenefit { get; set; }
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? SaveAsDraft { get; set; }
}

public class SponsorshipRequestUpdateDto
{
    [Required]
    [MaxLength(250)]
    public string RequestTitle { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    public string RequestorName { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    public string Department { get; set; } = null!;

    [Required]
    [MaxLength(3)]
    public string SponsorshipType { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string EventOrganisationName { get; set; } = null!;

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public decimal RequestedAmount { get; set; }

    [Required]
    public string Purpose { get; set; } = null!;

    public string? ExpectedBusinessBenefit { get; set; }
    public string? Remarks { get; set; }
    public string? StatusCode { get; set; }
    public Guid? UpdatedBy { get; set; }
}


public class SponsorshipRequestStatusUpdateDto
{
    [Required]
    public Guid SponsorshipId { get; set; }

    [Required]
    public string? StatusCode { get; set; }

    public Guid? UpdatedBy { get; set; }
}
