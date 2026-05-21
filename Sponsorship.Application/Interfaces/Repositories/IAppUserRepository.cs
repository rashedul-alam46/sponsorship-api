using Sponsorship.Application.DTOs;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Interfaces.Repositories;

public interface IAppUserRepository
{
    Task<AppUserReadDto?> GetByIdAsync(Guid id);
    Task<AppUsers?> GetEntityByIdAsync(Guid id);
    Task<IEnumerable<AppUserReadDto>> GetAllAsync();
    Task<AppUsers> AddAsync(AppUsers appUser);
    Task<bool> UpdateAsync(AppUsers appUser);
    Task<bool> DeleteAsync(Guid id);
}

