using AutoMapper;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;
using Sponsorship.Interfaces.Helpers;

namespace Sponsorship.Application.Services;

public class SponsorshipRequestService : ISponsorshipRequestService
{

    private readonly ISponsorshipRequestRepository _repo;
    private readonly IWorkflowHistoryRepository _repoWorkflowHistory;
    private readonly IServiceResponseFactory _response;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SponsorshipRequestService(ISponsorshipRequestRepository repo, IWorkflowHistoryRepository repoWorkflowHistory, IMapper mapper, IServiceResponseFactory response, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _repoWorkflowHistory = repoWorkflowHistory;
        _mapper = mapper;
        _response = response;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<IEnumerable<SponsorshipRequestReadDto>>> GetSponsorshipRequestsAsync()
    {
        var result = await _repo.GetAllAsync();

        if (!result.Any())
        {
            return _response.Create<IEnumerable<SponsorshipRequestReadDto>>(
                success: false,
                message: "No sponsorship requests found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship requests retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<SponsorshipRequestReadDto>> GetSponsorshipRequestAsync(Guid id)
    {
        var result = await _repo.GetByIdAsync(id);
        if (result == null)
        {
            return _response.Create<SponsorshipRequestReadDto>(
                success: false,
                message: "Sponsorship request not found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship request retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<SponsorshipRequestReadDto>> AddSponsorshipRequestAsync(SponsorshipRequestCreateDto dto)
    {
        try
        {
            var result = await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Sponsorship request creation logic
                var sponsorshipRequest = _mapper.Map<SponsorshipRequests>(dto);

                sponsorshipRequest.CreatedAt = DateTime.UtcNow;
                sponsorshipRequest.Status = "PMA";

                var savedEntity = await _repo.AddAsync(sponsorshipRequest);

                // Add workflow history
                await _repoWorkflowHistory.AddAsync(new WorkflowHistories
                {
                    SponsorshipId = savedEntity.SponsorshipId,
                    Notes = "New",
                    ActionBy = savedEntity.CreatedBy ?? Guid.Empty,
                    ActionDate = DateTime.UtcNow
                });

                var resultDto = await _repo.GetByIdAsync(savedEntity.SponsorshipId);

                return _response.Create(
                    success: true,
                    message: "Sponsorship request added successfully",
                    data: _mapper.Map<SponsorshipRequestReadDto>(resultDto)
                );
            });

            return result;
        }
        catch (Exception ex)
        {
            return _response.Create<SponsorshipRequestReadDto>(
                false,
                ex.Message,
                null
            );
        }
    }
    public async Task<ServiceResponse<SponsorshipRequestReadDto>> UpdateSponsorshipRequestAsync(Guid id, SponsorshipRequestUpdateDto dto)
    {
        var existing = await _repo.GetEntityByIdAsync(id);
        if (existing == null)
        {
            return _response.Create<SponsorshipRequestReadDto>(
                success: false,
                message: "Sponsorship request not found",
                data: null
            );
        }
        _mapper.Map(dto, existing);
        existing.UpdatedAt = DateTime.UtcNow;

        var updated = await _repo.UpdateAsync(existing);


        var resultDto = await _repo.GetByIdAsync(id);
        return _response.Create(
             success: true,
             message: "Sponsorship request updated successfully",
             data: _mapper.Map<SponsorshipRequestReadDto>(resultDto)
        );
    }
    public async Task<ServiceResponse<bool>> DeleteSponsorshipRequestAsync(Guid id)
    {
        var result = await _repo.DeleteAsync(id);
        if (!result)
        {
            return _response.Create<bool>(
                success: false,
                message: "Sponsorship request not found",
                data: false
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship request deleted successfully",
             data: true
        );
    }

    public async Task<ServiceResponse<bool>> UpdateStatusAsync(Guid id, string status)
    {
        var result = await _repo.UpdateStatusAsync(id, status);
        if (!result)
        {
            return _response.Create<bool>(
                success: false,
                message: "Sponsorship request not found or status update failed",
                data: false
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship request status updated successfully",
             data: true
        );
    }
}