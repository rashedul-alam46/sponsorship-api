using Microsoft.EntityFrameworkCore;
using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Application.Interfaces.Repositories;

namespace Sponsorship.Infrastructure.Repositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly SponsorshipDbContext _context;

    public AppUserRepository(SponsorshipDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<AppUserReadDto>> GetAllAsync()
    {
        var query = from a in _context.AppUsers

                    join r in _context.UserRoles
                    on a.RoleId equals r.RoleId
                    select new AppUserReadDto
                    {
                        UserId = a.UserId,
                        Email = a.Email,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        RoleId = a.RoleId,
                        RoleName = r.RoleName
                    };

        return await query.ToListAsync();
    }

    public async Task<AppUserReadDto?> GetByIdAsync(Guid id)
    {
        var query = from a in _context.AppUsers
                    join r in _context.UserRoles
                        on a.RoleId equals r.RoleId
                    where a.UserId == id
                    select new AppUserReadDto
                    {
                        UserId = a.UserId,
                        Email = a.Email,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        RoleId = a.RoleId,
                        RoleName = r.RoleName
                    };

        return await query.FirstOrDefaultAsync();
    }


    public async Task<AppUsers?> GetEntityByIdAsync(Guid id)
    {

        return await _context.AppUsers.Where(a => a.UserId == id).FirstOrDefaultAsync();
    }
    public async Task<AppUsers> AddAsync(AppUsers appUser)
    {
        _context.Set<AppUsers>().Add(appUser);
        await _context.SaveChangesAsync();
        return appUser;
    }

    public async Task<bool> UpdateAsync(AppUsers appUser)
    {
        var existingAppUser = await _context.AppUsers.FindAsync(appUser.UserId);
        if (existingAppUser == null)
        {
            return false;
        }

        existingAppUser.Email = appUser.Email;
        existingAppUser.FirstName = appUser.FirstName;
        existingAppUser.LastName = appUser.LastName;
        _context.AppUsers.Update(existingAppUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var appUser = await _context.AppUsers.FindAsync(id);
        if (appUser == null)
        {
            return false;
        }

        _context.AppUsers.Remove(appUser);
        await _context.SaveChangesAsync();
        return true;
    }

    // Update user password by tenantId and userId
    public async Task<bool> UpdatePasswordAsync(AppUsers appUsers)
    {
        if (appUsers == null)
            throw new ArgumentNullException(nameof(appUsers));

        _context.Set<AppUsers>().Attach(appUsers);

        _context.Entry(appUsers).Property(x => x.PasswordHash).IsModified = true;
        _context.Entry(appUsers).Property(x => x.PassSetOn).IsModified = true;

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;
    }

    public async Task<SignInUserDto?> GetUserForSignInAsync(string email)
    {
        var result = await (from i in _context.Set<AppUsers>()
                            where i.Email == email
                            select new SignInUserDto
                            {
                                UserId = i.UserId,
                                Email = i.Email,
                                FirstName = i.FirstName,
                                LastName = i.LastName,
                                RoleId = i.RoleId,
                                PasswordHash = i.PasswordHash
                            })
            .FirstOrDefaultAsync();
        return result;
    }

}
