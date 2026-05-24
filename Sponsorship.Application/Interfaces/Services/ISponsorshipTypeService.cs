using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Interfaces.Services;

public interface ISponsorshipTypeService
{
    Task<ServiceResponse<IEnumerable<SponsorshipTypeReadDto>>> GetSponsorshipTypesAsync();
    Task<ServiceResponse<SponsorshipTypeReadDto>> GetSponsorshipTypeAsync(string typeCode);
    Task<ServiceResponse<SponsorshipTypeReadDto>> AddSponsorshipTypeAsync(SponsorshipTypeCreateDto dto);
    Task<ServiceResponse<SponsorshipTypeReadDto>> UpdateSponsorshipTypeAsync(string typeCode, SponsorshipTypeUpdateDto dto);
    Task<ServiceResponse<bool>> DeleteSponsorshipTypeAsync(string typeCode);

}