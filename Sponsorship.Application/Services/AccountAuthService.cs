using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Wrappers;
using Sponsorship.Domain.Entities;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.DTOs;

namespace Sponsorship.Application.Services;

public class AccountAuthService : IAccountAuthService
{
    private readonly IAppUserRepository _repo;
    private readonly IMapper _mapper;
    private readonly IServiceResponseFactory _response;

    public AccountAuthService(IAppUserRepository repo, IMapper mapper, IServiceResponseFactory response)
    {
        _repo = repo;
        _mapper = mapper;
        _response = response;
    }

    // Change password for a system user
    public async Task<ServiceResponse<bool>> ChangePasswordAsync(ChangePasswordDto dto)
    {
        // Input validation
        if (dto == null)
            return _response.Create(false, "Invalid request.", false);

        if (string.IsNullOrWhiteSpace(dto.CurrentPassword) ||
            string.IsNullOrWhiteSpace(dto.NewPassword) ||
            string.IsNullOrWhiteSpace(dto.ConfirmPassword))
        {
            return _response.Create(false, "Password fields cannot be empty.", false);
        }

        if (dto.NewPassword != dto.ConfirmPassword)
        {
            return _response.Create(false, "New passwords do not match.", false);
        }

        if (dto.NewPassword.Length < 6)
        {
            return _response.Create(false, "Password must be at least 6 characters long.", false);
        }

        // Get current user
        var userFromDb = await _repo.GetEntityByIdAsync(dto.UserId);

        if (userFromDb is null)
        {
            return _response.Create(false, "User not found.", false);
        }

        AppUsers currentUser = new AppUsers();
        currentUser.UserId = dto.UserId;
        currentUser.PasswordHash = userFromDb.PasswordHash;
        currentUser.PassSetOn = userFromDb.PassSetOn;


        // Verify current password
        var hasher = new PasswordHasher<AppUsers>();

        var verificationResult = hasher.VerifyHashedPassword(
            currentUser,
            currentUser.PasswordHash,
            dto.CurrentPassword
        );

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return _response.Create(false, "Current password is incorrect.", false);
        }

        // Hash new password
        string newHashedPassword = hasher.HashPassword(currentUser, dto.NewPassword);

        // Prepare minimal entity for update
        AppUsers updateUser = new AppUsers
        {
            UserId = dto.UserId,
            PasswordHash = newHashedPassword,
            PassSetOn = DateTime.UtcNow
        };

        // Save to database
        var isUpdated = await _repo.UpdatePasswordAsync(updateUser);

        if (!isUpdated)
        {
            return _response.Create(false, "Failed to change password.", false);
        }

        return _response.Create(true, "Password changed successfully.", true);

    }




    // Sign in a user with email and password
    public async Task<ServiceResponse<SignInResponseDto>> SignInAsync(SignInDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
        {
            return _response.Create<SignInResponseDto>(false, "Invalid credentials");
        }

        // Get user by email
        var user = await _repo.GetUserForSignInAsync(dto.Email);
        if (user == null || user.StatusCode != "ACT")
        {
            return _response.Create<SignInResponseDto>(false, "Invalid credentials");
        }

        // Verify password
        var passwordHasher = new PasswordHasher<SignInUserDto>();
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return _response.Create<SignInResponseDto>(false, "Invalid credentials");
        }

        // Map response DTO
        SignInResponseDto signInResponseDto = new SignInResponseDto
        {
            TenantId = user.TenantId,
            UserId = user.UserId,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            StatusCode = user.StatusCode,
            RoleId = user.RoleId
        };

        // Optionally generate JWT token
        // var token = await _jwtTokenService.GenerateTokenAsync(user, dto.RememberMe);

        return _response.Create(
            success: true,
            message: "Sign in successful",
            data: _mapper.Map<SignInResponseDto>(signInResponseDto)
        );
    }

    //  Sign out the current user
    public async Task<ServiceResponse<bool>> SignOutAsync()
    {

        return _response.Create(
            success: true,
            message: "Signed out successfully",
            data: true
        );
    }

}
