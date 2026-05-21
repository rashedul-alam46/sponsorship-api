using Sponsorship.Application.DTOs;
using Sponsorship.Application.Factories;
using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Services;

public class DropdownService : IDropdownService
{
    private readonly IDropdownRepository _repo;
    private readonly IServiceResponseFactory _response;
    private readonly Random _random = new Random();

    public DropdownService(IDropdownRepository repo, IServiceResponseFactory response)
    {
        _repo = repo;
        _response = response;
    }


    public async Task<ServiceResponse<IEnumerable<DropdownItem>>> GetDepartmentsAsync()
    {
        var result = await _repo.GetDepartmentDropdownAsync();
        if (!result.Any())
        {
            return _response.Create<IEnumerable<DropdownItem>>(
                success: false,
                message: "No departments found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Departments retrieved successfully",
             data: result
        );
    }

    public async Task<ServiceResponse<IEnumerable<DropdownItem>>> GetSponsorshipTypesAsync()
    {
        var result = await _repo.GetSponsorshipTypeDropdownAsync();
        if (!result.Any())
        {
            return _response.Create<IEnumerable<DropdownItem>>(
                success: false,
                message: "No sponsorship types found",
                data: null
            );
        }

        return _response.Create(
             success: true,
             message: "Sponsorship types retrieved successfully",
             data: result
        );
    }

}