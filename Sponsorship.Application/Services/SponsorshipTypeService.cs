using AutoMapper;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;
using Sponsorship.Interfaces.Helpers;

namespace Sponsorship.Application.Services;

public class SponsorshipTypeService : ISponsorshipTypeService
{

    private readonly ISponsorshipTypeRepository _repo;
    private readonly IWorkflowHistoryRepository _repoWorkflowHistory;
    private readonly IServiceResponseFactory _response;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SponsorshipTypeService(ISponsorshipTypeRepository repo, IWorkflowHistoryRepository repoWorkflowHistory, IMapper mapper, IServiceResponseFactory response, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _repoWorkflowHistory = repoWorkflowHistory;
        _mapper = mapper;
        _response = response;
        _unitOfWork = unitOfWork;
    }

    // Get all sponsorship types
    public async Task<ServiceResponse<IEnumerable<SponsorshipTypeReadDto>>> GetSponsorshipTypesAsync()
    {
        var result = await _repo.GetAllAsync();

        if (!result.Any())
        {
            return _response.Create<IEnumerable<SponsorshipTypeReadDto>>(
                success: false,
                message: "No sponsorship types found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship types retrieved successfully",
             data: result
        );
    }

    // Get sponsorship type by ID
    public async Task<ServiceResponse<SponsorshipTypeReadDto>> GetSponsorshipTypeAsync(string typeCode)
    {
        var result = await _repo.GetByIdAsync(typeCode);
        if (result == null)
        {
            return _response.Create<SponsorshipTypeReadDto>(
                success: false,
                message: "Sponsorship type not found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship type retrieved successfully",
             data: result
        );
    }

    // Add new sponsorship type
    public async Task<ServiceResponse<SponsorshipTypeReadDto>> AddSponsorshipTypeAsync(SponsorshipTypeCreateDto dto)
    {
        var entity = _mapper.Map<SponsorshipTypes>(dto);
        var created = await _repo.AddAsync(entity);

        var resultDto = await _repo.GetByIdAsync(created.TypeCode);
        return _response.Create(
             success: true,
             message: "Sponsorship type created successfully",
             data: _mapper.Map<SponsorshipTypeReadDto>(resultDto)
        );
    }


    // Update sponsorship type
    public async Task<ServiceResponse<SponsorshipTypeReadDto>> UpdateSponsorshipTypeAsync(string typeCode, SponsorshipTypeUpdateDto dto)
    {
        var existing = await _repo.GetEntityByIdAsync(typeCode);
        if (existing == null)
        {
            return _response.Create<SponsorshipTypeReadDto>(
                success: false,
                message: "Sponsorship type not found",
                data: null
            );
        }
        _mapper.Map(dto, existing);


        var updated = await _repo.UpdateAsync(existing);


        var resultDto = await _repo.GetByIdAsync(typeCode);
        return _response.Create(
             success: true,
             message: "Sponsorship type updated successfully",
             data: _mapper.Map<SponsorshipTypeReadDto>(resultDto)
        );
    }

    // Delete sponsorship type
    public async Task<ServiceResponse<bool>> DeleteSponsorshipTypeAsync(string typeCode)
    {
        var result = await _repo.DeleteAsync(typeCode);
        if (!result)
        {
            return _response.Create<bool>(
                success: false,
                message: "Sponsorship type not found",
                data: false
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship type deleted successfully",
             data: true
        );
    }


}