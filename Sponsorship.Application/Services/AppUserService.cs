using AutoMapper;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Sponsorship.Application.Services;

public class AppUserService : IAppUserService
{

    private readonly IAppUserRepository _repo;
    private readonly IServiceResponseFactory _response;
    private readonly IMapper _mapper;


    public AppUserService(IAppUserRepository repo, IMapper mapper, IServiceResponseFactory response)
    {
        _repo = repo;
        _mapper = mapper;
        _response = response;
    }

    public async Task<ServiceResponse<IEnumerable<AppUserReadDto>>> GetAllAppUsersAsync()
    {
        var result = await _repo.GetAllAsync();

        if (!result.Any())
        {
            return _response.Create<IEnumerable<AppUserReadDto>>(
                success: false,
                message: "No app users found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "App users retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<AppUserReadDto>> GetAppUserByIdAsync(Guid id)
    {
        var result = await _repo.GetByIdAsync(id);
        if (result == null)
        {
            return _response.Create<AppUserReadDto>(
                success: false,
                message: "App user not found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "App user retrieved successfully",
             data: result
        );
    }
    public async Task<ServiceResponse<AppUserReadDto>> AddAppUserAsync(AppUserCreateDto appUserDto)
    {
        var appUser = _mapper.Map<AppUsers>(appUserDto);
        appUser.UserId = Guid.NewGuid();
        appUser.CreatedAt = DateTime.UtcNow;
        appUser.IsActive = true;

        var passwordHasher = new PasswordHasher<object>();
        appUser.PasswordHash = passwordHasher.HashPassword(appUserDto, appUserDto.Password);

        var savedEntity = await _repo.AddAsync(appUser);

        var resultDto = await _repo.GetByIdAsync(savedEntity.UserId);
        return _response.Create(
             success: true,
             message: "App user added successfully",
             data: _mapper.Map<AppUserReadDto>(resultDto)
        );
    }

    public async Task<ServiceResponse<AppUserReadDto>> UpdateAppUserAsync(Guid id, AppUserUpdateDto appUserDto)
    {
        var existingEntity = await _repo.GetEntityByIdAsync(id);
        if (existingEntity == null)
        {
            return _response.Create<AppUserReadDto>(
                success: false,
                message: "App user not found",
                data: null
            );
        }

        _mapper.Map(appUserDto, existingEntity);
        existingEntity.UpdatedAt = DateTime.UtcNow;

        var passwordHasher = new PasswordHasher<object>();
        existingEntity.PasswordHash = passwordHasher.HashPassword(appUserDto, appUserDto.Password);

        var updateResult = await _repo.UpdateAsync(existingEntity);
        if (!updateResult)
        {
            return _response.Create<AppUserReadDto>(
                success: false,
                message: "Failed to update app user",
                data: null
            );
        }

        var resultDto = await _repo.GetByIdAsync(id);
        return _response.Create(
             success: true,
             message: "App user updated successfully",
             data: _mapper.Map<AppUserReadDto>(resultDto)
        );
    }

    public async Task<ServiceResponse<bool>> DeleteAppUserAsync(Guid id)
    {
        var existingEntity = await _repo.GetEntityByIdAsync(id);
        if (existingEntity == null)
        {
            return _response.Create<bool>(
                success: false,
                message: "App user not found",
                data: false
            );
        }

        var deleteResult = await _repo.DeleteAsync(id);
        if (!deleteResult)
        {
            return _response.Create<bool>(
                success: false,
                message: "Failed to delete app user",
                data: false
            );
        }

        return _response.Create(
             success: true,
             message: "App user deleted successfully",
             data: true
        );
    }
}



