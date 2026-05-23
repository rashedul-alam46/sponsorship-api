using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Interfaces.Services;

public interface ISponsorshipRequestService
{
    Task<ServiceResponse<IEnumerable<SponsorshipRequestReadDto>>> GetSponsorshipRequestsAsync(Guid userId, int roleId);
    Task<ServiceResponse<SponsorshipRequestReadDto>> GetSponsorshipRequestAsync(Guid id);
    Task<ServiceResponse<SponsorshipRequestReadDto>> AddSponsorshipRequestAsync(SponsorshipRequestCreateDto sponsorshipRequestDto);
    Task<ServiceResponse<SponsorshipRequestReadDto>> UpdateSponsorshipRequestAsync(Guid id, SponsorshipRequestUpdateDto sponsorshipRequestDto);
    Task<ServiceResponse<bool>> DeleteSponsorshipRequestAsync(Guid id);
    Task<ServiceResponse<bool>> UpdateStatusAsync(SponsorshipRequestStatusUpdateDto dto);
    Task<ServiceResponse<IEnumerable<WorkflowHistoryReadDto>>> GetSponsorshipRequestHistoryAsync(Guid sponsorshipId);
}