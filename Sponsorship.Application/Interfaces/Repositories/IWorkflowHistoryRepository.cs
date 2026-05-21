using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Interfaces.Repositories;

public interface IWorkflowHistoryRepository
{
    Task<WorkflowHistoryReadDto?> GetByIdAsync(Guid id);
    Task<WorkflowHistories?> GetEntityByIdAsync(Guid id);
    Task<IEnumerable<WorkflowHistoryReadDto>> GetAllAsync(Guid sponsorshipId);
    Task<WorkflowHistories> AddAsync(WorkflowHistories workflowHistory);

}

