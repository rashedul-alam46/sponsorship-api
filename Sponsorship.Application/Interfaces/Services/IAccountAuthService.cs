using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;

namespace Sponsorship.Application.Interfaces.Services;

public interface IAccountAuthService
{
    Task<ServiceResponse<bool>> ChangePasswordAsync(ChangePasswordDto dto);
    Task<ServiceResponse<SignInResponseDto>> SignInAsync(SignInDto dto);
    Task<ServiceResponse<bool>> SignOutAsync();


}

