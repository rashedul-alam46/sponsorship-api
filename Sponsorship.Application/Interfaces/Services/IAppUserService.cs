using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Interfaces.Services;

public interface IAppUserService
{
    Task<ServiceResponse<IEnumerable<AppUserReadDto>>> GetAllAppUsersAsync();
    Task<ServiceResponse<AppUserReadDto>> GetAppUserByIdAsync(Guid id);
    Task<ServiceResponse<AppUserReadDto>> AddAppUserAsync(AppUserCreateDto appUserDto);
    Task<ServiceResponse<AppUserReadDto>> UpdateAppUserAsync(Guid id, AppUserUpdateDto appUserDto);
    Task<ServiceResponse<bool>> DeleteAppUserAsync(Guid id);

}