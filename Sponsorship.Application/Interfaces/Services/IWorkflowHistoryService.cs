using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Interfaces.Services;

public interface IWorkflowHistoryService
{
    Task<ServiceResponse<IEnumerable<WorkflowHistoryReadDto>>> GetWorkflowHistoriesAsync(Guid sponsorshipId);
    Task<ServiceResponse<WorkflowHistoryReadDto>> GetWorkflowHistoryAsync(Guid workflowId);
    Task<ServiceResponse<WorkflowHistoryReadDto>> AddWorkflowHistoryAsync(WorkflowHistoryCreateDto workflowHistoryDto);

}