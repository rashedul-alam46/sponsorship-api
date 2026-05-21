using Microsoft.EntityFrameworkCore;
using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Application.Interfaces.Repositories;

namespace Sponsorship.Infrastructure.Repositories;

public class WorkflowHistoryRepository : IWorkflowHistoryRepository
{
    private readonly SponsorshipDbContext _context;

    public WorkflowHistoryRepository(SponsorshipDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<WorkflowHistoryReadDto>> GetAllAsync(Guid sponsorshipId)
    {
        var query = from a in _context.WorkflowHistories
                    join d in _context.AppUsers
                        on a.ActionBy equals d.UserId
                    where a.SponsorshipId == sponsorshipId

                    select new WorkflowHistoryReadDto
                    {
                        WorkflowId = a.WorkflowId,
                        SponsorshipId = a.SponsorshipId,
                        Notes = a.Notes,
                        ActionBy = a.ActionBy,
                        ActionDate = a.ActionDate,
                        ActionByName = d.FirstName + " " + d.LastName
                    };

        return await query.ToListAsync();
    }

    public async Task<WorkflowHistoryReadDto?> GetByIdAsync(Guid id)
    {
        var query = from a in _context.WorkflowHistories
                    join d in _context.AppUsers
                        on a.ActionBy equals d.UserId
                    where a.WorkflowId == id

                    select new WorkflowHistoryReadDto
                    {
                        WorkflowId = a.WorkflowId,
                        SponsorshipId = a.SponsorshipId,
                        Notes = a.Notes,
                        ActionBy = a.ActionBy,
                        ActionDate = a.ActionDate,
                        ActionByName = d.FirstName + " " + d.LastName
                    };

        return await query.FirstOrDefaultAsync();



    }



    public async Task<WorkflowHistories?> GetEntityByIdAsync(Guid id)
    {

        return await _context.WorkflowHistories.Where(w => w.WorkflowId == id).FirstOrDefaultAsync();
    }
    public async Task<WorkflowHistories> AddAsync(WorkflowHistories workflowHistory)
    {
        _context.Set<WorkflowHistories>().Add(workflowHistory);
        await _context.SaveChangesAsync();
        return workflowHistory;
    }


}
