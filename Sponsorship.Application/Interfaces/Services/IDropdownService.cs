using Sponsorship.Application.DTOs;
using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Interfaces.Services;

public interface IDropdownService
{
    Task<ServiceResponse<IEnumerable<DropdownItem>>> GetDepartmentsAsync();
    Task<ServiceResponse<IEnumerable<DropdownItem>>> GetSponsorshipTypesAsync();
}