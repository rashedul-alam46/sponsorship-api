using Microsoft.EntityFrameworkCore;
using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Application.Interfaces.Repositories;

namespace Sponsorship.Infrastructure.Repositories;

public class SponsorshipRequestRepository : ISponsorshipRequestRepository
{
    private readonly SponsorshipDbContext _context;

    public SponsorshipRequestRepository(SponsorshipDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<SponsorshipRequestReadDto>> GetAllAsync()
    {
        var query = from a in _context.SponsorshipRequests
                    join d in _context.Departments
                        on a.Department equals d.DepCode
                    join s in _context.SponsorshipTypes
                        on a.SponsorshipType equals s.TypeCode
                    select new SponsorshipRequestReadDto
                    {
                        SponsorshipId = a.SponsorshipId,
                        RequestTitle = a.RequestTitle,
                        RequestorName = a.RequestorName,
                        DepartmentCode = d.DepCode,
                        DepartmentName = d.DepName,
                        SponsorshipType = s.TypeCode,
                        SponsorshipTypeName = s.TypeName,
                        EventOrganisationName = a.EventOrganisationName,
                        EventDate = a.EventDate,
                        RequestedAmount = a.RequestedAmount,
                        Purpose = a.Purpose,
                        ExpectedBusinessBenefit = a.ExpectedBusinessBenefit,
                        Remarks = a.Remarks
                    };

        return await query.ToListAsync();
    }

    public async Task<SponsorshipRequestReadDto?> GetByIdAsync(Guid id)
    {
        var query = from a in _context.SponsorshipRequests
                    join d in _context.Departments
                        on a.Department equals d.DepCode
                    join s in _context.SponsorshipTypes
                        on a.SponsorshipType equals s.TypeCode
                    where a.SponsorshipId == id
                    select new SponsorshipRequestReadDto
                    {
                        SponsorshipId = a.SponsorshipId,
                        RequestTitle = a.RequestTitle,
                        RequestorName = a.RequestorName,
                        DepartmentCode = d.DepCode,
                        DepartmentName = d.DepName,
                        SponsorshipType = s.TypeCode,
                        SponsorshipTypeName = s.TypeName,
                        EventOrganisationName = a.EventOrganisationName,
                        EventDate = a.EventDate,
                        RequestedAmount = a.RequestedAmount,
                        Purpose = a.Purpose,
                        ExpectedBusinessBenefit = a.ExpectedBusinessBenefit,
                        Remarks = a.Remarks
                    };

        return await query.FirstOrDefaultAsync();
    }



    public async Task<SponsorshipRequests?> GetEntityByIdAsync(Guid id)
    {

        return await _context.SponsorshipRequests.Where(s => s.SponsorshipId == id).FirstOrDefaultAsync();
    }
    public async Task<SponsorshipRequests> AddAsync(SponsorshipRequests sponsorshipRequest)
    {
        _context.Set<SponsorshipRequests>().Add(sponsorshipRequest);
        await _context.SaveChangesAsync();
        return sponsorshipRequest;
    }

    public async Task<bool> UpdateAsync(SponsorshipRequests sponsorshipRequest)
    {
        _context.Set<SponsorshipRequests>().Update(sponsorshipRequest);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var sponsorshipRequest = await _context.SponsorshipRequests.FindAsync(id);
        if (sponsorshipRequest == null) return false;

        _context.SponsorshipRequests.Remove(sponsorshipRequest);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsBySponsorshipIdAsync(Guid sponsorshipId)
    {
        return await _context.SponsorshipRequests.AnyAsync(a => a.SponsorshipId == sponsorshipId);
    }
}
