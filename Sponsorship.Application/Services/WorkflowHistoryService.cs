using AutoMapper;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Services;

public class WorkflowHistoryService : IWorkflowHistoryService
{

    private readonly IWorkflowHistoryRepository _repo;
    private readonly IServiceResponseFactory _response;
    private readonly IMapper _mapper;


    public WorkflowHistoryService(IWorkflowHistoryRepository repo, IMapper mapper, IServiceResponseFactory response)
    {
        _repo = repo;
        _mapper = mapper;
        _response = response;
    }

    public async Task<ServiceResponse<IEnumerable<WorkflowHistoryReadDto>>> GetWorkflowHistoriesAsync(Guid sponsorshipId)
    {
        var result = await _repo.GetAllAsync(sponsorshipId);

        if (!result.Any())
        {
            return _response.Create<IEnumerable<WorkflowHistoryReadDto>>(
                success: false,
                message: "No workflow histories found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Workflow histories retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<WorkflowHistoryReadDto>> GetWorkflowHistoryAsync(Guid workflowId)
    {
        var result = await _repo.GetByIdAsync(workflowId);
        if (result == null)
        {
            return _response.Create<WorkflowHistoryReadDto>(
                success: false,
                message: "Workflow history not found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Workflow history retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<WorkflowHistoryReadDto>> AddWorkflowHistoryAsync(WorkflowHistoryCreateDto workflowHistoryDto)
    {
        var workflowHistory = _mapper.Map<WorkflowHistories>(workflowHistoryDto);
        workflowHistory.ActionDate = DateTime.UtcNow;

        var savedEntity = await _repo.AddAsync(workflowHistory);

        var resultDto = await _repo.GetByIdAsync(savedEntity.WorkflowId);
        return _response.Create(
             success: true,
             message: "Workflow history added successfully",
             data: _mapper.Map<WorkflowHistoryReadDto>(resultDto)
        );
    }


}