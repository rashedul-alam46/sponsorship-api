using Microsoft.EntityFrameworkCore;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Repositories;

namespace Sponsorship.Infrastructure.Repositories;

public class DropdownRepository : IDropdownRepository
{
    private readonly SponsorshipDbContext _context;

    public DropdownRepository(SponsorshipDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DropdownItem>> GetDepartmentDropdownAsync()
    {
        return await _context.Departments
            .Select(c => new DropdownItem
            {
                Value = c.DepCode,
                Text = c.DepName
            })
            .OrderBy(c => c.Text)
            .ToListAsync();
    }


    public async Task<IEnumerable<DropdownItem>> GetSponsorshipTypeDropdownAsync()
    {
        return await _context.SponsorshipTypes
            .Select(a => new DropdownItem
            {
                Value = a.TypeCode,
                Text = a.TypeName
            })
            .OrderBy(a => a.Text)
            .ToListAsync();
    }
}