using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Interfaces.Repositories;

public interface ISponsorshipRequestRepository
{
    Task<SponsorshipRequestReadDto?> GetByIdAsync(Guid id);
    Task<SponsorshipRequests?> GetEntityByIdAsync(Guid id);
    Task<IEnumerable<SponsorshipRequestReadDto>> GetAllAsync();
    Task<SponsorshipRequests> AddAsync(SponsorshipRequests sponsorshipRequest);
    Task<bool> UpdateAsync(SponsorshipRequests sponsorshipRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsBySponsorshipIdAsync(Guid sponsorshipRequestId);
}

