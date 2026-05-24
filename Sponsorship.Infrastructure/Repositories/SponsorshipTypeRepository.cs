using Microsoft.EntityFrameworkCore;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Domain.Entities;
using Sponsorship.Infrastructure.Data;


namespace Sponsorship.Infrastructure.Repositories;

public class SponsorshipTypeRepository : ISponsorshipTypeRepository
{
    private readonly SponsorshipDbContext _context;

    public SponsorshipTypeRepository(SponsorshipDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<SponsorshipTypeReadDto>> GetAllAsync()
    {
        var sponsorshipTypes = await _context.SponsorshipTypes.ToListAsync();
        return sponsorshipTypes.Select(st => new SponsorshipTypeReadDto
        {
            TypeCode = st.TypeCode,
            TypeName = st.TypeName,
            Description = st.Description,
            IsActive = st.IsActive
        });
    }

    public async Task<SponsorshipTypeReadDto?> GetByIdAsync(string id)
    {
        var sponsorshipType = await _context.SponsorshipTypes.FindAsync(id);
        if (sponsorshipType == null) return null;

        return new SponsorshipTypeReadDto
        {
            TypeCode = sponsorshipType.TypeCode,
            TypeName = sponsorshipType.TypeName,
            Description = sponsorshipType.Description,
            IsActive = sponsorshipType.IsActive
        };
    }


    public async Task<SponsorshipTypes?> GetEntityByIdAsync(string typeCode)
    {

        return await _context.SponsorshipTypes.Where(s => s.TypeCode == typeCode).FirstOrDefaultAsync();
    }
    public async Task<SponsorshipTypes> AddAsync(SponsorshipTypes sponsorshipType)
    {
        _context.Set<SponsorshipTypes>().Add(sponsorshipType);
        await _context.SaveChangesAsync();
        return sponsorshipType;
    }

    public async Task<bool> UpdateAsync(SponsorshipTypes sponsorshipType)
    {
        _context.Set<SponsorshipTypes>().Update(sponsorshipType);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(string typeCode)
    {
        var sponsorshipType = await _context.SponsorshipTypes.FirstOrDefaultAsync(s => s.TypeCode == typeCode);
        if (sponsorshipType == null) return false;

        _context.SponsorshipTypes.Remove(sponsorshipType);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExistsBySponsorshipIdAsync(string typeCode)
    {
        return await _context.SponsorshipTypes.AnyAsync(a => a.TypeCode == typeCode);
    }


}
