using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Interfaces.Repositories;

public interface ISponsorshipTypeRepository
{
    Task<SponsorshipTypeReadDto?> GetByIdAsync(string id);
    Task<SponsorshipTypes?> GetEntityByIdAsync(string id);
    Task<IEnumerable<SponsorshipTypeReadDto>> GetAllAsync();
    Task<SponsorshipTypes> AddAsync(SponsorshipTypes sponsorshipType);
    Task<bool> UpdateAsync(SponsorshipTypes sponsorshipType);
    Task<bool> DeleteAsync(string typeCode);
    Task<bool> ExistsBySponsorshipIdAsync(string typeCode);

}

