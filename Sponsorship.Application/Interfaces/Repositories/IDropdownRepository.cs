using Sponsorship.Application.DTOs;

namespace Sponsorship.Application.Interfaces.Repositories;

public interface IDropdownRepository
{
    Task<IEnumerable<DropdownItem>> GetDepartmentDropdownAsync();
    Task<IEnumerable<DropdownItem>> GetSponsorshipTypeDropdownAsync();
}